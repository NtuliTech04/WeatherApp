import { Component, OnInit } from '@angular/core';
import { FindCityService } from '../../services/find-city.service';
import {AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import {Observable} from 'rxjs';
import {startWith, map} from 'rxjs/operators';


/**
 * City name input autocomplete
 */
@Component({
  selector: 'app-forecast-location-search',
  templateUrl: './forecast-location-search.component.html',
  styleUrls: ['./forecast-location-search.component.css'],
})
export class ForecastLocationSearchComponent implements OnInit{

  submitted: boolean = false;
  searchCityForm: FormGroup;

  cityNames: string[] = [];
  filteredCities: Observable<string[]>;

  constructor (
    private builder: FormBuilder,
    private findCityService: FindCityService,
  ){
    this.citySearchFormValidation();
  }

  ngOnInit() {
     //Creates a list of city names from json data.
     this.findCityService.getCities().subscribe(data => {
      this.cityNames = data.map(c => c.name);
    });

    //Filters city names based on input value changes
    this.filteredCities = this.searchCityForm.get("cityName").valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );
  }

   /*
    * Form Validation
    */

   //Custom validation of city input value
   ValidateCity(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {

      let inputValue = control.value.trim();

      if(!inputValue) {return null};

      if (!this.cityNames.includes(inputValue)){
        return {invalidCity: true};
      } else{
        return null;
      }
    }
  }

  citySearchFormValidation() {
    this.searchCityForm = this.builder.group({
      cityName: ['', [Validators.required, this.ValidateCity()]]
    });
  }
  //Getter to access form control
  get validateForm() {
    return this.searchCityForm.controls;
  }




  onSubmit() {
    this.submitted = true;
    if(!this.searchCityForm.valid) {
      return false;
    }
    else{
      //Call API Service
    }
  }


  //Filter method/function
  private _filter(value: string): string[] {
    const filterValue = this._normalizeValue(value);
    return this.cityNames.filter(city => this._normalizeValue(city).includes(filterValue));
  }

  //Ignores whitespaces
  private _normalizeValue(value: string): string {
    return value.toLowerCase().replace(/\s/g, '');
  }
}
