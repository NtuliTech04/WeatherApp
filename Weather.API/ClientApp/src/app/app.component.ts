import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PositionApiService } from './application/services/position-api.service';
import { WeatherAPIService } from './application/services/weather-api.service';
import { environment } from 'src/environments/environment';
import { firstValueFrom } from 'rxjs';
import { DataStoreService } from './application/services/data-store.service';
import { LocationSearch, UrlOptions } from './domain/models/location-search';
import { RuntimeError } from './domain/models/errors';
import { Utilities } from './application/Utilities/helper-functions';
import { PositionStack } from './domain/models/position-stack';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Weather Forecast';

  debug = true;

  locationAPIAvailable = true;
  isLoading = false;
  baseUrl: string;

  constructor (
    private http: HttpClient,
    private positionStackApi: PositionApiService,
    private weatherService: WeatherAPIService,
    public dataStore: DataStoreService,
  ) {
  this.baseUrl = location.href;
 }

 ngOnInit() {
  if(!this.debug && this.hasLocationAPIKey()) {
    this.isLoading = true;
    this.loadInitialForecast().then(() => {
      console.log('Initial load done');
      this.isLoading = false;
    }).catch((error) => {
      console.log(error);
      this.isLoading = false;
    });
  }
 }

 ngAfterViewInit(): void {
  this.maybeShowAPINotice();
 }

 async getIPAddress(): Promise<any> {
  return firstValueFrom(this.http.get("https://api.ipify.org/?format=json"));
 }

 async loadInitialForecast() {
  try {
    await this.ipAddressSearch();
  } catch (error) {
    if (error instanceof RuntimeError.ForecastLocationError) {
      this.locationAPIAvailable = false;
      try {
          console.log('Location API cannot be reached, getting forecast from gps position');
          let position = await Utilities.getCurrentPosition();
          await this.gpsSearch(position.coords.latitude, position.coords.longitude);
      } catch(error2) {
          Utilities.displayError(error2);
      }
      } else if (error instanceof RuntimeError.ForecastError) {
          console.log('Weather API is NOT available');
          Utilities.displayError(error);
      } else {
      Utilities.displayError(error);
   }
  }
 }

 async ipAddressSearch() {
  let searchLocation = this.dataStore.getUserLocation();
  let ipData = await this.getIPAddress();
  let ipAddress = ipData.ip;

  if (searchLocation == null || !this.dataStore.lastSearchMatches(LocationSearch.SearchType.IP, {ipAddress})) {
    try {
      let locationResults = await this.positionStackApi.getForecastLocation(LocationSearch.SearchType.IP, {ipAddress});
      searchLocation = locationResults.data[0];
    } catch (error: any) {
      let message = error.message ? error.message : error;
      throw new RuntimeError.ForecastLocationError(message, LocationSearch.SearchType.IP);
    }
  }

  let forecast: any;
  try {
      forecast = await this.weatherService.getWeatherForecast(searchLocation.locality, UrlOptions.Unit.Metric);
  } catch (error: any) {
      let message = error.message ? error.message : error;
      throw new RuntimeError.ForecastError(message);
  }

  this.dataStore.setUserLocation(searchLocation);

  this.dataStore.setCurrentForecast({
      currentForecast: forecast.current,
      currentDailyForecast: forecast.nextFiveDays,
      currentForecastLocation: searchLocation,
  });

  this.dataStore.updateLastSearchData({
      longitude: searchLocation.longitude,
      latitude: searchLocation.latitude,
      ipAddress,
  });
 }

 async gpsSearch(latitude: number, longitude: number) {
  let searchLocation = this.dataStore.getCurrentForecastLocation();
  if (this.locationAPIAvailable && (searchLocation == null || !this.dataStore.lastSearchMatches(LocationSearch.SearchType.GPS, {latitude, longitude}))) {
      this.dataStore.updateLastSearchData({
          searchQuery: ''
      });
      let locationResults = await this.positionStackApi.getForecastLocation(LocationSearch.SearchType.GPS, {latitude, longitude});
      searchLocation = locationResults.data[0];
   }

  let forecast = await this.weatherService.getWeatherForecast(searchLocation.locality, UrlOptions.Unit.Metric);

  this.dataStore.setUserLocation(searchLocation);

  this.dataStore.setCurrentForecast({
      currentForecast: forecast.current,
      currentDailyForecast: forecast.nextFivedays,
      currentForecastLocation: searchLocation,
  });

  this.dataStore.updateLastSearchData({
      longitude,
      latitude,
  });
 }



 async querySearch(searchQuery: string) {
  let searchLocation = this.dataStore.getCurrentForecastLocation();
  if (this.locationAPIAvailable && (searchLocation == null || !this.dataStore.lastSearchMatches(LocationSearch.SearchType.SearchQuery, {searchQuery}))) {

      let locationResults = await this.positionStackApi.getForecastLocation(LocationSearch.SearchType.SearchQuery, {searchQuery: searchQuery});
      searchLocation = locationResults.data[0];
      console.log(locationResults); //

      // Get the location that is the shortest distance from the user
      if (this.dataStore.getUserLocation() != null) {
          searchLocation = PositionStack.getNearestLocation(this.dataStore.getUserLocation().latitude, this.dataStore.getUserLocation().longitude, locationResults);
      }
  }

  let forecast = await this.weatherService.getWeatherForecast(searchLocation.locality, UrlOptions.Unit.Metric);

  this.dataStore.setCurrentForecast({
      currentForecast: forecast.current,
      currentDailyForecast: forecast.nextFivedays,
      currentForecastLocation: searchLocation,
  });

  this.dataStore.updateLastSearchData({
      longitude: searchLocation.longitude,
      latitude: searchLocation.latitude,
      locality: searchLocation.locality,
      searchQuery
  });
}


async onSearchLocation(eventData: any) {
  console.log(eventData);
  this.isLoading = true;
  let type = eventData.type;
  try {
      switch(type) {
        case LocationSearch.SearchType.IP:
            await this.ipAddressSearch();
            break;
        case LocationSearch.SearchType.SearchQuery:
            await this.querySearch(eventData.searchQuery);
            break;
        case LocationSearch.SearchType.GPS:
            await this.gpsSearch(eventData.latitude, eventData.longitude);
            break;
        default:
            throw new Error(`Unknown search type: ${type}`);
      }
      if (this.dataStore.getCurrentForecastLocation() != null) {
        console.log('Selected Location:', this.dataStore.getCurrentForecastLocation());
      }
  } catch (error) {
      Utilities.displayError(error);
      this.maybeShowAPINotice();
  } finally {
      this.isLoading = false;
  }
 }


  hasLocationAPIKey() {
    return environment.key.length > 0;
  }

  maybeShowAPINotice() {
    if (!this.hasLocationAPIKey()) {
        alert('A https://positionstack.com/ API Key is not defined. Please register an account to obtain your own free api key, and then set it within the PositionApiService class in the services directory');
    }
  }
}
