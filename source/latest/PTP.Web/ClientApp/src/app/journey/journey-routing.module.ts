import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CommonModule } from "@angular/common";

import { JourneyComponent } from "./journey.component";
import { JourneyListComponent } from "./journey-list/journey-list.component";
import {JourneyNewComponent} from "./journey-new/journey-new.component";
import {JourneyDetailComponent} from "./journey-list/journey-detail/journey-detail.component";
import {AppAuthGuard} from "../app-auth/app-auth.guard";


const routes: Routes = [
  { path: 'Home/Journey', component: JourneyComponent, canActivate: [AppAuthGuard],
    children: [
      { path: '', component: JourneyListComponent},
      { path: 'New', component: JourneyNewComponent },
      { path: 'Edit/:id', component: JourneyDetailComponent},
  ]}
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class JourneyRoutingModule {}
