import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { FormTitleDt } from 'src/app/modules/models/formTitleDt';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import { CommonService } from 'src/app/modules/_services/common.service';
import {HttpResponse} from "@angular/common/http";
import {CommunicationService} from "../../../_services/communication.service";
import {FormBuilder, FormControl, FormGroup} from "@angular/forms";
import {UserParams} from "../../../models/UserParams";
import {MatTableDataSource} from "@angular/material/table";
import {DbCommonService} from "../../../_services/db-common.service";
import {ToastrService} from "ngx-toastr";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-employee-certificate-details',
  templateUrl: './employee-certificate-details.component.html',
  styleUrls: ['./employee-certificate-details.component.scss']
})


export class EmployeeCertificateDetailsComponent implements OnInit {

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

  reportForm: FormGroup;

  universities: any[] = [];
  locations: any;
  contractTypes: any[] = [];
  departments: any[] = [];
  occupations: any[] = [];
  serviceTypes: any[] = [];
  periods: any[] = [];

  formData = {
    universityId: 0,
    //employeeName: 0,
    contractTypeId: 0,
    departmentIdFrom: 0,
    departmentIdTo: 0,
    positionId: 0,
    serviceTypeId: 0,
    periodFrom: 0,
    periodTo: 0
  };

  totalData: any[] = [];
  tableData: MatTableDataSource<any> = new MatTableDataSource<any>([]);

  // To display table column headers
  columnsToDisplay: string[] = ['date', 'empId', 'desc', 'debit', 'credit', 'balance'];

  userParams: UserParams;

  // Incase of any error will display error message.
  dataLoadingStatus: string = '';

  // True of any error
  isError: boolean = false;

  // Hide footer while loading.
  isLoadingCompleted: boolean = false;

  masterServiceType$: any[] = [];

  get empHistoryForm() { return this.reportForm.controls; }

  constructor(private common: CommonService,
              private activatedRout: ActivatedRoute,
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
            this.formHeaderLabels.push({"headerName": "Employee Certificate", "formID": "EmployeeCertificate", "subHeaderName": "شهادة الموظف", "status": "Active"})
            this.formBodyLabels.push("report");
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


  generateEmployeeCertificate(){
    const filename = `Certificate_${new Date().toLocaleDateString('en-US', { day: '2-digit', month: '2-digit', year: 'numeric' })}.pdf`;

    this._communicationService.generateEmployeeCertificate(
      this.userParams,
      21,
      1,
      0,
      1,
      99999,
      0,
      0,
      202301,
      202311).subscribe((response: HttpResponse<Blob>)  => {
      if (response.body) {
        const blob = new Blob([response.body], { type: 'application/pdf' });
        const url = window.URL.createObjectURL(blob);


        window.open(url, '_blank');

        window.URL.revokeObjectURL(url);
      }})
  }
  filterRecords(pageIndex: any) {
    if(this.formData.periodFrom > this.formData.periodTo) {
      this.toastr.error("Please select Period correctly.");
      return;
    }

    this.isLoadingCompleted = true;
    this._communicationService.GetEmployeeHistoryDetails(
      this.userParams,
      this.tenentId,
      1,
      0,
      this.formData.departmentIdFrom,
      this.formData.departmentIdTo == 0 ? this.departments[this.departments.length - 1].refid : this.formData.departmentIdTo,
      0,
      0,
      202301,
      202311)
      .subscribe((response: any) => {
        console.log(response, 'getemployee history')
        this.tableData = new MatTableDataSource<any>(response.body.empDetailsWithHistoryList.map((r: any) => {
          return {
            date: '10/08/2023',
            empId: r.dEemployeeID,
            desc: 'Description',
            debit: 50,
            credit: 100,
            balance: 80
          }
        }));
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
      ];
      this.departments.sort((a,b) => a.refid - b.refid);
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
    this.reportForm = this.fb.group({
      universityId: new FormControl(''),
      contractTypeId: new FormControl(''),
      departmentIdFrom: new FormControl(''),
      departmentIdTo: new FormControl(''),
      positionId: new FormControl(''),
      serviceTypeId: new FormControl(''),
      periodFrom: new FormControl(''),
      periodTo: new FormControl(''),
    })

    // this.reportForm.patchValue({
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
