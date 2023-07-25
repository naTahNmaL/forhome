
import { HttpClient } from '@angular/common/http';
import {Observable, Subject} from 'rxjs';
import { UserModel } from '../models/user.model';
import { Inject, Injectable } from '@angular/core';
import { Journey } from '../models/journey.model';
import {FormGroup} from "@angular/forms";
import {Router} from "@angular/router";


@Injectable()
export class JourneyService {
  userinfo: any;
  journeys: Journey[] = journeyList;
  forsearching: Journey[] = [...this.journeys];

  journeysChanged = new Subject<Journey[]>();

  constructor(private _router: Router) {
  }
  getJourneys(): Journey[]
  {
    return [...this.journeys];
  }

  getJourney(index:number) :Journey{
    return this.journeys[index];
  }

  addNewJourney(newJourney: any){

  }
  deleteJourney(index: number)
  {
    this.journeys.splice(index-1, 1);
    this.journeysChanged.next([...this.journeys]);
  }
  deleteSelected(list: Journey[]){
    list.forEach(selectedJourney => {
      const index = this.journeys.findIndex(
        journey => journey.id === selectedJourney.id
      );
      if (index !== -1) {
        this.journeys.splice(index, 1);
      }
    });
    // Emit the updated journeys array
    this.journeysChanged.next([...this.journeys]);
  }

  search(searchForm: FormGroup) {
    const searchTerm = searchForm.value;
    console.log(searchTerm);
    const filteredJourneys = this.journeys.filter(
      journey => (
          (searchTerm.name != null && journey.name.toLowerCase().includes(searchTerm.name)) ||
          (searchTerm.status != null && journey.status.includes(searchTerm.status)) ||
          (searchTerm.country != null && journey.country.includes(searchTerm.country)) ||
          (searchTerm.currency != null && journey.currency.includes(searchTerm.currency)) ||
          (searchTerm.amount != null && journey.amount >= searchTerm.amountFrom && journey.amount <= searchTerm.amountTo)
          // ||
          // (searchTerm.dateStartFrom != null && searchTerm.dateStartTo != null && journey.startDate >= searchTerm.dateStartFrom && journey.startDate <= searchTerm.dateStartTo) ||
          // (searchTerm.dateEndFrom != null && searchTerm.dateEndTo != null && journey.endDate >= searchTerm.dateEndFrom && journey.endDate <= searchTerm.dateEndTo)
      )

    )
    console.log(filteredJourneys);
    if(filteredJourneys.length != 0){
      this.journeysChanged.next(filteredJourneys);
    }
    else return;

  }
}

let journeyList: Journey[] = [
  {
    id: 1,
    userId: 123,
    name: 'Journey 1',
    description: 'Description for Journey 1aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabb',
    country: 'Country A',
    place: 'Place X',
    startDate: new Date('2023-07-01'),
    endDate: new Date('2023-07-10'),
    currency: 'USD',
    status: 'Completed',
    amount: 1000,
  },
  {
    id: 2,
    userId: 456,
    name: 'Journey 2',
    description: 'Description for Journey 2',
    country: 'Country B',
    place: 'Place Y',
    startDate: new Date('2023-08-01'),
    endDate: new Date('2023-08-15'),
    currency: 'EUR',
    status: 'In Progress',
    amount: 1500,
  },
  {
    id: 3,
    userId: 789,
    name: 'Journey 3',
    description: 'Description for Journey 3',
    country: 'Country C',
    place: 'Place Z',
    startDate: new Date('2023-09-01'),
    endDate: new Date('2023-09-20'),
    currency: 'GBP',
    status: 'Planning',
    amount: 2000,
  },
  {
    id: 4,
    userId: 123,
    name: 'Journey 4',
    description: 'Description for Journey 4',
    country: 'Country D',
    place: 'Place W',
    startDate: new Date('2023-10-01'),
    endDate: new Date('2023-10-31'),
    currency: 'JPY',
    status: 'In Progress',
    amount: 1800,
  },
  {
    id: 5,
    userId: 123,
    name: 'Journey 4',
    description: 'Description for Journey 4',
    country: 'Country D',
    place: 'Place W',
    startDate: new Date('2023-10-01'),
    endDate: new Date('2023-10-31'),
    currency: 'JPY',
    status: 'In Progress',
    amount: 1800,
  },
  {
    id: 6,
    userId: 123,
    name: 'Journey 4',
    description: 'Description for Journey 4',
    country: 'Country D',
    place: 'Place W',
    startDate: new Date('2023-10-01'),
    endDate: new Date('2023-10-31'),
    currency: 'JPY',
    status: 'In Progress',
    amount: 1800,
  },
  {
    id: 7,
    userId: 123,
    name: 'Journey 4',
    description: 'Description for Journey 4',
    country: 'Country D',
    place: 'Place W',
    startDate: new Date('2023-10-01'),
    endDate: new Date('2023-10-31'),
    currency: 'JPY',
    status: 'In Progress',
    amount: 1800,
  },

];
