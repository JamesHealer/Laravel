import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DetailedEmployee } from 'src/app/modules/models/DetailedEmployee';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { CommonService } from 'src/app/modules/_services/common.service';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';

@Component({
  selector: 'app-search-tab',
  templateUrl: './search-tab.component.html',
  styleUrls: ['./search-tab.component.scss']
})
export class SearchTabComponent implements OnInit {
  @Input() parentFormGroup: FormGroup;
  employeeForm: FormGroup | undefined;

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

  //
  @Input() arabicFont: string = 'font-family: Cairo;';
  @Input() pageName: string;

  /*----------------------------------------------------*/
  //#endregion

  formTitle: string;
  closeResult: string = '';
  searchForm: FormGroup;
  genderArray: any = [
    { id: 1, name: 'Male' },
    { id: 2, name: 'Female' }
  ];

  constructor(private commonDbService: DbCommonService,
    private commonService: CommonService,
    private toastr: ToastrService) {
 
  }
  lang:string;
  ngOnInit(): void {
    //#region TO SETUP THE FORM LOCALIZATION    
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang;
    })
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'SearchForm';

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {

      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {

        if (labels.formID == this.formId && labels.language == this.languageType) {

          this.formHeaderLabels.push(labels);

          this.formBodyLabels.push(labels.formTitleDTLanguage);

        }
      }
      console.log(this.formBodyLabels);
    }
    //#endregion
    //
    this.initializeSearchForm();
    //
    this.initializeEmployeeForm();
    if (this.parentFormGroup) {
      this.parentFormGroup.setControl('employeeForm', this.employeeForm);
    }


  }

  initializeSearchForm() {
    this.searchForm = new FormGroup({
      employeeId: new FormControl('', Validators.required),
      pfId: new FormControl('', Validators.required),
      cId: new FormControl('', Validators.required),
    })
  }
  initializeEmployeeForm() {
    this.employeeForm = new FormGroup({
      employeeId: new FormControl(''),
      englishName: new FormControl('', Validators.required),
      arabicName: new FormControl('', Validators.required),
      empBirthday: new FormControl('', Validators.required),
      membershipJoiningDate: new FormControl('', Validators.required),
      membership: new FormControl('', Validators.required),
      empGender: new FormControl('', Validators.required),
      empMaritalStatus: new FormControl('', Validators.required),
      mobileNumber: new FormControl('', Validators.required),
      empWorkTelephone: new FormControl('', Validators.required),
      contractType: new FormControl('', Validators.required),
      nationName: new FormControl('', Validators.required),
      departmentName: new FormControl('', Validators.required),
      occupation: new FormControl('', Validators.required),
      salary: new FormControl('', Validators.required),
      remarks: new FormControl('', Validators.required),
      joinedDate: new FormControl('', Validators.required),
      isKUEmployee: new FormControl(''),
      isOnSickLeave: new FormControl(''),
      isMemberOfFund: new FormControl(''),
      terminationId:new FormControl('')
    })
  }
  SearchEmployee() {
    this.commonDbService.SearchEmployee(this.searchForm.value).subscribe((response: any) => {
      console.log(response);
      if (response === null) {
        this.commonService.ifEmployeeExists = false;
        this.toastr.error('Sorry, record not found', 'Error');
        this.employeeForm?.reset();
      } else {
        this.commonService.ifEmployeeExists = true;
        this.employeeForm?.patchValue({
          employeeId: response.employeeId,
          englishName: response.englishName,
          arabicName: response.arabicName,
          empBirthday: new Date(response.empBirthday),
          empGender: response.empGender,
          membershipJoiningDate: response.membershipJoiningDate ? new Date(response.membershipJoiningDate) : '',
          membership: response.membership,
          empMaritalStatus: response.empMaritalStatus,
          mobileNumber: response.mobileNumber,
          empWorkTelephone: response.empWorkTelephone,
          contractType: response.contractType,
          nationName: response.nationName,
          departmentName: response.departmentName,
          occupation: response.departmentName,
          salary: response.salary,
          remarks: response.remarks,
          isKUEmployee: response.isKUEmployee,
          isOnSickLeave: response.isOnSickLeave,
          isMemberOfFund: response.isMemberOfFund,
          terminationId:response.terminationId

        })
        this.commonService.PFId = response.pfid;
        this.commonService.subscribedDate = response.subscribedDate;
        this.commonService.terminationDate = response.terminationDate;
        this.commonService.empSearchClickEvent.next(response.pfid);
      }
    }, error => {
      if (error.status === 500) {
        this.toastr.error('Please enter Employee Id or CID or PFId', 'Error');
      }
    });
  }

}
