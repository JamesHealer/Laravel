import { DatePipe } from '@angular/common';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { TransactionHdDto } from 'src/app/modules/models/FinancialService/TransactionHdDto';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { SelectOccupationsDto } from 'src/app/modules/models/SelectOccupationsDto';
import { SelectSubServiceTypeDto } from 'src/app/modules/models/SelectSubServiceTypeDto';
import { SelectServiceTypeDto } from 'src/app/modules/models/ServiceSetup/SelectServiceTypeDto';
import { CommonService } from 'src/app/modules/_services/common.service';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-view-service-detail',
  templateUrl: './view-service-detail.component.html',
  styleUrls: ['./view-service-detail.component.scss']
})
export class ViewServiceDetailComponent implements OnInit {
  // Getting base URL of Api from enviroment.
  baseUrl = environment.KUPFApiUrl;

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

  formTitle: string;
  closeResult: string = '';

  selectServiceType$: Observable<SelectServiceTypeDto[]>;
  selectServiceType: SelectServiceTypeDto[] = [];
  selectServiceSubType$: Observable<SelectServiceTypeDto[]>;
  selectServiceSubType: SelectSubServiceTypeDto[] = [];
  selectedServiceType: any;
  selectedServiceTypeText: any;
  selectedServiceSubType: any;
  selectedServiceSubTypeText: any;
  //
  parentForm: FormGroup;
  addServiceForm: FormGroup;
  financialCalculationForm: FormGroup;
  cashierInformationForm: FormGroup;
  popUpForm: FormGroup;
  isFormSubmitted = false;
  minDate: Date;
  editService$: Observable<TransactionHdDto[]>;
  mytransid: any;
  isObservableActive = true;
  pfId: any;
  isSubscriber = false;
  contractType$:Observable<SelectOccupationsDto[]>;
  // If PF Id is Not Null - SubscribeDate = Null and TerminationDate = Null
  notSubscriber: boolean = false;
  // 
  @ViewChild('popupModal', { static: true }) popupModal: ElementRef;
  //
  employeeForm: FormGroup | undefined;
  searchForm: FormGroup;
  genderArray: any = [
    { id: 1, name: 'Male' },
    { id: 2, name: 'Female' }
  ];
  maritalStatusArray: any = [
    { id: 1, name: 'Married' },
    { id: 2, name: 'Single' }
  ];
  @Input() arabicFont: string = 'font-family: Cairo;';
  @Input() pageName: string;
  isViewOnly: Boolean;
  // If Pf Id is null we will hide financial calculation div...
  isPFIdNull: boolean = false;
  //
  myTransId: any;
  //
  serviceTypeSelected: any;
  serviceSubTypeSelected: any;
  // To Set/Get discount type
  allowedDiscountType: any;
  //
  isSearched: boolean = false;
  //
  isPfIdExists: boolean = false;

