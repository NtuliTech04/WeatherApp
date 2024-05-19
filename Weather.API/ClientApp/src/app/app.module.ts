import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { ForecastLocationComponent } from './application/components/forecast-location/forecast-location.component';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { CurrentForecastComponent } from './application/components/current-forecast/current-forecast.component';
import { ForecastLocationSearchComponent } from './application/components/forecast-location-search/forecast-location-search.component';


@NgModule({
  declarations: [
    AppComponent,
    CurrentForecastComponent,
    ForecastLocationSearchComponent,
    ForecastLocationComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatInputModule,
    MatIconModule,
    FormsModule,
    MatButtonModule,
    MatProgressSpinnerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
