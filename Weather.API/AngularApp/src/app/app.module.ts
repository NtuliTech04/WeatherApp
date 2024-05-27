import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FindCityService } from './application/services/find-city.service';
import { AsyncPipe, CommonModule, DatePipe } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MdbDropdownModule } from 'mdb-angular-ui-kit/dropdown';

import { AppComponent } from './app.component';
import { ForecastLocationSearchComponent } from './application/components/forecast-location-search/forecast-location-search.component';
import { ForecastLocationComponent } from './application/components/forecast-location/forecast-location.component';
import { CurrentForecastComponent } from './application/components/current-forecast/current-forecast.component';



@NgModule({
  declarations: [
    AppComponent,
    ForecastLocationSearchComponent,
    ForecastLocationComponent,
    CurrentForecastComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule,
    CommonModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatAutocompleteModule,
    AsyncPipe,
    NgbModule,
    MdbDropdownModule,
  ],
  providers: [
    FindCityService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
