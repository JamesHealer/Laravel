import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { Observable } from 'rxjs';
import { DetailedEmployee } from 'src/app/modules/models/DetailedEmployee';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { SelectDepartmentsDto } from 'src/app/modules/models/SelectDepartmentsDto';
import { SelectOccupationsDto } from 'src/app/modules/models/SelectOccupationsDto';
import { SelectTerminationsDto } from 'src/app/modules/models/SelectTerminationsDto';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { EmployeeService } from 'src/app/modules/_services/employee.service';

@Component({
  selector: 'app-editemployeeinformation',
  templateUrl: './editemployeeinformation.component.html',
  styleUrls: ['./editemployeeinformation.component.scss']
})
export class EditemployeeinformationComponent implements OnInit {
  occupations$: Observable<SelectOccupationsDto[]>;
  departments$: Observable<SelectDepartmentsDto[]>;
  terminations$: Observable<SelectTerminationsDto[]>;
  employeeData$:Observable<DetailedEmployee[]>;
  //
  employeeData:DetailedEmployee[]=[];
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
  datePickerConfig: Partial<BsDatepickerConfig> | undefined;
  addEmployeeForm:FormGroup;
  isChildFormSet = false;
  showChildComponent = false;
  //
  employeeId:any;
  
  selectedStatus: number | undefined;
  maritalStatusArray = [
      { id: 1, name: 'Married' },
      { id: 2, name: 'Single' }
  ];
  selectedGender: number | undefined;
  genderArray = [
      { id: 1, name: 'Male' },
      { id: 2, name: 'Female' }
  ];
  
  constructor(
    private fb: FormBuilder,
    private commonDbService: DbCommonService,
    private activatedRout: ActivatedRoute,
    private employeeService: EmployeeService) { 
    this.datePickerConfig = Object.assign({},{containerClass:'theme-dark-blue'})
    this.employeeId = this.activatedRout.snapshot.paramMap.get('id');
    
  }
  
  ngOnInit(): void {
    this.initializeForm();
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

        if (labels.formID == this.formId && labels.language == this.languageType) {

          this.formHeaderLabels.push(labels);

          this.formBodyLabels.push(labels.formTitleDTLanguage);

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
    //#endregion
   this.employeeData$ =  this.employeeService.GetEmployeeById(this.employeeId);
   this.employeeData$.subscribe((response)=>{
    this.employeeData = response;
   },error=>{
    console.log(error);
   })
  }
 initializeForm(){
    this.addEmployeeForm = this.fb.group({
      englishName: new FormControl('',Validators.required),
      arabicName: new FormControl('',Validators.required),
      empBirthday: new FormControl('',Validators.required),
      empGender: new FormControl('',Validators.required),
      empMaritalStatus: new FormControl('',Validators.required),
      mobileNumber: new FormControl('',Validators.required),
      empWorkTelephone: new FormControl('',Validators.required),
      empWorkEmail: new FormControl('',Validators.required),
      next2KinName: new FormControl('',Validators.required),
      next2KinMobNumber: new FormControl('',Validators.required),
      department: new FormControl('',Validators.required),
      departmentName: new FormControl('',Validators.required),
      salary: new FormControl('',Validators.required),      
      empCidNum: new FormControl('',Validators.required),
      empPaciNum: new FormControl('',Validators.required),
      empOtherId: new FormControl('',Validators.required),
      membership: new FormControl('',Validators.required),
      membershipJoiningDate: new FormControl('',Validators.required),
      termination: new FormControl('',Validators.required),
      terminationDate: new FormControl('',Validators.required),
      loanAct: new FormControl('',Validators.required),
                       
    })    
  }

  

  onChange(form: FormGroup<any>) {
    // reset the form value to the newly emitted form group value.
    this.addEmployeeForm = form;
  }
}
