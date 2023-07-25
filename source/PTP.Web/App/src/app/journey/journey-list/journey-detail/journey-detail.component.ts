import {Component, OnInit} from '@angular/core';
import { FormGroup} from "@angular/forms";
import {JourneyService} from "../../journey.service";
import {Router} from "@angular/router";
import {Journey} from "../../../models/journey.model";

@Component({
  selector: 'app-journey-detail',
  templateUrl: './journey-detail.component.html',
  styleUrls: ['./journey-detail.component.css']
})
export class JourneyDetailComponent implements  OnInit{
  journey!: Journey ;
  editJourney= new FormGroup('');

  index!: number ;
  constructor(private _journeyService: JourneyService,
              private _router: Router) {
     this.index = +_router.url.split('/')[4] ;
  }

  ngOnInit(){
    this.journey = this._journeyService.getJourney(this.index);
    console.log(this.journey)
  }

}
