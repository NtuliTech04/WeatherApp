import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LocationSearch } from 'src/app/domain/models/location-search';
import { Utilities } from '../../Utilities/helper-functions';

interface EventData {
  searchQuery: string;
  latitude: number;
  longitude: number;
  type: LocationSearch.SearchType;
}

@Component({
  selector: 'app-forecast-location-search',
  templateUrl: './forecast-location-search.component.html',
  styleUrls: ['./forecast-location-search.component.css']
})
export class ForecastLocationSearchComponent implements OnInit {

  searchQuery!: string;

  @Input()
  //showQuerySearch!: boolean;
  showQuerySearch: boolean = true;

  @Output('searchLocation')
  searchLocationEmitter = new EventEmitter();

  constructor() {}
  ngOnInit(): void { }


  newEventData() {
    let eventData: EventData = {
        searchQuery: '',
        latitude: -1,
        longitude: -1,
        type: undefined, //-1
    };
    return eventData;
  }

  onSearchQueryLocation() {
    if (!this.searchQuery || this.searchQuery.trim().length == 0) {
      return;
    }
    let eventData = this.newEventData();
    eventData.searchQuery = this.searchQuery.trim(),
    eventData.type = LocationSearch.SearchType.SearchQuery,
    this.searchLocationEmitter.emit(eventData);
  }

  async onSearcGPSLocation() {
    try {
        let locationCacheMinutes = 2;
        let position = await Utilities.getCurrentPosition({maximumAge: 60 * locationCacheMinutes * 1000});
        let eventData = this.newEventData();

        eventData.latitude = position.coords.latitude;
        eventData.longitude = position.coords.longitude;
        eventData.type = LocationSearch.SearchType.GPS;

        this.searchLocationEmitter.emit(eventData);

      } catch (error: any) {
        if (error.code
            && (error.code == GeolocationPositionError.PERMISSION_DENIED
                || error.code == GeolocationPositionError.POSITION_UNAVAILABLE)
            && (!Utilities.isLocalNetwork() && !Utilities.isSecureConnection())) {
                let eventData = this.newEventData();
                eventData.type = LocationSearch.SearchType.IP;
                this.searchLocationEmitter.emit(eventData);
        } else {
          Utilities.displayError(error);
        }
     }
  }
}
