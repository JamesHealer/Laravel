import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
} from '@angular/core';
import { NavigationCancel, NavigationEnd, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { LayoutService } from '../../core/layout.service';
import { environment } from './../../../../../environments/environment';
import {
  MenuComponent,
  DrawerComponent,
  ToggleComponent,
  ScrollComponent,
} from '../../../kt/components';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { LocalizationService } from 'src/app/modules/_services/localization.service';

@Component({
  selector: 'app-aside',
  templateUrl: './aside.component.html',
  styleUrls: ['./aside.component.scss'],
})
export class AsideComponent implements OnInit, OnDestroy {
  /*********************/
  AppFormLabels$: Observable<FormTitleHd[]>;
  AppFormLabels: FormTitleHd[] = [];
  lang: any;
  /*********************/
  asideTheme: string = '';
  asideMinimize: boolean = false;
  asideMenuCSSClasses: string = '';
  appPreviewDocsUrl: string = environment.appPreviewDocsUrl;
  @ViewChild('ktAsideScroll', { static: true }) ktAsideScroll: ElementRef;
  private unsubscribe: Subscription[] = [];

  constructor(private layout: LayoutService, private router: Router, private localizationService: LocalizationService) { }

  ngOnInit(): void {
    this.asideTheme = this.layout.getProp('aside.theme') as string;
    this.asideMinimize = this.layout.getProp('aside.minimize') as boolean;
    this.asideMenuCSSClasses = this.layout.getStringCSSClasses('asideMenu');
    this.routingChanges();
  }

  routingChanges() {
    const routerSubscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd || event instanceof NavigationCancel) {
        this.menuReinitialization();
      }
    });
    this.unsubscribe.push(routerSubscription);
  }

  menuReinitialization() {
    setTimeout(() => {
      MenuComponent.reinitialization();
      DrawerComponent.reinitialization();
      ToggleComponent.reinitialization();
      ScrollComponent.reinitialization();
      if (this.ktAsideScroll && this.ktAsideScroll.nativeElement) {
        this.ktAsideScroll.nativeElement.scrollTop = 0;
      }
    }, 50);
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
  
  refreshLocalStorage() {
    localStorage.removeItem('AppLabels');
    // 
    if (localStorage.getItem('AppLabels') === null) {
      this.lang = localStorage.getItem('lang');
      // Get form body labels 
      this.AppFormLabels$ = this.localizationService.getAppLabels()
      // Get observable as normal array of items
      this.AppFormLabels$.subscribe({
        next: data => {
          this.AppFormLabels = data;
          localStorage.setItem('AppLabels', JSON.stringify(this.AppFormLabels));
        },
        error: error => {
          console.log(error);
        },
        complete: () => {
          console.log('Request completed');
          location.reload();
        }
      })
    }
  }
}

