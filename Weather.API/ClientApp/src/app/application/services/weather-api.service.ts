import { WeatherForecast } from './../../domain/models/weather-forecast';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom, Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { RuntimeError } from 'src/app/domain/models/errors';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WeatherAPIService {

  private URL: string = environment.apiBaseUrl;
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

/**
 * Weather Forecast API Calls
 */

  async getWeatherForecast(location: string, unit: string) {
    //Current Weather
    let currentWeather = await firstValueFrom(this.getCurrentForecast(location, unit));
      console.log(currentWeather);
    //Null handling
    if (currentWeather == null) {
      throw new RuntimeError.ForecastError(`No Current Weather results returned for this city: ${location}`);
    }
    //Five days forecast
    let daily = await firstValueFrom(this.getFiveDayWeather(location, unit));

    return {
      current: currentWeather,
      nextFivedays: daily
    };
  }


  // getCurrentForecast(location: string, unit: string): Observable<any> {
  //   let url = `${this.URL}/WeatherService/current?location=${location}&unit=${unit}`;
  //   return this.http.get(url, { headers: this.headers }).pipe(
  //     map((res: Response) => {
  //       return res || {};
  //     }),
  //     catchError(this.errorHandler)
  //   );
  // }
  getCurrentForecast(location: string, unit: string): Observable<WeatherForecast.CurrentWeather> {
    let url = `${this.URL}/WeatherService/current?location=${location}&unit=${unit}`;
    return this.http.get<WeatherForecast.CurrentWeather>(url, { headers: this.headers }).pipe(
      map((response: WeatherForecast.CurrentWeather) => {
        return response ;
      }),
      catchError(this.errorHandler)
    );
  }

  // getFiveDayWeather(location: string, unit: string): Observable<WeatherForecast.FiveDayForecast> {
  //   let url = `${this.URL}/WeatherService/fivedays-forecast?location=${location}&unit=${unit}`;
  //   return this.http.get<WeatherForecast.FiveDayForecast>(url);
  // }
  getFiveDayWeather(location: string, unit: string): Observable<WeatherForecast.FiveDayForecast> {
    let url = `${this.URL}/WeatherService/fivedays-forecast?location=${location}&unit=${unit}`;
    return this.http.get<WeatherForecast.FiveDayForecast>(url, { headers: this.headers }).pipe(
      map((response: WeatherForecast.FiveDayForecast) => {
        return response;
      }),
      catchError(this.errorHandler)
    );
  }



/**
 * Error Handling
 */
  errorHandler(ex: HttpErrorResponse) {
    let errorMessage = '';
    if (ex.error instanceof ErrorEvent) {
      //Get client-side error
      errorMessage = ex.error.message;
    }
    else{
      //Get server-side erro
      errorMessage = `Error Code: ${ex.status}\nMessage: ${ex.message}`;
    }
    console.log(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}
