import {Component, OnInit} from '@angular/core';
import {UserModel} from "./models/user.model";
import {AppValueService} from "./services/app-value.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements  OnInit  {
   _user: UserModel = defaultUser;
   language: string = 'English';

  defaultValue: any;
  constructor(private _appValueService: AppValueService) {
    _appValueService.getDefaultValue();
  }

  ngOnInit() {
    // this.loadDefaultValue();
  }
  // loadDefaultValue() {
  //   this._appValueService.getDefaultValue().subscribe(
  //     (data) => {
  //       this.defaultValue = data;
  //       console.log('Default Value:', this.defaultValue);
  //     },
  //     (error) => {
  //       console.error('Error loading default value:', error);
  //     }
  //   );
  // }
}

const defaultUser: UserModel = {
  id: '1',
  userName: 'LAMA'
}
