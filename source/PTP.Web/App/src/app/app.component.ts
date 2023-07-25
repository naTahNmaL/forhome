import { Component } from '@angular/core';
import {UserModel} from "./models/user.model";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
   _user: UserModel = defaultUser;
   language: string = 'English';

}

const defaultUser: UserModel = {
  id: '1',
  userName: 'LAMA',
  fullName: 'Tan Lam'
}
