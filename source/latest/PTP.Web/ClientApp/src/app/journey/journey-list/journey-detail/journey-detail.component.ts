import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
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
  editJourney!: FormGroup;

  index!: number ;
  constructor(private _journeyService: JourneyService,
              private _router: Router) {
     this.index = +_router.url.split('/')[4] ;
  }

  ngOnInit(){
    this.journey = this._journeyService.getJourney(this.index-1);
    console.log(this.journey)

    this.editJourney = new FormGroup({
      'name' : new FormControl(this.journey.name, Validators.required),
      'description': new FormControl(this.journey.description, Validators.required),
      'country': new FormControl(this.journey.country, Validators.required),
      'place': new FormControl(this.journey.place, Validators.required),
      'startDate': new FormControl(this.journey.startDate, Validators.required),
      'endDate': new FormControl(this.journey.endDate, Validators.required),
      'currency': new FormControl(this.journey.currency, Validators.required),
      'amount': new FormControl(this.journey.amount, Validators.required),
      'status': new FormControl(this.journey.status, Validators.required)
    });
  }

}
