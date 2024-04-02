import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Observable } from 'rxjs';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { CommonService } from 'src/app/modules/_services/common.service';
import { CommunicationService } from 'src/app/modules/_services/communication.service';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { UserParams } from 'src/app/modules/models/UserParams';
import { EmployeeHistoryDetailsDto } from 'src/app/modules/models/EmployeeHistoryDetailsDto';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-details-with-history',
  templateUrl: './employee-details-with-history.component.html',
  styleUrls: ['./employee-details-with-history.component.scss']
})

export class EmployeeDetailsWithHistoryComponent implements OnInit {

  // We will filter form header labels array
  formHeaderLabels: any[] = [];

  formTitle: string;
  lang: any = '';

  // Language Type e.g. 1 = ENGLISH and 2 =  ARABIC
  languageType: any;

  // Selected Language
  language: any;

  // FormId
  formId: string;
  pageSize: number = 10;
  formGroup: FormGroup;

  // We will get form lables from lcale storage and will put into array.
  AppFormLabels: FormTitleHd[] = [];
  
  // We will filter form body labels array
  formBodyLabels: any[] = [];

  tenentId: number = 0;

  employeeHistoryForm: FormGroup;

  universities: any[] = [];
  locations: any;
  contractTypes: any[] = [];
  departments: any[] = [];
  occupations: any[] = [];
  serviceTypes: any[] = [];
  periods: any[] = [];

  formData = {
    universityId: 0,
    contractTypeId: 0,
    departmentIdFrom: 0,
    departmentIdTo: 0,
    positionId: 0,
    serviceTypeId: 0,
    periodFrom: 0,
    periodTo: 0
  };

  // Getting data as abservable.
  employeeHistoryDetailsDto$: Observable<EmployeeHistoryDetailsDto[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  employeeHistoryDetailsDto: MatTableDataSource<EmployeeHistoryDetailsDto> = new MatTableDataSource<any>([]);

  // To display table column headers
  columnsToDisplay: string[] = ['empId', 'contractType', 'department', 'loadAmount', 'installment', 'paid', 'pen'];

  userParams: UserParams;

  // Incase of any error will display error message.
  dataLoadingStatus: string = '';

  // True of any error
  isError: boolean = false;

  // Hide footer while loading.
  isLoadingCompleted: boolean = false;

  masterServiceType$: any[] = [];

  get empHistoryForm() { return this.employeeHistoryForm.controls; }

  constructor(private common: CommonService, 
    private _communicationService: CommunicationService, 
    private toastr: ToastrService,
    private commonDbService: DbCommonService, 
    private fb: FormBuilder) { 
    this.formGroup = new FormGroup({
      locationId: new FormControl(null),
      contactId: new FormControl(null)
    })
    this.userParams = this._communicationService.getUserParams();
  }

  ngOnInit(): void {
    this.tenentId = JSON.parse(
      localStorage.getItem('user') || '{}'
    )[0].tenantId;
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang;      
    })
    this.formTitle = this.common.getFormTitle();
    this.formTitle = '';
    // #region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'EmployeeHistoryDetails';

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {
      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');
      let index = 0;

      for (let labels of this.AppFormLabels) {
        // console.log("labels", labels)
        if (labels.formID == this.formId && labels.language == this.languageType) {
          this.formHeaderLabels.push(labels);
          this.formBodyLabels.push(labels.formTitleDTLanguage);
          console.log(this.formBodyLabels);
        } else {
          index++;
          if(index === 1) {
            this.formHeaderLabels.push({"headerName": "Employee History Details", "formID": "EmployeeHistoryDetails", "subHeaderName": "تفاصيل تاريخ الموظف", "status": "Active"})
            this.formBodyLabels.push("employeeHistoryDetail");
          }
        }
      }   
    }

