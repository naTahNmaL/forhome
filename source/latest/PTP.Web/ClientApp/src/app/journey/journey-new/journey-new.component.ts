import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {F} from "@angular/cdk/keycodes";
import {Journey} from "../../models/journey.model";
import {JourneyService} from "../journey.service";

@Component({
  selector: 'app-journey-new',
  templateUrl: './journey-new.component.html',
  styleUrls: ['./journey-new.component.scss']
})
export class JourneyNewComponent implements OnInit{

  newJourneyForm: FormGroup;

  constructor(private _journeyService: JourneyService) {
    this.newJourneyForm = new FormGroup({
    'image': new FormControl(),
    'name': new FormControl('', Validators.required),
    'description': new FormControl(),
    'country': new FormControl(),
    'place': new FormControl(),
    'dateFrom': new FormControl(),
    'dateTo': new FormControl(),
    'currency': new FormControl(),
    'amount': new FormControl(),
    'day': new FormControl(),
    'night': new FormControl(),
    'status': new FormControl()
  })}

  ngOnInit() : void {

  }
  onSubmit(): void{
    if(!this.newJourneyForm){
      return;
    }

    console.log(this.newJourneyForm.value);
    this._journeyService.addNewJourney([this.newJourneyForm.value]);
  }
}
