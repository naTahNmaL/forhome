import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {JourneyService} from "../../journey.service";

@Component({
  selector: 'app-journey-form',
  templateUrl: './journey-form.component.html',

  styleUrls: ['./journey-form.component.css']
})
export class JourneyFormComponent implements OnInit{
  value: string = 'Clear me';
  protected readonly length = length;
  protected readonly innerWidth = innerWidth;
  searchForm!: FormGroup;

  constructor(private _journeyService: JourneyService) {
  }
  ngOnInit(){
    this.searchForm = new FormGroup({
      'searchString': new FormControl(''),
      'status': new FormControl(''),
      'country': new FormControl(''),
      'currency': new FormControl(''),
      'amountFrom': new FormControl(''),
      'amountTo': new FormControl(''),
      'dateStartFrom': new FormControl(''),
      'dateStartTo': new FormControl(''),
      'dateEndFrom': new FormControl(''),
      'dateEndTo': new FormControl('')
    })
  }

  clearForm(){
    this.searchForm.reset();
  }

  onSubmit(){
    if(this.searchForm.invalid){
      return;
    }
    this._journeyService.search(this.searchForm);
    this.clearForm();
  }
}
