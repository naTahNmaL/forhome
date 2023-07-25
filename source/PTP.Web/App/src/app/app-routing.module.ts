import { NgModule } from "@angular/core";
import { PreloadAllModules, RouterModule, Routes } from "@angular/router";
import { NotFoundComponent } from "./not-found/not-found.component";
import { AppUserComponent } from "./app-user/app-user.component";
import {LoginComponent} from "./app-auth/login/login.component";

const routes: Routes = [
  { path: '', redirectTo: 'Home/Journey', pathMatch: 'full'},
  { path: 'User', component: AppUserComponent},
  { path: 'Login', component: LoginComponent},
  { path: '**', component: NotFoundComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules})],
  exports: [RouterModule]
})
export class AppRoutingModule {}
