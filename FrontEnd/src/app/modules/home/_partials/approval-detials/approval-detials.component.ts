import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { Observable } from 'rxjs';
import { FormTitleDt } from 'src/app/modules/models/formTitleDt';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { SelectApprovalRoleDto } from 'src/app/modules/models/ServiceSetup/SelectApprovalRoleDto';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import { CommonService } from 'src/app/modules/_services/common.service';

@Component({
  selector: 'app-approval-detials',
  templateUrl: './approval-detials.component.html',
  styleUrls: ['./approval-detials.component.scss']
})
export class ApprovalDetialsComponent implements OnInit {

  @Input() accordialApprovalDetails: string;
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
  formBodyLabels: any = {
    en: {},
    ar: {}
  };

  // FormId
  formId: string;
  lang: string;

    /*----------------------------------------------------*/  
  //#endregion

  @Input() parentFormGroup: FormGroup;
  approvalDetailsForm: FormGroup;

  //
  // approvalRoles$: Observable<SelectApprovalRoleDto[]>;
  approvalRoles$:SelectApprovalRoleDto[];
  
  constructor(private commonDbService: DbCommonService,
    public common:CommonService){ }

  ngOnInit(): void {
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC

    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'AddService';

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {

      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {

        if (labels.formID == this.formId) {

          const jsonFormTitleDTLanguage = labels.formTitleDTLanguage.reduce((result: any, element) => {
            result[element.labelId] = element;
            return result;
          }, {})
          if(labels.language == 1 ) {
            this.formBodyLabels['en'] = jsonFormTitleDTLanguage;
          } else if (labels.language == 2) {
            this.formBodyLabels['ar'] = jsonFormTitleDTLanguage;
          }
          // this.formBodyLabels.push(jsonFormTitleDTLanguage);
          console.log(this.formHeaderLabels)
          console.log(this.formBodyLabels);

        }
      }
    }
    //#endregion
    this.initializeForm();
    if (this.parentFormGroup) {
      this.parentFormGroup.setControl('approvalDetailsForm', this.approvalDetailsForm);
    }
    //
     this.commonDbService.GetApprovalRoles().subscribe((res:any)=>{
      this.approvalRoles$= res;
    });
    
  }

  initializeForm() {
    this.approvalDetailsForm = new FormGroup({
      serApproval1: new FormControl(''),
      approvalBy1: new FormControl(''),
      approvedDate1: new FormControl(''),
      
      serApproval2: new FormControl(''),
      approvalBy2: new FormControl(''),
      approvedDate2: new FormControl(''),


      serApproval3: new FormControl(''),
      approvalBy3: new FormControl(''),
      approvedDate3: new FormControl(''),

      serApproval4: new FormControl(''),
      approvalBy4: new FormControl(''),
      approvedDate4: new FormControl(''),

      serApproval5: new FormControl(''),
      approvalBy5: new FormControl(''),
      approvedDate5: new FormControl(''),
    })
  }
  
}
