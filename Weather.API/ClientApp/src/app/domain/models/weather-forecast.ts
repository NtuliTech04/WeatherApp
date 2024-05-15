import { Time } from "@angular/common";

 export namespace WeatherForecast {

  //Current three hour forecast
  export interface CurrentWeather{
    dateTime: Date;
    weatherData: WeatherCondition[];
    temperatureData: Temperatures;
    visibility: number;
    windData: Wind;
  }


  //Five days max & min forecast
  export interface FiveDayForecast{
    fiveDayForecastData: DayHourlyForecast[];
  }


  //Three hour interval forecast for one day
  export interface DayHourlyForecast {
    date: Date;
    minTemp: number;
    maxTemp: number;
    dailyForecastData: ThreeHourForecast[];
  }


  export interface ThreeHourForecast{
    timestamp: number;
    timeInterval: Time;
    weatherData: WeatherCondition[];
    temperatureData: Temperatures;
    visibility: number;
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
}
