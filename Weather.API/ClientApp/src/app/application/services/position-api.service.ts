import { PositionStack } from './../../domain/models/position-stack';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { RuntimeError } from 'src/app/domain/models/errors';
import { LocationSearch } from 'src/app/domain/models/location-search';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PositionApiService {

  private positionAPI: string = environment.baseStackUrl;
  private Key: string = environment.key;

  constructor(private http: HttpClient) { }

  getForwardSearch(search: string) {
    let url = `${this.positionAPI}/forward?access_key=${this.Key}&query=${encodeURIComponent(search)}`;
    console.log(url);
    return this.http.get<PositionStack.LocationResult>(url);
  }

  getReverseSearch(ipAddress: string): any;
  getReverseSearch(latitude: number, longitude: number): any;
  getReverseSearch(param1: string | number, param2?: string | number): any {
    let search = '';
    if (param2 == null) {
        search = `${param1}`;
    } else {
        search = `${param1},${param2}`;
    }
    let url = `${this.positionAPI}/reverse?access_key=${this.Key}&query=${search}&limit=1`;
    console.log(url);
    return this.http.get<PositionStack.LocationResult>(url);
  }


  async getForecastLocation(type: LocationSearch.SearchType, options: LocationSearch.Options) {
    let observable!: Observable<PositionStack.LocationResult>;
    switch (type) {
        case LocationSearch.SearchType.IP:
            observable = this.getReverseSearch(options.ipAddress || '');
            break;
        case LocationSearch.SearchType.SearchQuery:
            observable = this.getForwardSearch(options.searchQuery || '');
            break;
        case LocationSearch.SearchType.GPS:
            observable = this.getReverseSearch(options.latitude || 0, options.longitude || 0);
            break;
        default:
            throw new Error(`Unknown search type: ${type}`);
      }
    let geocode = await firstValueFrom(observable);
    console.log(geocode);
    if (geocode.error != null) {
      throw new RuntimeError.ForecastLocationError(geocode.error.message, type);
    }  else if (!geocode.data || geocode.data.length == 0) {
      throw new RuntimeError.ForecastLocationError('No forecast location results returned', type);
    }
    return geocode;
  }
}
