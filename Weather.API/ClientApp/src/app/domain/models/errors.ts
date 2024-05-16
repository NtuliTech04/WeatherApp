import { LocationSearch } from "./location-search";

export namespace RuntimeError {

  export class ForecastLocationError extends Error {
    code: LocationSearch.SearchType;
    constructor(msg: string, code: LocationSearch.SearchType){
      super(msg);
      this.code = code;
      //Set explicit prototype.
      Object.setPrototypeOf(this, LocationSearch.SearchType);
    }
  }


  export class ForecastError extends Error {
    constructor(msg: string) {
        super(msg);

        // Set the prototype explicitly.
        Object.setPrototypeOf(this, ForecastError.prototype);
    }
  }
}
