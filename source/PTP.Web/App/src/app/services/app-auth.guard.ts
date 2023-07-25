import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from "@angular/router";
import {Observable} from "rxjs";

export class AppAuthGuard implements CanActivate{
  constructor(private _router: Router) {
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):
    Observable<boolean | UrlTree>
    | Promise<boolean
    | UrlTree>
    | boolean
    | UrlTree
  {
    return ;
  }

}
