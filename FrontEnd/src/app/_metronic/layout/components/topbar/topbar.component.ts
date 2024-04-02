import { Component, OnInit } from '@angular/core';
import { LayoutService } from '../../core/layout.service';
import { LoginService } from 'src/app/modules/_services/login.service';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.scss'],
})
export class TopbarComponent implements OnInit {
  toolbarButtonMarginClass = 'ms-1 ms-lg-3';
  toolbarButtonHeightClass = 'w-30px h-30px w-md-40px h-md-40px';
  toolbarUserAvatarHeightClass = 'symbol-30px symbol-md-40px';
  toolbarButtonIconSizeClass = 'svg-icon-1';
  headerLeft: string = 'menu';
  menuHeading: any[] = [];
  lang: any;
  AppFormLabels$: Observable<FormTitleHd[]>;
  AppFormLabels: FormTitleHd[] = [];
  constructor(private layout: LayoutService, private loginService: LoginService,
    private router: Router,
    private localizationService: LocalizationService,) { }

  ngOnInit(): void {
    this.headerLeft = this.layout.getProp('header.left') as string;
  }
  refreshPage() {

    localStorage.removeItem('AppLabels');
    localStorage.removeItem("userMenu");
    const userId = JSON.parse(localStorage.getItem('user') || '{}')[0].userId;
    const tenantId = JSON.parse(localStorage.getItem('user') || '{}')[0].tenantId;
    // 
    if (localStorage.getItem('AppLabels') === null) {
      this.lang = localStorage.getItem('lang');

      this.loginService.GetUserFunctionsByUserId(userId).subscribe((response: any[]) => {
        this.menuHeading = response;
        localStorage.setItem('userMenu', JSON.stringify(this.menuHeading));
        this.loginService.RefreshUpdatedData(tenantId).subscribe((res:any)=>{
          console.log(res);
        })

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
            location.reload();
          }
        })
      });
    }


    // if (val == '/dashboard') {
    //   const divs = document.querySelectorAll('.show');
    //   divs.forEach((x) => {
    //     x.classList.remove('show')
    //   })
    // }
  }

  navigateDashboard() {
    this.router.navigate(['/dashboard'])
    const divs = document.querySelectorAll('.show');
    divs.forEach((x) => {
      x.classList.remove('show')
    })
  }
}
