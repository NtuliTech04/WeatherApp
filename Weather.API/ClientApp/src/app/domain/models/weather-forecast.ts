import { Time } from "@angular/common";
import { environment } from "src/environments/environment";

 export namespace WeatherForecast {

  //Current three hour forecast
  export interface CurrentWeather{
    timestamp: number;
    lastUpdated: Date; //Date&Time
    visibility: number;
    currentTemps: Temperatures;
    currentWind: Wind;
    currentWeather: WeatherCondition;
    // locationData: GeoLocation;
  }


  //Five days max, min, & humidity forecast
  export interface FiveDayForecast{
    fiveDayForecastData: DailyWeatherForecast[];
    // locationData: GeoLocation;
  }

  //Daily forecast
  export interface DailyWeatherForecast {
    timestamp: number;
    weatherDate: Date;
    minDayTemp: number;
    maxDatTemp: number;
    humidity: number;
  }

  //Three hour interval forecast for one day
  export interface ThreeHourForecast{
    timestamp: number;
    timeInterval: Time;
    visibility: number;
    weatherData: WeatherCondition;
    temperatureData: Temperatures;
    windData: Wind;
  }


  //Base models for weather forecast
  export interface WeatherCondition {
    condition: string;
    description: string;
    icon: string;
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
    sunrise: number,
    sunset: number,
    timezone: number,
    country: string
  }


  export function getForcastImgSrc(icon: string) {
    return `${environment.openWeatherIcons}/${icon}@2x.png`;
  }
}