  constructor(private financialService: FinancialService,
    private commonService: DbCommonService,
    private fb: FormBuilder,
    private toastrService: ToastrService,
    private activatedRout: ActivatedRoute,
    public common: CommonService,
    public datepipe: DatePipe,
    private router: Router,
    private modalService: NgbModal) {

    //
    this.setUpParentForm();
    this.minDate = new Date();
    this.minDate.setDate(this.minDate.getDate());
    //
    this.mytransid = this.activatedRout.snapshot.paramMap.get('transId');
  }
  lang:string;
  ngOnInit(): void {
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    //#region TO SETUP THE FORM LOCALIZATION    
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

          this.formHeaderLabels.push(labels);

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

    // To FillUp Contract Types
    this.contractType$ = this.commonService.GetContractType();

    // Getting SerialNo...
    this.financialService.GenerateFinancialServiceSerialNo().subscribe((response: any) => {
      //
      this.addServiceForm.patchValue({
        searialNo: response
      })
    });

    this.initializeAddServiceForm();
    //
    this.initPopUpModal();
    //
    this.setValidators(this.notSubscriber);
    // 
    this.initializeEmployeeForm();
    //
    this.initializeSearchForm();
    //
    this.initializeFinancialForm();
    //
    this.initializeCashierInformationForm();

    // Get Tenant Id
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { location: any; }) => obj.location);

    //

    if (this.mytransid) {
      this.common.ifEmployeeExists = true;
      // To display other Accordians
      this.isSearched = true;
      if (this.common.isViewOnly === true) {
        // If user comes from Cashier Approval...
        this.isViewOnly = true;
      }
      // To Select selected service type  
      this.financialService.GetServiceType(tenantId).subscribe((response: any) => {
        this.selectServiceType = response;
      });
      //
      this.financialService.GetFinancialServiceById(this.mytransid).subscribe((response: any) => {
        this.allowedDiscountType = response.discountType;
        this.serviceTypeSelected = response.serviceType;
        console.log('edit response', response);
        this.parentForm.patchValue({
          employeeForm: {
            employeeId: response.employeeId,
            englishName: response.englishName,
            arabicName: response.arabicName,
            empGender: response.empGender,
            joinedDate: new Date(response.joinedDate),
            empBirthday: new Date(response.empBirthday),
            mobileNumber: response.mobileNumber,
            empMaritalStatus: +response.empMaritalStatus,
            nationName: response.nationName,
            contractType: +response.contractType,
            subscriptionAmount: response.subscriptionAmount,
            subscriptionPaid: response.subscriptionPaid,
            lastSubscriptionPaid: response.paidSubscriptionAmount,
            subscriptionDueAmount: response.subscriptionDueAmount,
            subscriptionStatus: response.subscriptionStatus,
            terminationDate: response.terminationDate,
            endDate: response.endDate,
            employeeStatus: response.employeeStatus,
            CountryNameEnglish: response.nationName,
            CountryNameArabic: response.nationName,
            employeePFId: response.pfid,
            employeeCID: response.empCidNum,
            employeeFormEmployeeId: response.employeeId,
            kinMobile:response.kinMobile,
            kinName:response.kinName,
            serviceTypeId: response.serviceTypeId,
            serviceSubTypeId: response.serviceSubTypeId,
            serviceType: response.serviceTypeId,
            serviceSubType: response.serviceSubTypeId,

          },
          addServiceForm: {
            mytransid: response.mytransid,
            
            totinstallments: response.totinstallments,
            totamt: response.totamt,
            installmentAmount: response.installmentAmount,
            installmentsBegDate: response.installmentsBegDate ? new Date(response.installmentsBegDate) : '',
            untilMonth: response.untilMonth,
            downPayment: response.downPayment,
            pfId: response.pfid,
            allowDiscountAmount: response.allowDiscountAmount,
            discountType: response.discountType,
            allowDiscountDefault: response.allowDiscountDefault
          },
          financialForm: {
            hajjAct: response.hajjAct,
            loanAct: response.loanAct,
            persLoanAct: response.persLoanAct,
            otherAct1: response.otherAct1,
            otherAct2: response.otherAct2,
            otherAct3: response.otherAct3,
            otherAct4: response.otherAct4,
            otherAct5: response.otherAct5,
          },
          // approvalDetailsForm: {
          //   serApproval1: response.serApproval1,
          //   approvalBy1: response.approvalBy1,
          //   approvedDate1: response.approvedDate1,
          //   serApproval2: response.serApproval2,
          //   approvalBy2: response.approvalBy2,
          //   approvedDate2: response.approvedDate2,
          //   serApproval3: response.serApproval3,
          //   approvalBy3: response.approvalBy3,
          //   approvedDate3: response.approvedDate3,
          //   serApproval4: response.serApproval4,
          //   approvalBy4: response.approvalBy4,
          //   approvedDate4: response.approvedDate4,
          //   serApproval5: response.serApproval5,
          //   approvalBy5: response.approvalBy5,
          //   approvedDate5: response.approvedDate5,
          // },
          // documentAttachmentForm: {
          //   docType: response.transactionHDDMSDto[0].docType,
          //   docType1: response.transactionHDDMSDto[1].docType,
          //   docType2: response.transactionHDDMSDto[2].docType,
          //   docType3: response.transactionHDDMSDto[3].docType,
          //   docType4: response.transactionHDDMSDto[4].docType,
          //   attachmentByName: response.transactionHDDMSDto[0].attachmentByName,
          //   attachmentByName1: response.transactionHDDMSDto[1].attachmentByName,
          //   attachmentByName2: response.transactionHDDMSDto[2].attachmentByName,
          //   attachmentByName3: response.transactionHDDMSDto[3].attachmentByName,
          //   attachmentByName4: response.transactionHDDMSDto[4].attachmentByName,
          // }
        })
        this.commonService.GetSubServiceTypeByServiceType(tenantId, response.serviceTypeId).subscribe((response: any) => {
          this.selectServiceSubType = response;
        });

      })
      //
      //this.enableDisableControls(this.addServiceForm.get('allowDiscountDefault')?.value)   
      this.addServiceForm.get('pfId')?.disable();
      this.employeeForm?.get('contractType')?.disable();
    }
    this.employeeForm?.get('serviceType')?.disable();
    this.employeeForm?.get('serviceSubType')?.disable();  
  }
  ngOnDestroy(): void {
    this.isObservableActive = false;
    this.isSubscriber = false;
    this.common.isViewOnly = false;
    this.isPFIdNull = false;
    this.isSearched = false;
  }

  setUpParentForm() {
    this.parentForm = this.fb.group({});
  }
  // 
  initializeEmployeeForm() {
    this.employeeForm = new FormGroup({
      employeeId: new FormControl(''),
      englishName: new FormControl('', Validators.required),
      arabicName: new FormControl('', Validators.required),
      empGender: new FormControl('', Validators.required),
      joinedDate: new FormControl('', Validators.required),
      mobileNumber: new FormControl('', Validators.required),
      empMaritalStatus: new FormControl('', Validators.required),
      nationName: new FormControl('', Validators.required),
      contractType: new FormControl('', Validators.required),
      kinName: new FormControl('', Validators.required),
      kinMobile: new FormControl('', Validators.required),
      subscriptionAmount: new FormControl('', Validators.required),
      subscriptionPaid: new FormControl('', Validators.required),
      lastSubscriptionPaid: new FormControl(''),
      subscriptionDueAmount: new FormControl(''),
      subscriptionStatus: new FormControl(''),
      terminationDate: new FormControl(''),
      endDate: new FormControl(''),
      employeeStatus: new FormControl(''),
      isKUEmployee: new FormControl(''),
      isOnSickLeave: new FormControl(''),
      isMemberOfFund: new FormControl(''),
      CountryNameEnglish: new FormControl(''),
      CountryNameArabic: new FormControl(''),
      employeePFId: new FormControl(''),
      employeeCID: new FormControl(''),
      employeeFormEmployeeId: new FormControl(''),
      serviceSubType: new FormControl('', Validators.required),
      serviceType: new FormControl('', Validators.required),
      transDate: new FormControl(moment(new Date()).format("yyyy-MM-DD")),
      serviceSubTypeId: new FormControl(''),
      serviceTypeId: new FormControl(''),
    })
    this.parentForm.setControl('employeeForm', this.employeeForm);
  }
  initializeSearchForm() {
    this.searchForm = new FormGroup({
      employeeId: new FormControl('', Validators.required),
      pfId: new FormControl('', Validators.required),
      cId: new FormControl('', Validators.required),
    })
  }
  initializeAddServiceForm() {
    this.addServiceForm = this.fb.group({
      mytransid: new FormControl('0'),
      
      searialNo: new FormControl('', Validators.required),
      totamt: new FormControl('0', Validators.required),
      totinstallments: new FormControl('0', Validators.required),
      allowDiscount: new FormControl('', Validators.required),
      installmentAmount: new FormControl('0', Validators.required),
      installmentsBegDate: new FormControl('', Validators.required),
      untilMonth: new FormControl('', Validators.required),
      
      downPayment: new FormControl('0'),
      discountType: new FormControl(null),
      allowDiscountAmount: new FormControl('0'),
      allowDiscountPer: new FormControl(null),
      pfId: new FormControl(null),
      allowDiscountDefault: new FormControl(null)
    })
    this.parentForm.setControl('addServiceForm', this.addServiceForm);
  }
  initPopUpModal() {
    this.popUpForm = this.fb.group({
      transactionId: new FormControl(null),
      attachId: new FormControl(null)
    })
  }
  initializeFinancialForm() {
    this.financialCalculationForm = this.fb.group({
      noOfTransactions: new FormControl('0'),
      subscriptionPaidAmount: new FormControl('0.0'),
      subscriptionDueAmount: new FormControl('0.0'),
      subscriptionInstalmentAmount: new FormControl('0.0'),
      financialAid: new FormControl('0.0'),
      pfFundRevenue: new FormControl('0.0'),
      adjustmentAmount: new FormControl('0.0'),
      adjustmentAmountRemarks: new FormControl(null),
      pfFundRevenuePercentage: new FormControl('0.0'),
      sponsorLoanPendingAmount: new FormControl('0.0'),
      sponsorDueAmount: new FormControl('0.0'),
      finAidAmountRemarks: new FormControl(null),
      loanPendingAmount: new FormControl('0.0'),
      loanreceivedAmount: new FormControl('0.0'),
      loanInstallmentAmount: new FormControl('0.0'),
      noOfSponsor: new FormControl('0'),
      yearOfService: new FormControl(null),
      totalAmount: new FormControl('0.0'),
      financialAidAmount: new FormControl('0.0'),
      UpdateToDate: new FormControl(null),
      mySeq: new FormControl(1),
      DisplayPERIOD_CODE: new FormControl('20230214')
    });
  }
  initializeCashierInformationForm() {
    this.cashierInformationForm = this.fb.group({
      payPer1: new FormControl('0'),
      draftNumber1: new FormControl('0'),
      draftDate1: new FormControl(null),
      draftAmount1: new FormControl('0'),
      bankAccount1: new FormControl('0'),
      deliveryDate1: new FormControl(null),
      receivedBy1: new FormControl(null),
      deliveredBy1: new FormControl(null),
      payPer2: new FormControl('0'),
      draftNumber2: new FormControl('0'),
      draftDate2: new FormControl(null),
      draftAmount2: new FormControl('0'),
      bankAccount2: new FormControl('0'),
      deliveryDate2: new FormControl(null),
      receivedBy2: new FormControl(null),
      deliveredBy2: new FormControl(null),
    })
  }
  calculateUntilMonth(selectedDate: Date) {
    if (selectedDate !== undefined) {
      let noOfinstallments = this.addServiceForm.get('totinstallments')?.value;
      var newDate = moment(selectedDate).add(noOfinstallments - 1, 'M').format('MMM-YYYY');
      this.addServiceForm.patchValue({
        untilMonth: newDate
      });
    }

  }
  
  // To access form controls...
  get addServiceFrm() { return this.addServiceForm.controls; }
  
  // Conditionally set validations.
  setValidators(isNotSubscriber: boolean) {
    const totamt = this.addServiceForm.get('totamt');
    const totinstallments = this.addServiceForm.get('totinstallments');
    const installmentAmount = this.addServiceForm.get('installmentAmount');
    const allowDiscount = this.addServiceForm.get('allowDiscount');
    const installmentsBegDate = this.addServiceForm.get('installmentsBegDate');

    const serviceType = this.addServiceForm.get('serviceType');
    const serviceSubType = this.employeeForm?.get('serviceSubType');
    if (isNotSubscriber) {
      totamt?.setValidators([Validators.required]);
      totinstallments?.setValidators([Validators.required]);
      installmentAmount?.setValidators([Validators.required]);
      allowDiscount?.setValidators([Validators.required]);
      installmentsBegDate?.setValidators([Validators.required]);
      serviceType?.setValidators([Validators.required]);
      serviceSubType?.setValidators([Validators.required]);
    }
    if (!isNotSubscriber) {
      totamt?.setValidators(null);
      totinstallments?.setValidators(null);
      installmentAmount?.setValidators(null);
      allowDiscount?.setValidators(null);
      installmentsBegDate?.setValidators(null);
      serviceType?.setValidators(null);
      serviceSubType?.setValidators(null);
    }
    totamt?.updateValueAndValidity();
    totinstallments?.updateValueAndValidity();
    installmentAmount?.updateValueAndValidity();
    allowDiscount?.updateValueAndValidity();
    installmentsBegDate?.updateValueAndValidity();
    serviceType?.updateValueAndValidity();
    serviceSubType?.updateValueAndValidity();
  }
}
