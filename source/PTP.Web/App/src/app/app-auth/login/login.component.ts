import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {User} from "oidc-client";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements  OnInit  {
  usernamePattern = /^[a-z]{3,15}$/i;

  constructor( private _router: Router) {}

  ngOnInit() {
  }


}