    this.getUniversities();
    this.getDepartments();
    this.getOccupations();
    this.getServiceTypes();
    this.getLocations();
    this.getContractTypes();
    this.getMasterContracts();
    this.initializeSearchForm();
    this.getPeriods();
  }
  
  loadData(pageIndex: number) {
    // this._communicationService.GetIncomingLetters(pageIndex + 1, this.pageSize, this.formGroup.value.searchTerm).subscribe((response: any) => {
    //   this.incommingCommunicationDto = new MatTableDataSource<IncommingCommunicationDto>(response.body);
    //  console.log(response.body)
    //   this.incommingCommunicationDto.paginator = this.paginator;
    //   this.incommingCommunicationDto.sort = this.sort;
    //   this.isLoadingCompleted = true;
    //   setTimeout(() => {
    //     this.paginator.pageIndex = pageIndex;
    //     this.paginator.length = response.body.totalRecords;
    //   });
    // }, error => {
    //   console.log(error);
    //   this.dataLoadingStatus = 'Error fetching the data';
    //   this.isError = true;
    // })
  }

  filterRecords(pageIndex: any) {
    // if (this.formGroup.value.locationId != null && this.employeeHistoryDetailsDto) {
    //   this.employeeHistoryDetailsDto.filter = this.formGroup.value.locationId.trim();
    // }

    if(this.formData.periodFrom > this.formData.periodTo) {
      this.toastr.error("Please select Period correctly.");
      return;
    }

    this._communicationService.setUserParams(this.userParams);
    this.isLoadingCompleted = true;
    this._communicationService.GetEmployeeHistoryDetails(
      this.userParams, 
      this.tenentId,
      this.formData.universityId, 
      this.formData.contractTypeId, 
      this.formData.departmentIdFrom,
      this.formData.departmentIdTo == 0 ? this.departments[this.departments.length - 1].refid : this.formData.departmentIdTo,
      this.formData.positionId,
      this.formData.serviceTypeId,
      this.formData.periodFrom,
      this.formData.periodTo)
    .subscribe((response: any) => {
      console.log(response, 'getemployee history')
      // this._communicationService.GetEmployeeHistoryDetails(this.userParams, "", val, val1, val2, this.urlServiceData.serviceTypeId, this.urlServiceData.subServiceTypeId).subscribe((response: any) => {
    }, error => {
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }

  getUniversities() {
    this.commonDbService.GetUniversities().subscribe(data => {
      console.log('universities', data);
      this.universities = [
        {
          univId: 0, 
          univName1: 'All Universities', 
          univName2: 'All Universities', 
          univName3: 'All Universities'
        },
        ...data
      ];
    });
  }

  getPeriods() {
    this.commonDbService.GetPeriods().subscribe(data => {
      console.log('Periods', data);
      this.periods = [];
      this.periods.push({
        code: 0,
        shortname: 'All Periods'
      })

      for(let i=0; i<data.length; i++) {
        this.periods.push({
          code: data[i],
          shortname: data[i].toString()
        })
      }
    })    
  }

  getServiceTypes() {
    this.commonDbService.GetServiceType(this.tenentId).subscribe(data => {
      console.log('serviceTypes', data);
      this.serviceTypes = [
        {
          refid: 0,
          shortname: 'All ServiceTypes'
        },
        ...data
      ]
    })
  }

  getDepartments() {
    this.commonDbService.GetDepartments().subscribe(data => {
      console.log('departments', data);
      this.departments = [
        {
          refid: 0,
          shortname: 'All Departments'
        },
        ...data
      ]
    })
  }

  getOccupations() {
    this.commonDbService.GetOccupations().subscribe(data => {
      console.log('occupations', data);
      this.occupations = [
        {
          refid: 0,
          shortname: 'All Occupations'
        },
        ...data
      ]
    })
  }

  getLocations() {
    this.commonDbService.getLocations().subscribe(data => {
      console.log("localutons", data)
      this.locations = data;
    })
  }

  getContractTypes() {
    this.commonDbService.GetContractType().subscribe(data => {
      console.log("contractTypes", data)
      this.contractTypes = [
        {
          refid: 0,
          shortname: 'All ContractTypes'
        },
        ...data
      ]
    })
  }

  getMasterContracts() {
    this.commonDbService.GetMaterServiceTypes().subscribe((result) => {
      this.masterServiceType$ = result;
    }); 
  }

  initializeSearchForm() {
    this.employeeHistoryForm = this.fb.group({
      universityId: new FormControl(''),
      contractTypeId: new FormControl(''),
      departmentIdFrom: new FormControl(''),
      departmentIdTo: new FormControl(''),
      positionId: new FormControl(''),
      serviceTypeId: new FormControl(''),
      periodFrom: new FormControl(''),
      periodTo: new FormControl(''),
    })

    // this.employeeHistoryForm.patchValue({
    //   universityId: 0,
    //   contractTypeId: 0,
    //   departmentIdFrom: 0,
    //   departmentIdTo: 0,
    //   positionId: 0,
    //   serviceId: 0,
    //   periodFrom: 0,
    //   periodTo: 0,
    // })
  }

  pageChanged(event: any) {
    if (event.pageIndex == 0) {
      this.userParams.pageNumber = event.pageIndex + 1
    } else if (event.length <= (event.pageIndex * event.pageSize + event.pageSize)) {
      this.userParams.pageNumber = event.pageIndex + 1;
    }
    else if (event.previousPageIndex > event.pageIndex) {
      this.userParams.pageNumber = event.pageIndex;
    } else {
      this.userParams.pageNumber = event.pageIndex + 1
    }
    this.userParams.pageSize = event.pageSize;
    // this.financialService.setUserParams(this.userParams);
    if (this.formGroup.value.searchTerm == null) {
      // this.loadData(event.pageIndex, 0, 0, 0);
    } else if (this.formGroup.value.searchTerm.length > 0) {
      // this.filterRecords(event.pageIndex);
    } else {
      // this.loadData(event.pageIndex, 0, 0, 0);
    }
  }

  onDepartmentFromChange() {
    if(this.formData.departmentIdFrom == 0) this.formData.departmentIdTo = 0;
  }
  onDepartmentToChange() {
    if(this.formData.departmentIdTo == 0) this.formData.departmentIdFrom = 0;
  }
  onPeriodFromChange() {
    if(this.formData.periodFrom == 0) this.formData.periodTo = 0;
  }
  onPeriodToChange() {
    if(this.formData.periodTo == 0) this.formData.periodFrom = 0;
  }
}
