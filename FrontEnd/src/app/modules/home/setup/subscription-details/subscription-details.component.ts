import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { ReturnServiceApprovals } from 'src/app/modules/models/ReturnServiceApprovals';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { CommonService } from 'src/app/modules/_services/common.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-subscription-details',
  templateUrl: './subscription-details.component.html',
  styleUrls: ['./subscription-details.component.scss']
})
export class SubscriptionDetailsComponent implements OnInit {


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

  //#region
  // To display table column headers
  columnsToDisplay: string[] = ['action', 'employeeId', 'employeeName', 'civilId', 'mobile', 'subscriptionAppliedDate', 'status'];

  // Getting data as abservable.
  returnServiceApprovals$: Observable<any[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  returnServiceApprovals: MatTableDataSource<any> = new MatTableDataSource<any>([]);

  // Paginator
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  // Sorting
  @ViewChild(MatSort) sort!: MatSort;

  // Hide footer while loading.
  isLoadingCompleted: boolean = false;

  // Incase of any error will display error message.
  dataLoadingStatus: string = '';

  // True of any error
  isError: boolean = false;

  // formGroup
  formGroup: FormGroup;

  // Search Term
  searchTerm: string = '';
  //#endregion

  pageNumber:number = 1
  pageSize:number = 10;
  searchQuery:string = ''
  tenantId:number;
  locationId:number;

  formTitle: string;
  selectedOpt: string = '';
  lang: any = '';
  // Modal close result...
  closeResult = '';
  constructor(private router: Router,
    private commonService: CommonService,
    private toastrService: ToastrService,
    private financialService: FinancialService) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl('')
    })
    var localData = JSON.parse(localStorage.getItem('user') || '{}')[0];
    console.log(localData)
    this.tenantId = localData.tenantId;
    this.locationId = localData.locationId
  }

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
    this.formId = 'SubscriptionDetails';

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {

      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {

        if (labels.formID == this.formId && labels.language == this.languageType) {

          const jsonFormTitleDTLanguage = labels.formTitleDTLanguage.reduce((result: any, element) => {
            result[element.labelId] = element;
            return result;
          }, {})
          this.formBodyLabels.push(jsonFormTitleDTLanguage);
          this.formHeaderLabels.push(labels);

        }
      }
      console.log(this.formHeaderLabels);
      console.log(this.formBodyLabels);
    }
    //#endregion
    this.getSubscriptionGrid(this.pageNumber, this.pageSize, this.searchQuery);
  }

  getSubscriptionGrid(pageNumber:number, pageSize:number, searchQuery:string){
    this.financialService.GetNewSubscription(pageNumber, pageSize, searchQuery, this.tenantId,this.locationId ).subscribe((res:any)=>{
      if(res){
        this.returnServiceApprovals = new MatTableDataSource<any>(res.newSubscriberList);
        this.returnServiceApprovals.paginator = this.paginator;
        this.returnServiceApprovals.sort = this.sort;
        this.isLoadingCompleted = true;
      }     
      else{
        this.toastrService.warning('No data found', 'Warning');
        this.returnServiceApprovals = new MatTableDataSource<any>;
      }
    })
  }

  sbscriptionRedirect(val:number){
    this.financialService.subScriptionId = val;
    const urlServiceData = {
      serviceTypeName: "MEMBERSHIP  MANAGEMENT SERVICES - خدمات إدارة العضوية",
      subServiceTypeName: "Membership Subscribe - عضــــــــــــــو جديد",
      serviceTypeId: 1,
      subServiceTypeId: 1,      
    }
    this.router.navigate(['/service-setup/add-service', { serviceInformation: JSON.stringify(urlServiceData) }])

  }
  pageChanged(e:any){
    this.getSubscriptionGrid(e.pageIndex+1, e.pageSize, this.searchQuery)
  }
  filterRecords(){
    this.getSubscriptionGrid(this.pageNumber, this.pageSize, this.formGroup.value.searchTerm)
  }
  clearFilter(){
    this.getSubscriptionGrid(this.pageNumber, this.pageSize, this.searchQuery);
  }
  reloadPage() {
    let currentUrl = this.router.url;
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate([currentUrl]);
  }
}
