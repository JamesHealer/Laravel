import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { FormTitleDt } from 'src/app/modules/models/formTitleDt';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import { CommonService } from 'src/app/modules/_services/common.service';
import { OffersService } from 'src/app/modules/_services/offers.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-offer-received-maintenace',
  templateUrl: './offer-received-maintenace.component.html',
  styleUrls: ['./offer-received-maintenace.component.scss']
})
export class OfferReceivedMaintenaceComponent implements OnInit {
// /*********************/
// formHeaderLabels$ :Observable<FormTitleHd[]>; 
// formBodyLabels$ :Observable<FormTitleDt[]>; 
// formBodyLabels :FormTitleDt[]=[]; 
// id:string = '';
// languageId:any;
// // FormId to get form/App language
// @ViewChild('OfferDetails') hidden:ElementRef;
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

    columnsToDisplay: string[] = ['action','name', 'employeeId', 'offersRecievedDate', 'civilId', 'mobileNo'];
    //
  
    // We need a normal array of data so we will subscribe to the observable and will get data
    offersWebsite: MatTableDataSource<any> = new MatTableDataSource<any>([]);
  
    // Paginator
    @ViewChild(MatPaginator) paginator!: MatPaginator;
  
    // Sorting
    @ViewChild(MatSort) sort!: MatSort;

    /*----------------------------------------------------*/  
  //#endregion

  constructor(
    private commonService:CommonService,
    private _offerService:OffersService,
    private financialService: FinancialService,
    private router: Router
    ) { }
lang:string;
tenantId:number;
locationId:number;
  ngOnInit(): void {
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang;
    })
    var data = JSON.parse(localStorage.getItem("user")!);
    this.tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    this.locationId = data.map((obj: { locationId: any; }) => obj.locationId);
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'specialOfferReceivedHandling';

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
          this.formBodyLabels.push(jsonFormTitleDTLanguage);

        }
      }
      console.log(this.formBodyLabels)
    }
    //#endregion
    this.getOffersByWebsite();
  }

  pageNumber=1;
  pageSize= 10;


  getOffersByWebsite(){
    this._offerService.GetRecievedOffersByWebsite(this.pageNumber, this.pageSize, this.tenantId, this.locationId).subscribe((res:any)=>{
      console.log(res);
      this.offersWebsite = res.offersRecievedList;
    })
  }

  sbscriptionRedirect(e:any){
    this.financialService.subScriptionId = e.employeeId;
    const urlServiceData = {
      serviceTypeName: e.serviceTypeName,
      subServiceTypeName: e.serviceSubTypeName,
      serviceTypeId: e.serviceTypeId,
      subServiceTypeId: e.serviceSubTypeId,      
    }
    this.router.navigate(['/service-setup/add-service', { serviceInformation: JSON.stringify(urlServiceData) }])

  }

  onPaginationChange(e:any){

  }
  
}
