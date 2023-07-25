import {AfterViewInit, Component, Input, OnChanges, OnInit, SimpleChanges, ViewChild} from '@angular/core';
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator } from "@angular/material/paginator";
import {Journey} from "../../../models/journey.model";
import {SelectionModel} from "@angular/cdk/collections";
import {MatDialog} from "@angular/material/dialog";
import {JourneyDeleteConfirmComponent} from "./journey-delete-confirm/journey-delete-confirm.component";
import {JourneyService} from "../../journey.service";

@Component({
  selector: 'app-journey-infobar',
  templateUrl: './journey-infobar.component.html',
  styleUrls: ['./journey-infobar.component.css'],
})
export class JourneyInfobarComponent implements OnInit, AfterViewInit{
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  displayedColumns: string[] = ['checkAll', 'name', 'description', 'country', 'start-date', 'end-date', 'currency', 'amount', 'status', 'edit'];
  dataSource: MatTableDataSource<Journey>;
  selection = new SelectionModel<Journey>(true, []);

  constructor(public dialog: MatDialog, private _journeyService: JourneyService) {
    this.dataSource = new MatTableDataSource<Journey>([])
    this._journeyService.journeysChanged.subscribe((updatedJourneys) => {
      this.dataSource.data = updatedJourneys
    })
  }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this._journeyService.getJourneys())
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }
  toggleAllRows() {
    if (this.isAllSelected()) {
      this.selection.clear();
      return;
    }

    this.selection.select(...this.dataSource.data);
  }
  checkboxLabel(row?: Journey): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }

  onDeleteItem(element: any){
    const dialogRef = this.dialog.open(JourneyDeleteConfirmComponent);
    dialogRef.afterClosed().subscribe(accept => {
      if(accept){
        this._journeyService.deleteJourney(element.id);
      }
    })
  }
  onClickDeleteSelected(){
    const dialogRef = this.dialog.open(JourneyDeleteConfirmComponent);
    dialogRef.afterClosed().subscribe(accept => {
      if(accept){
        this._journeyService.deleteSelected(this.selection.selected);
        this.dataSource = new MatTableDataSource(this._journeyService.getJourneys());
        this.selection.clear();
      }
    })
  }

  openDialog(){
    const dialogRef = this.dialog.open(JourneyDeleteConfirmComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}



