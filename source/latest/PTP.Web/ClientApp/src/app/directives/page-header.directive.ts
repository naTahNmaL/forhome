import { Directive, OnInit, OnDestroy } from '@angular/core';
import { AppTitleService } from '../services/app-title.service';
import { Subscription } from 'rxjs';

@Directive({
  selector: '[appPageHeader]',
})
export class PageHeaderDirective implements OnInit, OnDestroy {
  private _pageTitleSubscription!: Subscription;

  constructor(private _pageTitleService: AppTitleService) {}

  ngOnInit() {
    this._pageTitleSubscription = this._pageTitleService.pageTitle$.subscribe(
      (title) => {
        this.updatePageTitle(title[0]);
      }
    );
  }

  ngOnDestroy() {
    this._pageTitleSubscription.unsubscribe();
  }

  private updatePageTitle(title: string) {
    const pageHeader = document.querySelector('.pageHeader h3');
    if (pageHeader) {
      pageHeader.innerHTML = `${title}`;
    }
  }
}
