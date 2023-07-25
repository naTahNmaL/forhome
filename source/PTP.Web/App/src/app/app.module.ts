import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';

import { AppRoutingModule } from './app-routing.module';
import { JourneyModule } from './journey/journey.module';
import { NotFoundComponent } from './not-found/not-found.component';
import { AppTitleService } from './services/app-title.service';
import { AppUserComponent } from './app-user/app-user.component';
import { AppAuthComponent } from './app-auth/app-auth.component';
import { LoginComponent } from './app-auth/login/login.component';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,

    NotFoundComponent,
    AppUserComponent,
    AppAuthComponent,
    LoginComponent,


  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,

    JourneyModule,
    AppRoutingModule,
    MatToolbarModule,
    MatButtonModule,
  ],
  providers: [AppTitleService],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
