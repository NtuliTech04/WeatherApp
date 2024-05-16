import { Time } from "@angular/common";

 export namespace WeatherForecast {

  //Current three hour forecast
  export interface CurrentWeather{
    updatedOn: Date; //Date&Time
    weatherData: WeatherCondition[];
    temperatureData: Temperatures;
    visibility: number;
    windData: Wind;
    locationData: GeoLocation;
  }


  //Five days max, min, & humidity forecast
  export interface FiveDayForecast{
    fiveDayForecastData: DailyWeatherForecast[];
    locationData: GeoLocation;
  }

  //Daily forecast
  export interface DailyWeatherForecast {
    timestamp: number;
    date: Date;
    minDayTemp: number;
    maxDatTemp: number;
    humidity: number;
  }

  //Three hour interval forecast for one day
  export interface ThreeHourForecast{
    timestamp: number;
    timeInterval: Time;
    visibility: number;
    weatherData: WeatherCondition[];
    temperatureData: Temperatures;
    windData: Wind;
  }


  //Base models for weather forecast
  export interface WeatherCondition {
    condition: string;
    description: string;
  }

  export interface Temperatures {
    temp: number;
    feelsLike: number;
    minTemp: number;
    maxTemp: number;
    humidity: number;
  }

  export interface Wind {
    speed: number;
    direction: number;
  }

  export interface GeoLocation {
    lat: number;
    lon: number;
    cityName: string;
    country: string
  }
}
