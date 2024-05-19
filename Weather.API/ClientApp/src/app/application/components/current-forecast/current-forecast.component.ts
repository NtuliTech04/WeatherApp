import { Component, Input, OnInit } from '@angular/core';
import { WeatherForecast } from 'src/app/domain/models/weather-forecast';
import { Utilities } from '../../Utilities/helper-functions';

@Component({
  selector: 'app-current-forecast',
  templateUrl: './current-forecast.component.html',
  styleUrls: ['./current-forecast.component.css']
})
export class CurrentForecastComponent implements OnInit{

  @Input()
  forecast!: WeatherForecast.CurrentWeather;

  localDate!: string;

  constructor() {}

  ngOnInit(): void {
    this.localDate = this.getLocalDateString();
  }

  getForecastImgSrc() {
    return WeatherForecast.getForcastImgSrc("01d")
  }

  getTimeOfDay() {
    return 'Day';
  }

  getOutsideDescription() {
    return "Clear Sky";
  }

  getLocalDateString() {
    let date = this.forecast.lastUpdated;
    return `${Utilities.getWeekdayName(date)} ${Utilities.getDateTimeString(date)}`;
  }

  getLocalSunrise() {
    return "6:33 AM";
  }

  getLocalSunset() {
    return "5:10 PM";
  }

  getLastUpdated() {
    let date = new Date(this.forecast.lastUpdated );
    return "9:46 AM";
  }
}
