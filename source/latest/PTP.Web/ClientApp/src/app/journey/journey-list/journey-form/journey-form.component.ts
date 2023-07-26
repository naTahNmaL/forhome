import {Component, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {JourneyService} from "../../journey.service";

@Component({
  selector: 'app-journey-form',
  templateUrl: './journey-form.component.html',

  styleUrls: ['./journey-form.component.css']
})
export class JourneyFormComponent implements OnInit {
  validDatePattern = "/^(0[1-9]|1[012])\/(0[1-9]|[12][0-9]|3[01])\/\d{4}$/";
  protected readonly length = length;
  protected readonly innerWidth = innerWidth;
  errorMess: string = ''

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
      'dateStartTo': new FormControl('',),
      'dateEndFrom': new FormControl(''),
      'dateEndTo': new FormControl('',)
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
