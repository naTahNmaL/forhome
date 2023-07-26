import { Injectable } from "@angular/core";
import { Title } from "@angular/platform-browser";
import { NavigationEnd, Router } from "@angular/router";
import { BehaviorSubject, Subscription } from "rxjs";


@Injectable({ providedIn: 'root'})
export class AppTitleService{
  private _pageTitle: string[] = [];

  private pageTitleSubject = new BehaviorSubject<string[]>([]);
  public pageTitle$ = this.pageTitleSubject.asObservable();
  constructor(private router: Router) {
    this.updatePageTitleOnNavigation();
  }

  private updatePageTitleOnNavigation() {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.pageTitleSubject.next(this.getPageTitleFromUrl(event.url));
      }
    });
  }

  private getPageTitleFromUrl(url: string): string[] {
    var temp =  url.split('/');
    this._pageTitle[0] = temp[1];
    this._pageTitle[1] = url.substring(1);
    return this._pageTitle;
  }
}
