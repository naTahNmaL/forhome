import {Component, OnInit} from '@angular/core';

import {AppAuthService} from "../app-auth.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {userLoginRequest} from "../../models/userLoginRequest.model";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  implements  OnInit{
  usernamePattern = /^[a-z]{3,15}$/i;

  authForm!: FormGroup;
  constructor(private _appAuthService: AppAuthService) {

  }

  ngOnInit(): void {
    this.authForm = new FormGroup({
      'username': new FormControl('', Validators.required),
      'password': new FormControl('', Validators.required)
    })
  }

  onSubmit(){
    if(this.authForm.invalid){
      return;
    }
    const username = this.authForm.value.username;
    const password = this.authForm.value.password;
    this._appAuthService.sendLoginRequest(username, password)
  }
}
