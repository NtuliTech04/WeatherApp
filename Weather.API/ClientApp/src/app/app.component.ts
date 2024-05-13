import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Weather Forecast';

  debug = true;

  isLoading = false;
  baseUrl: string;

  constructor(){
    this.baseUrl = location.href;
  }
}
