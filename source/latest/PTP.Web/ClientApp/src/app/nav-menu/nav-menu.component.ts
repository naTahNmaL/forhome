import {Component, Input, OnInit} from '@angular/core';
import {UserModel} from "../models/user.model";
import {Subscription} from "rxjs";
import {AppAuthService} from "../app-auth/app-auth.service";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit
{
  @Input() _user!: UserModel;
  language: string = "en";
  username!: any;
  isLogin: boolean = false;
  private _userLogin: Subscription;
  constructor(private _appAuthService: AppAuthService) {
    this._userLogin = _appAuthService.user.subscribe(
      user => {
        this.username = user?.userName;
        this.isLogin = !!user;
      }
    )
  }

  ngOnInit() {

  }


  isExpanded = false;
  collapse() {
    this.isExpanded = false;
  }
  onLogOut(){
    this._appAuthService.Logout();
  }
  toggleFrench() {
    this.language =   "fr"; // Unselect the other button
  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  toggleEnglish() {
    this.language = "en";
  }

}
