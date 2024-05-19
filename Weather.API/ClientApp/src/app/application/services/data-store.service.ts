import { LocationSearch } from 'src/app/domain/models/location-search';
import { Injectable } from '@angular/core';
import { PositionStack } from 'src/app/domain/models/position-stack';
import { WeatherForecast } from 'src/app/domain/models/weather-forecast';

/**
 * Application services holding related data
*/

interface ForecastData {
  currentForecastLocation: PositionStack.Location | any;
  currentForecast: WeatherForecast.CurrentWeather | any;
  currentDailyForecast: WeatherForecast.FiveDayForecast;
}

@Injectable({
  providedIn: 'root'
})
export class DataStoreService {

  private userLocation!: PositionStack.Location;

  baseUrl!: string;
  lastSearchData: LocationSearch.Options = {
    searchQuery: '',
    longitude: 0,
    latitude: 0,
    ipAddress: ''
  };

  private forecastData: ForecastData = {
    currentForecastLocation: undefined,
    currentForecast: undefined,
    currentDailyForecast: undefined
  };

  constructor() {}

  getUserLocation(): PositionStack.Location {
    return this.userLocation;
  }

  getCurrentForecastLocation(): PositionStack.Location {
    return this.forecastData.currentForecastLocation;
  }

  getCurrentForecast(): WeatherForecast.CurrentWeather {
    return this.forecastData.currentForecast;
  }

  getCurrentDailyForecast(): WeatherForecast.FiveDayForecast {
    return this.forecastData.currentDailyForecast;
  }

  setUserLocation(data: PositionStack.Location) {
    this.userLocation = data;
  }

  setCurrentForecast(data: ForecastData) {
    this.copyProps(data, this.forecastData);
  }

  updateLastSearchData(data: LocationSearch.Options) {
    this.copyProps(data, this.lastSearchData);
  }

  lastSearchMatches(type: LocationSearch.SearchType, options: LocationSearch.Options) {
    switch (type) {
        case LocationSearch.SearchType.IP:
            return this.lastSearchData.ipAddress == options.ipAddress;
        case LocationSearch.SearchType.GPS:
            return this.lastSearchData.longitude == options.longitude && this.lastSearchData.latitude == options.latitude;
        case LocationSearch.SearchType.SearchQuery:
            return this.lastSearchData.searchQuery == options.searchQuery;
        default:
            throw new Error(`Unknown search type: ${type}`);
    }
  }

  private copyProps(source: any, destination: any) {
    for (let prop in source) {
        if (source[prop] != undefined) {
            destination[prop] = source[prop];
        }
    }
  }
}
