
import { ChangeDetectorRef, Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { CountriesDto } from 'src/app/modules/models/CountriesDto';
import { DetailedEmployee } from 'src/app/modules/models/DetailedEmployee';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { SelectDepartmentsDto } from 'src/app/modules/models/SelectDepartmentsDto';
import { SelectOccupationsDto } from 'src/app/modules/models/SelectOccupationsDto';
import { SelectTerminationsDto } from 'src/app/modules/models/SelectTerminationsDto';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { EmployeeService } from 'src/app/modules/_services/employee.service';
import { CommonService } from 'src/app/modules/_services/common.service';
import { UserFunctionsService } from 'src/app/modules/_services/user-functions.service';
import { AuthService } from 'src/app/modules/auth';

@Component({
  selector: 'app-addemployeeinformation',
  templateUrl: './addemployeeinformation.component.html',
  styleUrls: ['./addemployeeinformation.component.scss'],

})
export class AddemployeeinformationComponent implements OnInit {
  isLoading$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoading: boolean;
  private unsubscribe: Subscription[] = [];

  //
  parentForm: FormGroup;
  addEmployeeForm: FormGroup;
  //
  jobDetailsForm: FormGroup;
  //
  membershipForm: FormGroup;
  //
  isChildFormSet = false;
  showChildComponent = false;
  //
  //
  isFormSubmitted = false;
  occupations$: Observable<SelectOccupationsDto[]>;
  departments$: Observable<SelectDepartmentsDto[]>;
  terminations$: Observable<SelectTerminationsDto[]>;
  countries$: Observable<CountriesDto[]>;
  //
  contractType$: Observable<SelectOccupationsDto[]>;
  //
  editEmployeeInformation$: Observable<DetailedEmployee[]>;
  employeeId: any;
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

  /*----------------------------------------------------*/
  //#endregion
  datePickerConfig: Partial<BsDatepickerConfig> | undefined;
  selectedStatus: number | undefined;
  maritalStatusArray: any = [
    { id: 1, name: 'Married' },
    { id: 2, name: 'Single' }
  ];
  selectedGender: number | undefined;
  genderArray: any = [
    { id: 1, name: 'Male' },
    { id: 2, name: 'Female' }
  ];
  // 
  @ViewChild('popupModal', { static: true }) popupModal: ElementRef;
  //
  popUpForm: FormGroup;
  closeResult: string = '';
  isOK: boolean = false;
  lang: string;

  locations: any;
  tenantId: any;
  isManager: any = false;
  
  constructor(
    private cdr: ChangeDetectorRef,
    private employeeService: EmployeeService,
    private toastrService: ToastrService,
    private commonDbService: DbCommonService,
    public common: CommonService,
    private fb: FormBuilder,
    private activatedRout: ActivatedRoute,
    private router: Router,
    private modalService: NgbModal,
    private renderer: Renderer2,
    private userFunctionService: UserFunctionsService,
    private auth: AuthService) {

    this.datePickerConfig = Object.assign({}, { containerClass: 'theme-dark-blue' })
    const loadingSubscr = this.isLoading$
      .asObservable()
      .subscribe((res) => (this.isLoading = res));
    this.unsubscribe.push(loadingSubscr);
    this.setUpParentForm();
    //
    this.employeeId = this.activatedRout.snapshot.paramMap.get('employeeId');

    this.countries$ = this.commonDbService.GetCountryList();
  }

  selectedOccupation: number | undefined;
  ngOnInit(): void {
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    this.initializeForm();
    //
    this.initializeJobDetailsForm();
    //
    this.initializeMembershipForm();
    //
    this.initPopUpModal();
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'AddEmployee';

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
          if (labels.language == 1) {
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

    //#region Filling All dropDown from db    
    // To FillUp Occupations
    this.occupations$ = this.commonDbService.GetOccupations();
    // To FillUp Departments
    this.departments$ = this.commonDbService.GetDepartments();
    // To FillUp terminations
    this.terminations$ = this.commonDbService.GetTerminations();
    // To FillUp Contract Types
    this.contractType$ = this.commonDbService.GetContractType();
    this.getLocations();
    //#endregion
    // Get and fill data in Edit Mode...
    if (this.employeeId != null) {
      this.jobDetailsForm.controls.empCidNum.disable()
      this.jobDetailsForm.controls.salary.disable()
      this.isOK = true;
      this.userFunctionService.GetFunctionUserByUserIdAsync(this.auth.getUserId()).subscribe(data => {
        if (data && data.length > 0) {
          let role = data.find(d => d.menU_ID == 12 && d.sP1 == 1 && d.useR_ID == this.auth.getUserId());
          //let role = data.find(d => d.sP1 == 1);
          this.isManager = role ? true : false
          if (this.isManager) {
            this.jobDetailsForm.controls.empCidNum.enable()
            this.jobDetailsForm.controls.salary.enable()
          }
        }
      })
      this.editEmployeeInformation$ = this.employeeService.GetEmployeeById(this.employeeId);
      this.editEmployeeInformation$.subscribe((response: any) => {
        console.log(response);
        this.parentForm.patchValue({
          addEmployeeForm: {
            employeeId: response.employeeId,
            englishName: response.englishName,
            arabicName: response.arabicName,
            empBirthday: response.empBirthday ? new Date(response.empBirthday) : '',
            empGender: response.empGender,
            empMaritalStatus: +response.empMaritalStatus,
            mobileNumber: response.mobileNumber,
            empWorkTelephone: response.empWorkTelephone,
            empWorkEmail: response.empWorkEmail,
            next2KinName: response.next2KinName,
            next2KinMobNumber: response.next2KinMobNumber,
            isKUEmployee: response.isKUEmployee,
            isMemberOfFund: response.isMemberOfFund,
            terminationBanned: response.terminationBanned,
            isOnSickLeave: response.isOnSickLeave,
            nationCode: response.nationCode,
            joinedDate: response.joinedDate ? new Date(response.joinedDate) : '',
            locationId: response.locationId ? response.locationId : 1,
            holdQty: response.holdQty,
            holdRemarks: response.holdRemarks,
            unHoldDate: response.unHoldDate,
            unHoldBy: response.unHoldBy
          },
          jobDetailsForm: {
            department: response.department,
            departmentName: +response.departmentName,
            salary: response.salary,
            empCidNum: response.empCidNum,
            empPaciNum: response.empPaciNum,
            empOtherId: response.empOtherId,
            contractType: +response.contractType
          },
          membershipForm: {
            membership: response.membership,
            membershipJoiningDate: response.membershipJoiningDate ? new Date(response.membershipJoiningDate) : '',
            termination: +response.termination,
            terminationDate: response.terminationDate ? new Date(response.terminationDate) : '',
          },
          financialForm: {
            loanAct: response.loanAct,
            hajjAct: response.hajjAct,
            persLoanAct: response.persLoanAct,
            consumerLoanAct: response.consumerLoanAct,
            otherAct1: response.otherAct1,
            otherAct2: response.otherAct2,
            otherAct3: response.otherAct3,
            otherAct4: response.otherAct4,
            otherAct5: response.otherAct5,
          },
          finanacialFormGroup: {
            subOPAmount: response.subOPAmount,
            subOPNotPaidAmount: response.subOPNotPaidAmount,
            loanOPAmount: response.loanOPAmount,
            loanOPNotPaidAmount: response.loanOPNotPaidAmount
          }
        })
      })
    }
    else {
      this.addEmployeeForm.controls.terminationBanned.disable()
    }

    this.membershipForm.get('termination')?.disable();
    var data = JSON.parse(localStorage.getItem("user")!);
    this.tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId)[0];

  }

  getLocations() {
    this.commonDbService.getLocations().subscribe(data => {
      this.locations = data;
    })
  }

  initializeForm() {
    this.addEmployeeForm = this.fb.group({
      employeeId: new FormControl('', [Validators.required, Validators.min(11)]),
      englishName: new FormControl('', Validators.required),
      arabicName: new FormControl('', Validators.required),
      empBirthday: new FormControl('', Validators.required),
      empGender: new FormControl('', Validators.required),
      empMaritalStatus: new FormControl('', Validators.required),
      mobileNumber: new FormControl('', Validators.required),
      empWorkTelephone: new FormControl(''),
      empWorkEmail: new FormControl('', Validators.required),
      next2KinName: new FormControl(''),
      next2KinMobNumber: new FormControl(''),
      isKUEmployee: new FormControl('true'),
      isOnSickLeave: new FormControl(''),
      isMemberOfFund: new FormControl(''),
      terminationBanned: new FormControl(false),
      nationCode: new FormControl('', Validators.required),
      nationName: new FormControl(''),
      joinedDate: new FormControl('', Validators.required),
      locationId: ['', Validators.required],
      holdQty: [null],
      holdRemarks: [null],
      unHoldDate: [],
      unHoldBy: []
    })
    this.parentForm.setControl('addEmployeeForm', this.addEmployeeForm);
  }
  initializeJobDetailsForm() {
    this.jobDetailsForm = this.fb.group({
      department: new FormControl('', Validators.required),
      departmentName: new FormControl('', Validators.required),
      salary: new FormControl('', [Validators.required, Validators.min(11)]),
      empCidNum: new FormControl('', [Validators.required, Validators.minLength(12), Validators.maxLength(12)]),
      empPaciNum: new FormControl(''),
      empOtherId: new FormControl(''),
      contractType: new FormControl('', Validators.required)
    })
    this.parentForm.setControl('jobDetailsForm', this.jobDetailsForm);
  }
  initializeMembershipForm() {
    this.membershipForm = this.fb.group({
      membership: new FormControl('', Validators.required),
      membershipJoiningDate: new FormControl('', Validators.required),
      termination: new FormControl('', Validators.required),
      terminationDate: new FormControl('', Validators.required),
    })
    this.parentForm.setControl('membershipForm', this.membershipForm);
  }
  initPopUpModal() {
    this.popUpForm = this.fb.group({
      errorMessage: new FormControl(null)
    })
  }
  setUpParentForm() {
    this.parentForm = this.fb.group({});
  }
  //get gender(){return this.addEmployeeForm.get('gender')}


  //Save employee data...
  submitForm() {
    console.log(this.parentForm)
    this.isFormSubmitted = true;
    if (this.addEmployeeForm.invalid || this.jobDetailsForm.invalid) {
      console.log((this.empForm.employeeId.touched || this.isFormSubmitted) && this.empForm.employeeId.errors?.required && this.empForm.employeeId.errors?.minlength)
      this.toastrService.warning('Kindly enter all the mandatory fields', 'Warning');
    } else {
      var data = JSON.parse(localStorage.getItem("user")!);
      //const locationId = data.map((obj: { locationId: any; }) => obj.locationId);
      const username = data.map((obj: { username: any; }) => obj.username);
      const userId = data.map((obj: { userId: any; }) => obj.userId);

      let empId = this.addEmployeeForm.get('employeeId')?.value
      this.parentForm.controls.addEmployeeForm.patchValue({
        empGender: +this.parentForm.value.addEmployeeForm.empGender,
        empMaritalStatus: +this.parentForm.value.addEmployeeForm.empMaritalStatus,
        employeeId: +empId,
      });
      //  TO CONVER OBJECT ARRAY AS SIMPLE ARRAY.
      let formData = {
        ...this.parentForm.value.addEmployeeForm,
        ...this.parentForm.value.jobDetailsForm,
        ...this.parentForm.value.membershipForm,
        ...this.parentForm.value.financialForm,
        ...this.parentForm.value.finanacialFormGroup,
        tenentID: this.tenantId,
        // locationId: locationId[0],
        username: username[0],
        userId: userId[0]
      }
      //

      //
      if (this.addEmployeeForm.valid) {
        if (this.employeeId != null) {
          this.employeeService.UpdateEmployee(formData).subscribe((res: any) => {
            console.log(res);
            this.toastrService.success('Saved successfully', 'Success');
            this.addEmployeeForm.reset();
            this.jobDetailsForm.reset();
            this.membershipForm.reset();
            this.parentForm.reset();
            this.router.navigateByUrl('/employee/view-employee')
          }, error => {
            if (error.status === 500) {
              this.toastrService.error('Something went wrong', 'Error');
            }
          })
        }
        else {
          this.employeeService.ValidateEmployeeData(formData).subscribe((response: any) => {
            if (response == "1") {
              this.toastrService.error('Duplicate Civil Id, please enter a different Civil Id', 'Error');
            }
            else if (response == "2") {
              this.popUpForm.patchValue({
                errorMessage: '?Duplicate mobile number found, do you want to proceed'
              })
              this.openPopUpModal(this.popupModal, formData);
            }
            else if (response == "3") {
              this.popUpForm.patchValue({
                errorMessage: '?Duplicate email found, do you want to proceed'
              })
              this.openPopUpModal(this.popupModal, formData);
            }
            else if (response == "4") {
              this.toastrService.error('Duplicate Employee Id, please enter a different Employee Id', 'Error');
            }
            else if (response == "0") {
              this.employeeService.AddEmployee(formData).subscribe((res: any) => {
                console.log(res)
                this.toastrService.success('Saved successfully', 'Success');
                this.addEmployeeForm.reset();
                this.jobDetailsForm.reset();
                this.membershipForm.reset();
                this.parentForm.reset();
                this.addEmployeeForm.controls['employeeId'].setValue(0);
                this.router.navigateByUrl('/employee/view-employee')
              })
            }
          });
        }
      }
    }
  }
  //
  get empForm() { return this.addEmployeeForm.controls; }
  get jobForm() { return this.jobDetailsForm.controls; }
  //

  employeeIdChanged(e: any) {
    let tenantId = this.tenantId;
    let locationId = this.addEmployeeForm.controls.locationId.value;
    if (!locationId) {
      this.toastrService.error('Please select the Unversity', 'Error');
      return;
    }
    let employeeId = this.addEmployeeForm.controls.employeeId.value;
    this.employeeService.validateEmployeeId(tenantId, locationId, employeeId).subscribe((response: any) => {
      if (response != null && response != undefined) {


        if (!response) {
          this.toastrService.error('Duplicate Employee Id, please enter a different Employee Id', 'Error');
          this.addEmployeeForm.controls.employeeId.setErrors({ duplicate: true }); // Control is invalid
        }
      }
    })
  }
  addChildComponent(): void {
    this.showChildComponent = true;
  }
  onCountryChange(event: any) {
    console.log(event);
    this.addEmployeeForm.controls['nationName'].setValue(event.counamE1);
  }
  onChange(form: FormGroup<any>) {
    // reset the form value to the newly emitted form group value.
    this.addEmployeeForm = form;
  }
  saveSettings() {
    this.isLoading$.next(true);
    setTimeout(() => {
      this.isLoading$.next(false);
      this.cdr.detectChanges();
    }, 1500);
  }

  ngOnDestroy() {
    this.unsubscribe.forEach((sb) => sb.unsubscribe());
  }
  //#region Delete operation and Modal Config
  openPopUpModal(content: any, formData: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'yes') {
        this.employeeService.AddEmployee(formData).subscribe((response: any) => {
          this.toastrService.success('Saved successfully', 'Success');
          this.parentForm.reset();
        })
      }
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

}

export function customValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    // Perform your custom validation logic here
    if (control.value !== 'valid') {
      // The control is invalid; return an error object
      return { duplicate: true };
    }

    // The control is valid; return null
    return null;
  };
}
