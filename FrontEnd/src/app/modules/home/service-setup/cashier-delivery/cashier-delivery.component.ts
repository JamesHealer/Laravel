import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { SelectBankAccount } from 'src/app/modules/models/SelectBankAccount';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { CommonService } from 'src/app/modules/_services/common.service';

@Component({
  selector: 'app-cashier-delivery',
  templateUrl: './cashier-delivery.component.html',
  styleUrls: ['./cashier-delivery.component.scss']
})
export class CashierDeliveryComponent implements OnInit {

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

  lang: any;

  cashierDeliveryForm: FormGroup;
  transId: number;
  employeeId: number;
  accountName: string;
  //
  selectBankAccount$: Observable<SelectBankAccount[]>;
  //
  idDisabled = false;
  isFormSubmitted = false;
  constructor(private fb: FormBuilder,
    private dbCommonService: DbCommonService,
    private activatedRoute: ActivatedRoute,
    private financialService: FinancialService,
    private commonService: CommonService,
    private toastrService: ToastrService,
    private router: Router
  ) {
    this.activatedRoute.queryParams.subscribe(params => {
      this.transId = params['mytransId'];
      this.employeeId = params['employeeId'];
    });
  }
  deliveryInformation: any;
  ngOnInit(): void {

    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang
    })

    //#region TO SETUP THE FORM LOCALIZATION
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'CashierDelivery';
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
          console.log(this.formHeaderLabels)
          console.log(this.formBodyLabels);
        }
      }
      console.log(this.formBodyLabels);
    }
    // Get Tenant Id
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { locationId: any; }) => obj.locationId);
    const username = data.map((obj: { username: any; }) => obj.username);
    //
    this.initializeCashierDeliveryForm();
    //
    this.selectBankAccount$ = this.dbCommonService.GetBankAccounts(tenantId, locationId);
    //
    this.dbCommonService.GetDraftInformationByEmployeeId(this.employeeId, tenantId, locationId, this.transId).subscribe((response: any) => {
      this.deliveryInformation = response;
      this.cashierDeliveryForm.patchValue({
        totalAmount: response.totalAmount.toFixed(3),
        bankAccount1: +response.bankAccount1,
        draftNumber1: response.draftNumber1,
        draftDate1: response.draftDate1 ? new Date(response.draftDate1) : new Date(),
        receivedBy1: response.receivedBy1,
        receivedDate1: response.receivedDate1 ? new Date(response.receivedDate1) : new Date(),
        deliveredBy1: username[0],
        deliveryDate1: response.deliveryDate1 ? new Date(response.deliveryDate1) : new Date(),
        pfid: response.pfid,
        empCidNum: response.empCidNum,
        arabicName: response.arabicName,
        englishName: response.englishName,
        transId: this.transId,
        employeeId: this.employeeId,
        collectedBy: response.collectedBy,
        relationship: response.relationship,
        collectedPersonCID: response.collectedPersonCID,
        chequeNumber: response.chequeNumber,
      })
      if (this.cashierDeliveryForm.controls['receivedBy1'].value) {
        this.idDisabled = true;
        this.cashierDeliveryForm.disable();
      }
    }, error => {
      console.log(error);
    })
    this.onSearchChange();
  }

  onSaveClick() {
    this.isFormSubmitted = true;
    if (this.cashierDeliveryForm.controls['receivedBy1'].valid) {
      if (this.cashierDeliveryForm.valid) {
        this.financialService.CreateCahierDelivery(this.cashierDeliveryForm.value).subscribe((response: any) => {
          if (response === 1) {
            this.idDisabled = true;
            this.toastrService.success('Saved successfully', 'Success');
          } else {
            this.toastrService.error('Something went wrong', 'Error');
          }
        }, error => {
          console.log(error)
        })
      }
    }
  }

  initializeCashierDeliveryForm() {
    this.cashierDeliveryForm = this.fb.group({
      totalAmount: new FormControl('0'),
      bankAccount1: new FormControl('', Validators.required),
      draftNumber1: new FormControl('0'),
      draftDate1: new FormControl(null),
      receivedBy1: new FormControl('', Validators.required),
      receivedDate1: new FormControl(null),
      deliveredBy1: new FormControl(),
      pfid: new FormControl(),
      empCidNum: new FormControl(),
      employeeId: new FormControl(),
      arabicName: new FormControl(),
      englishName: new FormControl(),
      deliveryDate1: new FormControl(null),
      transId: new FormControl(''),
      collectedBy: new FormControl(''),
      relationship: new FormControl(''),
      collectedPersonCID: new FormControl(''),
      chequeNumber: new FormControl('')
    })
  }

  redirectTo(uri: string) {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate([uri]));
  }
  // To access form controls...
  get cashierDeliveryFrm() { return this.cashierDeliveryForm.controls; }

  onSearchChange() {
    this.selectBankAccount$.subscribe((res: any) => {
      res.filter((item: any) => {
        if (item.accountNumber == this.cashierDeliveryForm.controls['bankAccount1'].value) {
          this.accountName = item.accountName
        }
      })
    })
  }
  onPrintClick() {
    var divToPrint = document.getElementById('print-index-invoice');
    var newWin = window.open('', 'Print-Window');
    newWin?.document.open();
    newWin?.document.write('<html><link rel="stylesheet" type="text/css" media="print"/><body onload="window.print()">' + divToPrint?.innerHTML + '</body></html>');
    newWin?.document.close();
    setTimeout(function () {
      newWin?.close();
    }, 5);
  }
}
