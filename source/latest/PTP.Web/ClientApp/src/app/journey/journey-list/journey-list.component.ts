import { Component, OnInit } from '@angular/core';
import { JourneyService } from '../journey.service';
import { Journey } from 'src/app/models/journey.model';

@Component({
  selector: 'app-journey-list',
  templateUrl: './journey-list.component.html',
  styleUrls: ['./journey-list.component.css']
})
export class JourneyListComponent implements OnInit {
  journeys!: Journey[];
  constructor(private _journeyService: JourneyService){

  }

  ngOnInit(): void{
    this.journeys = this._journeyService.journeys;
  }
}
