import {HttpClient} from "@angular/common/http";
import {Injectable, OnInit} from "@angular/core";
import {Observable} from "rxjs";
import {defaultData} from "../models/defaultData.model";
@Injectable()
export class AppValueService implements  OnInit{
  val!: defaultData;
  constructor(private _http: HttpClient) {

  }
  ngOnInit() {
    this.getDefaultValue();
    console.log(this.val)
  }

  getDefaultValue(){
     this._http.get<defaultData>("/defaultData").subscribe(
      response => {
        console.log(response.id)
      },
       error => {
        console.log(Error, error)
       }
    )
  }
}
