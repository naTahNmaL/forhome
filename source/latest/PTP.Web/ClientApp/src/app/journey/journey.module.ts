import { NgModule } from "@angular/core";
import { JourneyListComponent } from "./journey-list/journey-list.component";
import { CommonModule } from "@angular/common";
import { JourneyRoutingModule } from "./journey-routing.module";
import { JourneyService } from "./journey.service";
import { JourneyComponent } from "./journey.component";
import { AppTitleService } from "../services/app-title.service";
import { PageHeaderDirective } from "../directives/page-header.directive";
import { JourneyNewComponent } from './journey-new/journey-new.component';

import { JourneyFormComponent } from './journey-list/journey-form/journey-form.component';
import { JourneyDetailComponent } from './journey-list/journey-detail/journey-detail.component';
import { JourneyInfobarComponent } from './journey-list/journey-infobar/journey-infobar.component';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatSelectModule} from "@angular/material/select";
import {MatIconModule} from "@angular/material/icon";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatButtonModule} from "@angular/material/button";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatNativeDateModule} from "@angular/material/core";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatTableModule} from "@angular/material/table";
import {MatPaginatorModule} from "@angular/material/paginator";
import {MatCheckboxModule} from "@angular/material/checkbox";
import { JourneyDeleteConfirmComponent } from './journey-list/journey-infobar/journey-delete-confirm/journey-delete-confirm.component';
import {MatDialogModule} from "@angular/material/dialog";
import {MatTooltipModule} from "@angular/material/tooltip";

import {ShortenPipe} from "../pipes/shorten.pipe";
import {MatGridListModule} from "@angular/material/grid-list";
import {MatChipsModule} from "@angular/material/chips";
import {MatSortModule} from "@angular/material/sort";
import {AppAuthGuard} from "../app-auth/app-auth.guard";

@NgModule({
  imports: [
    CommonModule,
    JourneyRoutingModule,

    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatIconModule,
    FormsModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatToolbarModule,
    MatTableModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatDialogModule,
    MatTooltipModule,
    MatGridListModule,
    ReactiveFormsModule,
    MatChipsModule,
    MatSortModule,

  ],

  declarations: [
    JourneyListComponent,
    JourneyComponent ,
    PageHeaderDirective,
    JourneyNewComponent,

    JourneyFormComponent,
    JourneyDetailComponent,
    JourneyInfobarComponent,
    JourneyDeleteConfirmComponent,

    ShortenPipe
  ],
  providers: [
    JourneyService,
    AppTitleService,
    AppAuthGuard
  ]
})
export class JourneyModule {}
