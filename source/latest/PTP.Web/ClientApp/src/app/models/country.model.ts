import {PlaceModel} from "./place.model";

export class CountryModel {
  constructor(
    public id: number,
    public name: string,
    public place: PlaceModel[]
  ) {
  }
}
