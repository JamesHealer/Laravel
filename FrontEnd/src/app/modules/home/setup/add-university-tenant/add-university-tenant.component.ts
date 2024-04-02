import { Component, OnInit } from '@angular/core';
import { CommonService } from 'src/app/modules/_services/common.service';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';

@Component({
  selector: 'app-add-university-tenant',
  templateUrl: './add-university-tenant.component.html',
  styleUrls: ['./add-university-tenant.component.scss']
})
export class AddUniversityTenantComponent implements OnInit {
// /*********************/
// formHeaderLabels$ :Observable<FormTitleHd[]>; 
// formBodyLabels$ :Observable<FormTitleDt[]>; 
// formBodyLabels :FormTitleDt[]=[]; 
// id:string = '';
// languageId:any;
// // FormId to get form/App language
// @ViewChild('AddUniversityTenant') hidden:ElementRef;
// /*********************/
//#region 
    /*----------------------------------------------------*/

    // Language Type e.g. 1 = ENGLISH and 2 =  ARABIC
    languageType: any;

    // Selected Language
    language: any;

    // We will get form lables from lcale storage and will put into array.
    AppFormLabels: FormTitleHd[] = [];

    // We will filter form header labels array
    formHeaderLabels: any[] = [];

    // We will filter form body labels array
    formBodyLabels: any[] = [];

    // FormId
    formId: string;

    /*----------------------------------------------------*/  
  //#endregion
  lang:string;
  constructor( public commonService:CommonService) { }

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
    this.formId = 'AddUniversityTenant';

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {
      console.log(this.languageType);
      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {

        if (labels.formID == this.formId && labels.language == this.languageType) {

          this.formHeaderLabels.push(labels);

          this.formBodyLabels.push(labels.formTitleDTLanguage);
          console.log(labels);

        }
      }
      console.log(this.formBodyLabels);
    }
    //#endregion
  }
  
}
