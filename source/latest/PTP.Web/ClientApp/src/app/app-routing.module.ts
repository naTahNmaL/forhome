import { NgModule } from "@angular/core";
import { PreloadAllModules, RouterModule, Routes } from "@angular/router";
import { NotFoundComponent } from "./not-found/not-found.component";
import { AppUserComponent } from "./app-user/app-user.component";
import { LoginComponent} from "./app-auth/login/login.component";
import {AppAuthGuard} from "./app-auth/app-auth.guard";

const routes: Routes = [
  { path: '', redirectTo: 'Home/Journey', pathMatch: 'full'},
  { path: 'Login', component: LoginComponent},
  { path: 'Home/Journey', loadChildren: () => import("./journey/journey.module").then((m) => m.JourneyModule)},
  { path: 'User', component: AppUserComponent, canActivate: [AppAuthGuard]},
  { path: '**', component: NotFoundComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules})],
  exports: [RouterModule]
})
export class AppRoutingModule {}
