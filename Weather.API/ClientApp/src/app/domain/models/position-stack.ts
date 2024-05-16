import { Utilities } from "src/app/application/Utilities/helper-functions";

export namespace PositionStack {

  export interface LocationResult {
    data: Location[];
    error: Error;
  }

  export interface Location {
    latitude: number
    longitude: number
    type: string
    name: string
    number: any
    postal_code: string
    street: any
    confidence: number
    region: string
    region_code: string
    county: string
    locality: string
    administrative_area: any
    neighbourhood: any
    country: string
    country_code: string
    continent: string
    label: string
  }


  export interface Error {
    code: string;
    message: string;
  }

  export function getNearestLocation(latitude: number, longitude: number, locationResults: PositionStack.LocationResult) {
    let nearestDistance = Number.MAX_VALUE;
    let nearestLocation!: PositionStack.Location;
    for (let location of locationResults.data) {
        let distance = Utilities.getDistance(latitude, longitude, location.latitude, location.longitude);
        if (distance < nearestDistance) {
            nearestLocation = location;
            nearestDistance = distance;
        }
    }
    return nearestLocation;
  }
}
