import {Component, Input} from '@angular/core';
import {UserModel} from "../models/user.model";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  @Input() _user!: UserModel;
  @Input() language!: string;

  isLogin: boolean = false;
  isExpanded = false;
  guest: boolean = true;
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
