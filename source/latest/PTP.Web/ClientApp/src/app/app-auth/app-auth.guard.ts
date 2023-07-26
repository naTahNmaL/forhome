import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from "@angular/router";
import {map, Observable, take} from "rxjs";
import {AppAuthService} from "./app-auth.service";
import {Injectable} from "@angular/core";
@Injectable()
export class AppAuthGuard implements CanActivate{
  constructor(private _router: Router, private _appAuthService: AppAuthService) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean
    | UrlTree
    | Observable<boolean| UrlTree>
    | Promise<boolean | UrlTree>
  {
    return this._appAuthService.user.pipe(
      take(1),
      map(user => {
        const isAuth = !!user;
        if (isAuth) {
          return state.url.includes('/Login') ? this._router.parseUrl('/Home/Journey') : true;
        }
        return this._router.createUrlTree(['Login']);
      })
    );
  }
}
