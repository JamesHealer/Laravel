import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { DomSanitizer } from '@angular/platform-browser';
import { MenuHeading } from 'src/app/modules/models/MenuHeading';
import { UserFunctionDto } from 'src/app/modules/models/UserFunctions/UserFunctionDto';
import { CommonService } from 'src/app/modules/_services/common.service';
import { environment } from '../../../../../../environments/environment';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { LoginService } from 'src/app/modules/_services/login.service';

@Component({
  selector: 'app-aside-menu',
  templateUrl: './aside-menu.component.html',
  styleUrls: ['./aside-menu.component.scss'],
})

export class AsideMenuComponent implements OnInit {
  appAngularVersion: string = environment.appVersion;
  appPreviewChangelogUrl: string = environment.appPreviewChangelogUrl;

  @Output() dataEvent = new EventEmitter<string>();
  //
  menuHeading: any[] = [];
  color: any;
  lang: any;
  AppFormLabels$: Observable<FormTitleHd[]>;
  AppFormLabels: FormTitleHd[] = [];

  constructor(private common: CommonService,
    private router: Router,
    private localizationService: LocalizationService,
    private loginService: LoginService,
    private sanitizer: DomSanitizer) {
    this.common.menuSessionUdpated.subscribe((result: any) => {
      this.setMenuFromSession();
    })
  }

  ngOnInit(): void {

    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    this.setMenuFromSession();
  }

  sidebarMenuItem: any = [];
  setMenuFromSession() {
    let menuItem: any = []
    let highLightHeading: any = []
    this.menuHeading = JSON.parse(localStorage.getItem('userMenu') || '[]');
    if(this.menuHeading.length > 0) {
      this.menuHeading.map((m: any) => {
        menuItem.push({
          headingNameEnglish: m.headingNameEnglish,
          headingNameArabic: m.headingNameArabic,
          menuItems: m.menuItems,
          headingMenuId: m.headingMenuId,
          headingIconPath: m.headingIconPath,
          headingURLOption: m.headingURLOption
        })
      })
  
      this.menuHeading[0].listMenuHighLightHeading.map((x: any) => {
        if (x.language == 1) {
          highLightHeading.push({
            arabicTitle: x.arabicTitle,
            title: x.title,
            orderBy: x.orderBy
          })
        }
      })
  
      menuItem.map((x: any) => {
        this.sidebarMenuItem.push({
          headingNameEnglish: x.headingNameEnglish,
          headingNameArabic: x.headingNameArabic,
          menuItems: x.menuItems,
          highLightHeadingarabicTitle: x.headingNameArabic,
          highLightHeadingtitle: x.headingNameEnglish,
          headingIconPath: x.headingIconPath,
          headingMenuId: x.headingMenuId,
          headingURLOption: x.headingURLOption
        })
      })
  
      console.log(this.menuHeading);
      console.log(highLightHeading, 'highLightHeading');
      console.log(this.sidebarMenuItem, 'sidebarMenuItem');
    }

    setTimeout(() => {
      document.getElementById('0')?.classList.remove('show')
    }, 1000)

  }

  openRequestForDiscountForm(title: string) {
    this.common.sendFormTitle(title);
    this.redirectTo('/service-setup/add-service');
  }

  // Manually redirect to URL to dynamicall change title of form
  redirectTo(uri: string) {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate([uri]));
  }

  toPrint(val: string) {
    localStorage.setItem('LabelFrom', val);
  }
  // refreshPage(val: any) {
  //   if (val != '/dashboard') {
  //     localStorage.removeItem('AppLabels');
  //     localStorage.removeItem("userMenu");
  //     const userId = JSON.parse(localStorage.getItem('user') || '{}')[0].userId;
  //     // 
  //     if (localStorage.getItem('AppLabels') === null) {
  //       this.lang = localStorage.getItem('lang');

  //       this.loginService.GetUserFunctionsByUserId(userId).subscribe((response: any[]) => {
  //         this.menuHeading = response;
  //         localStorage.setItem('userMenu', JSON.stringify(this.menuHeading));

       
  //       // Get form body labels 
  //       this.AppFormLabels$ = this.localizationService.getAppLabels()
  //       // Get observable as normal array of items
  //       this.AppFormLabels$.subscribe({
  //         next: data => {
  //           this.AppFormLabels = data;
  //           localStorage.setItem('AppLabels', JSON.stringify(this.AppFormLabels));
  //         },
  //         error: error => {
  //           console.log(error);
  //         },
  //         complete: () => {
  //           location.reload();
  //         }
  //       })
  //     });
  //     }
  //   }

  //   if (val == '/dashboard') {
  //     const divs = document.querySelectorAll('.show');
  //     divs.forEach((x) => {
  //       x.classList.remove('show')
  //     })
  //   }
  // }

  ngOnDestroy() {
    this.sidebarMenuItem = [];
  }
}
