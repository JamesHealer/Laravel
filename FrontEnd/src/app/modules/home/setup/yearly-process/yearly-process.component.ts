import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CommonService } from 'src/app/modules/_services/common.service';
import { UserFunctionsService } from 'src/app/modules/_services/user-functions.service';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';

@Component({
  selector: 'app-yearly-process',
  templateUrl: './yearly-process.component.html',
  styleUrls: ['./yearly-process.component.scss']
})
export class YearlyProcessComponent implements OnInit {
  // Language Type e.g. 1 = ENGLISH and 2 =  ARABIC
  languageType: any;

  // Selected Language
  language: any;

  // We will get form lables from lcale storage and will put into array.
  AppFormLabels: FormTitleHd[] = [];

  // We will filter form header labels array
  formHeaderLabels: any[] = [];
  formId: string;
  lang:any = '';
  // We will filter form body labels array
  formBodyLabels: any[] = [];
  nextPeriodCode: any;
  username:string;

  constructor(private _userFunctionsService: UserFunctionsService,
    private toastr: ToastrService,
    private commonService:CommonService
    ) { }

  ngOnInit(): void {
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang;
    })
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'YearlyProcess';
    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {

      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {
        if (labels.formID == this.formId) {
          this.formHeaderLabels.push(labels);
          const jsonFormTitleDTLanguage = labels.formTitleDTLanguage.reduce((result: any, element) => {
            result[element.labelId] = element;
            return result;
          }, {})
          this.formBodyLabels.push(jsonFormTitleDTLanguage);
        }
      }
      console.log(this.formBodyLabels)
    }
    
    this.nextPeriodCode = JSON.parse(localStorage.getItem('user') || '{}')[0].nextPeriodCode;
    this.username = JSON.parse(localStorage.getItem('user') || '{}')[0].username;
  }

  onOpenCalendar(container: any) {
    container.monthSelectHandler = (event: any): void => {
      container._store.dispatch(container._actions.select(event.date));
    };
    container.setViewMode('month');
  }

  calculateYearlyProcessForMembership() {
    this._userFunctionsService.calculateYearlyProcessForMembership(this.nextPeriodCode, this.username).subscribe((res: any) => {
      if (res.result>0) {
        this.toastr.success(res.message);
      }else{
        this.toastr.warning(res.message);
      }
    }, error => {
      this.toastr.error("Something went wrong!!")
    })

  }
}
