import { Component } from '@angular/core';
import {Subscription} from "rxjs";
import {JourneyService} from "../journey/journey.service";
import {AppTitleService} from "../services/app-title.service";

@Component({
  selector: 'app-app-user',
  templateUrl: './app-user.component.html',
  styleUrls: ['./app-user.component.css']
})
export class AppUserComponent {

  _pageTitle: string[] = [];

  private pageTitleSubscription: Subscription;

  constructor(private _appTitleService: AppTitleService ){
    this.pageTitleSubscription = this._appTitleService.pageTitle$.subscribe(
      (title) => {
        this._pageTitle = title;
      }
    );
  }
}
