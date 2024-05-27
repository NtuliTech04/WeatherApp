import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FindCityService {

  constructor(private http: HttpClient) { }

  //Gets ZA Cities from json file
  getCities(): Observable<any[]> {
    return this.http.get<any[]>('/assets/json/City.json');
  }
}
