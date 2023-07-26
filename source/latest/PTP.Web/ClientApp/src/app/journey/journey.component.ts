import { HttpClient } from '@angular/common/http';
import {Component, OnInit, Inject, OnChanges, SimpleChanges, AfterViewInit} from '@angular/core';
import { JourneyService } from './journey.service';
import { AppTitleService } from '../services/app-title.service';
import { Subscription } from 'rxjs';
import {Route, Router} from "@angular/router";

@Component({
  selector: 'app-journey',
  templateUrl: './journey.component.html',
  styleUrls: ['./journey.component.css']
})
export class JourneyComponent implements OnInit{
  userinfo: any = [];
  _pageTitle: string[] = [];
  createJourney: boolean = true;
  private pageTitleSubscription: Subscription;

  constructor(
    private _journeyService: JourneyService,
    private _appTitleService: AppTitleService,
    private _router: Router,
  ){
    this.pageTitleSubscription = this._appTitleService.pageTitle$.subscribe(
      (title) => {
        this._pageTitle = title;
      }
    );
  }

  ngOnInit(): void {
    this.userinfo = this._journeyService.userinfo;

  }



  createNewJourney(){
    this.createJourney = !this.createJourney;
    this._router.navigate(["Home/Journey/New"]);
  }
}

