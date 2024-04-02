import { DatePipe } from '@angular/common';
import { ChangeDetectorRef, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router, RoutesRecognized } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { Observable,from, takeUntil, takeWhile } from 'rxjs';
import { TransactionHdDto } from 'src/app/modules/models/FinancialService/TransactionHdDto';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { SelectOccupationsDto } from 'src/app/modules/models/SelectOccupationsDto';
import { SelectSubServiceTypeDto } from 'src/app/modules/models/SelectSubServiceTypeDto';
import { SelectServiceTypeDto } from 'src/app/modules/models/ServiceSetup/SelectServiceTypeDto';
import { CommonService } from 'src/app/modules/_services/common.service';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { environment } from 'src/environments/environment';
import { Location } from '@angular/common';
import { PageInfoService } from 'src/app/_metronic/layout';
import { getMonth } from 'ngx-bootstrap/chronos';

@Component({
  selector: 'app-add-service',
  templateUrl: './add-service.component.html',
  styleUrls: ['./add-service.component.scss']
})
export class AddServiceComponent implements OnInit, OnDestroy {
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
  calculatedtotalAmount = 0;
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
  contractType$: Observable<SelectOccupationsDto[]>;
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
  isDisabledAddService: boolean = false;
  // To Set/Get discount type
  allowedDiscountType: any;
  //
  showHidePaymentStatus: boolean;
  showHideButton : boolean;
  showHide: boolean;
  isSearched: boolean = false;
  showHideSesrchFrom: boolean = false;
  showHideMessage: boolean;
  //
  isPfIdExists: boolean = false;
  lang: string;
  serviceInformationJson: any;

  constructor(
    private financialService: FinancialService,
    private commonService: DbCommonService,
    private fb: FormBuilder,
    private toastrService: ToastrService,
    private activatedRout: ActivatedRoute,
    public common: CommonService,
    public datepipe: DatePipe,
    public _pageInfoService: PageInfoService,
    private router: Router,
    private ref: ChangeDetectorRef,
    private location: Location,
    private modalService: NgbModal) {

    this.setUpParentForm();

    this.minDate = new Date();
    this.minDate.setDate(this.minDate.getDate());
    //
    this.mytransid = this.activatedRout.snapshot.paramMap.get('mytransid');

    var serviceInformation: any = this.activatedRout.snapshot.paramMap.get('serviceInformation');
    if (serviceInformation) {
      this.serviceInformationJson = JSON.parse(serviceInformation);
      console.log(this.serviceInformationJson);
    }
  }
  ngAfterContentChecked() {
    if (this.serviceInformationJson) {
      this.ref.detectChanges();
      this._pageInfoService.setTitle(this.serviceInformationJson.subServiceTypeEnglishName);
    }
  }

  tenantId: number;
  serviceArabicName: string = '';
  subServiceArabicName: string = '';

  ngOnInit(): void {
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    this.showHideButton=false;
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

    // To FillUp Contract Types
    this.contractType$ = this.commonService.GetContractType();
    //
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
    this.tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { location: any; }) => obj.location);

    // To Select selected service type  
    // this.financialService.GetServiceType(tenantId).subscribe((response: any) => {
    //   this.selectServiceType = response;
    // });
    // this.commonService.GetSubServiceTypeByServiceType(tenantId, ).subscribe((res: any) => {
    //   this.selectServiceSubType = res;
    //   // this.serviceSubTypeSelected = response.serviceSubType;   
    // });

    //

    if (this.serviceInformationJson) {
      this.employeeForm?.patchValue({
        serviceType: this.serviceInformationJson.serviceTypeEnglishName,
        serviceSubType: this.serviceInformationJson.subServiceTypeEnglishName,
        serviceTypeId: this.serviceInformationJson.serviceTypeId,
        serviceSubTypeId: this.serviceInformationJson.subServiceTypeId,
      })
      this.serviceArabicName = this.serviceInformationJson.serviceTypeArabicName;
      this.subServiceArabicName = this.serviceInformationJson.subServiceTypeArabicName;
    }

    if (this.mytransid) {

      this.common.ifEmployeeExists = true;
      // To display other Accordians
      this.isSearched = true;
      if (this.common.isViewOnly === true) {
        // If user comes from Cashier Approval...
        this.isViewOnly = true;
      }

      //
      this.financialService.GetFinancialServiceById(this.mytransid).subscribe((response: any) => {
        this.GetServiceTypeSubServiceTypeByTenentId(response.serviceTypeId, response.serviceSubTypeId);
        console.log('edit service', response);
        this.showHideSesrchFrom = true;
        this.allowedDiscountType = response.discountType;
        // this.serviceTypeSelected = response.serviceType;
        this.onServiceSubTypeChange(response.serviceTypeId, response.serviceSubTypeId);

        // this.serviceInformationJson.serviceTypeName = response.serviceType;
        // this.serviceInformationJson.subServiceTypeName = response.serviceSubType;
        // this.serviceInformationJson.serviceTypeId = response.serviceTypeId;
        // this.serviceInformationJson.subServiceTypeId = response.serviceSubTypeId;
        this._pageInfoService.setTitle(response.serviceSubType);
        this.calculatedtotalAmount = response.totamt - response.allowDiscountAmount - response.downPayment;
 
          // && response.serviceTypeId == 3
  
          if(response.totamt != null){
            this.showHidePaymentStatus = true;
          }
  
          if(this.calculatedtotalAmount == 0){
            response.totinstallments = 0;
            response.installmentAmount = 0;
            response.installmentsBegDate = new Date();
            response.untilMonth =  moment(new Date()).format('MMM-YYYY');
          }
        this.parentForm.patchValue({
          employeeForm: {
            employeeId: response.employeeId,
            englishName: response.englishName,
            arabicName: response.arabicName,
            empGender: response.empGender,
            joinedDate: moment(response.joinedDate).format("DD-MM-yyyy"),
            empBirthday: new Date(response.empBirthday),
            mobileNumber: response.mobileNumber,
            empMaritalStatus: +response.empMaritalStatus,
            nationName: response.nationName,
            contractType: +response.contractType,
            subscriptionAmount: response.subscriptionAmount,
            subscriptionPaid: response.subscriptionPaid,
            lastSubscriptionPaid: response.lastSubscriptionPaid,
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
            kinMobile: response.kinMobile,
            kinName: response.kinName,
            salary: response.salary,
            serviceType: response.serviceType,
            serviceSubType: response.serviceSubType,
            serviceTypeId: response.serviceTypeId,
            serviceSubTypeId: response.serviceSubTypeId,
          },
          addServiceForm: {
            // mytransid: response.mytransid,
            totinstallments: response.totinstallments,
            totamt: response.totamt,
            installmentAmount: response.installmentAmount,
            installmentsBegDate: response.installmentsBegDate ? new Date(response.installmentsBegDate) : '',
            untilMonth: response.untilMonth,
            downPayment: response.downPayment,
            pfId: response.pfid,
            allowDiscountAmount: response.allowDiscountAmount,
            discountType: response.discountType,
            allowDiscountDefault: response.allowDiscountDefault,
            searialNo: response.mytransid,
            Remark:response.remark,
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
         
        })
        this.financialCalculationForm.patchValue({
          subscriptionPaidAmount: response.paidSubscriptionAmount,
          subscriptionDueAmount: response.subscriptionDueAmount,
          financialAid: response.financialAidPercentage,
          pfFundRevenue: response.pfFundRevenue,
          adjustmentAmount: response.adjustmentAmount,
          adjustmentAmountRemarks: response.adjustmentAmountRemarks,
          finAidAmountRemarks: response.financialAmountRemarks,
          payableAmount: response.calculatedAmount,
          loanPendingAmount: response.loanAmountBalance,
          yearOfService: response.yearOfService,
          financialAidAmount: response.financialAmount,
        })

        // this.searchForm.controls['employeeId'].setValue(response.employeeId);
        // setTimeout(()=>{
        //   this.getFinancialCalculation();
        // })        
        this.enableDisableControls(response.allowDiscountDefault);
      })
      //

      this.addServiceForm.get('pfId')?.disable();
      this.employeeForm?.get('contractType')?.disable();
    }
    if (this.financialService.subScriptionId) {
      this.searchForm.controls['employeeId'].setValue(this.financialService.subScriptionId);
      this.SearchNewSubscriber();
    }
  }

  GetServiceTypeSubServiceTypeByTenentId(a1: any, b1: any) {
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    this.financialService.GetServiceTypeSubServiceTypeByTenentId(tenantId).subscribe((res: any) => {
      var val = res.find((x: any) => {
        return x.serviceTypeId == a1 && x.subServiceTypeId == b1
      })
      this.serviceInformationJson = val
      console.log(val);

      // this.serviceInformationJson = {
      //   menuId: "35",
      //   serviceTypeId: 2,
      //   serviceTypeName: "FINANCIAL SERVICES -  الخدمات المالية",
      //   subServiceTypeId: 201,
      //   subServiceTypeName: "Return a Reserved Amount - إرجاع مبلغ محجوز",
      //   tab1: "1",
      //   tab2: "2",
      //   tab3: "1",
      //   tab4: "1",
      //   tab5: "3",
      //   tab6: "3"
      // }
    })
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

  initializeEmployeeForm() {
    this.employeeForm = new FormGroup({
      employeeId: new FormControl(''),
      englishName: new FormControl('', Validators.required),
      serviceSubType: new FormControl('', Validators.required),
      serviceSubTypeId: new FormControl(''),
      serviceType: new FormControl('', Validators.required),
      serviceTypeId: new FormControl(''),
      transDate: new FormControl(null),
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
      // isOnSickLeave: new FormControl(''),
      // isMemberOfFund: new FormControl(''),
      CountryNameEnglish: new FormControl(''),
      CountryNameArabic: new FormControl(''),
      employeePFId: new FormControl(''),
      employeeCID: new FormControl(''),
      employeeFormEmployeeId: new FormControl(''),
      salary: new FormControl('0'),
      SponserID: new FormControl('0'),
      SponserName: new FormControl(''),
      NumberofSponsorships: new FormControl(''),
      SponserRemarks: new FormControl(''),
    })
    this.employeeForm.controls['transDate'].setValue(moment(new Date()).format("DD-MM-yyyy"));
    this.employeeForm?.get('transDate')?.disable();
    this.parentForm.setControl('employeeForm', this.employeeForm);
  }
  
  initializeSearchForm() {
    this.searchForm = new FormGroup({
      employeeId: new FormControl(0, Validators.required),
      pfId: new FormControl('', Validators.required),
      cId: new FormControl('', Validators.required),
    })
  }
  initializeAddServiceForm() {
    this.addServiceForm = this.fb.group({
      // mytransid: new FormControl('0'),
      searialNo: new FormControl('', Validators.required),
      totamt: new FormControl('0', Validators.required),
      totinstallments: new FormControl('0', Validators.required),
      allowDiscount: new FormControl('', Validators.required),
      installmentAmount: new FormControl('0', Validators.required),
      installmentsBegDate: new FormControl('', Validators.required),
      untilMonth: new FormControl('', Validators.required),
      downPayment: new FormControl('0'),
      discountType: new FormControl('0'),
      allowDiscountAmount: new FormControl('0'),
      allowDiscountPer: new FormControl(0),
      allowDiscountDefault: new FormControl(null),
      pfId: new FormControl(''),
      Remark: new FormControl('')
    })
    this.parentForm.setControl('addServiceForm', this.addServiceForm);
  }
  initPopUpModal() {
    this.popUpForm = this.fb.group({
      transactionId: new FormControl(null),
      attachId: new FormControl(null),
      pfid: new FormControl(null)
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
      payableAmount: new FormControl(''),
      loanPendingAmount: new FormControl('0.0'),
      loanreceivedAmount: new FormControl('0.0'),
      loanInstallmentAmount: new FormControl('0.0'),
      noOfSponsor: new FormControl('0'),
      yearOfService: new FormControl(null),
      totalAmount: new FormControl('0.0'),
      financialAidAmount: new FormControl('0.0'),
      UpdateToDate: new FormControl(null),
      mySeq: new FormControl(1),
      mytransid: new FormControl(0),
      DisplayPERIOD_CODE: new FormControl('20230214'),
      amountMinus: new FormControl('0.0'),
      amountPlus: new FormControl('0.0'),
      systemRemarks: new FormControl(''),
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



  saveFinancialService() {
    this.isFormSubmitted = true;
    if (!this.searchForm.value['employeeId']) {
      this.toastrService.warning("Kindly search an employee", 'Warning');
    }

    var x = [5, 3, 6].find((y) => {
      return y === this.employeeFrm?.serviceSubTypeId.value
    })
    if (x) {
      this.addServiceForm.patchValue({
        // mytransid: new FormControl('0'),
        searialNo: this.addServiceForm.controls['searialNo'].value ? this.addServiceForm.controls['searialNo'].value : 0,
        totamt: this.addServiceForm.controls['totamt'].value ? this.addServiceForm.controls['totamt'].value : 0,
        totinstallments: this.addServiceForm.controls['totinstallments'].value ? this.addServiceForm.controls['totinstallments'].value : 0,
        allowDiscount: this.addServiceForm.controls['allowDiscount'].value ? this.addServiceForm.controls['allowDiscount'].value : 0,
        installmentAmount: this.addServiceForm.controls['installmentAmount'].value ? this.addServiceForm.controls['installmentAmount'].value : 0,
        installmentsBegDate: moment(this.addServiceForm.controls['installmentsBegDate'].value).format("yyyy-MM-DD"),
        untilMonth: moment(this.addServiceForm.controls['untilMonth'].value ? this.addServiceForm.controls['untilMonth'].value : new Date()).format("yyyy-MM-DD"),
        downPayment: this.addServiceForm.controls['downPayment'].value ? this.addServiceForm.controls['downPayment'].value : 0,
        discountType: this.addServiceForm.controls['discountType'].value ? this.addServiceForm.controls['discountType'].value : 0,
        allowDiscountAmount: this.addServiceForm.controls['allowDiscountAmount'].value ? this.addServiceForm.controls['allowDiscountAmount'].value : 0,
        allowDiscountPer: this.addServiceForm.controls['allowDiscountPer'].value ? this.addServiceForm.controls['allowDiscountPer'].value : 0,
        allowDiscountDefault: this.addServiceForm.controls['allowDiscountDefault'].value ? this.addServiceForm.controls['allowDiscountDefault'].value : false,
      })
      if (!this.financialCalculationForm.controls['totalAmount'].value) {
        this.toastrService.warning("Kindly get the financial calculation", "Warning");
        return;
      }
    } else {
      this.financialCalculationForm.patchValue({
        noOfTransactions: this.financialCalculationForm.controls['noOfTransactions'].value ? this.financialCalculationForm.controls['noOfTransactions'].value : 0,
        subscriptionPaidAmount: this.financialCalculationForm.controls['subscriptionPaidAmount'].value ? this.financialCalculationForm.controls['subscriptionPaidAmount'].value : 0,
        subscriptionDueAmount: this.financialCalculationForm.controls['subscriptionDueAmount'].value ? this.financialCalculationForm.controls['subscriptionDueAmount'].value : 0,
        subscriptionInstalmentAmount: this.financialCalculationForm.controls['subscriptionInstalmentAmount'].value ? this.financialCalculationForm.controls['subscriptionInstalmentAmount'].value : 0,
        financialAid: this.financialCalculationForm.controls['financialAid'].value ? this.financialCalculationForm.controls['financialAid'].value : 0,
        pfFundRevenue: this.financialCalculationForm.controls['pfFundRevenue'].value ? this.financialCalculationForm.controls['pfFundRevenue'].value : 0,
        adjustmentAmount: this.financialCalculationForm.controls['adjustmentAmount'].value ? this.financialCalculationForm.controls['adjustmentAmount'].value : 0,
        adjustmentAmountRemarks: this.financialCalculationForm.controls['adjustmentAmountRemarks'].value ? this.financialCalculationForm.controls['adjustmentAmountRemarks'].value : 0,
        pfFundRevenuePercentage: this.financialCalculationForm.controls['pfFundRevenuePercentage'].value ? this.financialCalculationForm.controls['pfFundRevenuePercentage'].value : 0,
        sponsorLoanPendingAmount: this.financialCalculationForm.controls['sponsorLoanPendingAmount'].value ? this.financialCalculationForm.controls['sponsorLoanPendingAmount'].value : 0,
        sponsorDueAmount: this.financialCalculationForm.controls['sponsorDueAmount'].value ? this.financialCalculationForm.controls['sponsorDueAmount'].value : 0,
        finAidAmountRemarks: this.financialCalculationForm.controls['finAidAmountRemarks'].value ? this.financialCalculationForm.controls['finAidAmountRemarks'].value : 0,
        payableAmount: this.financialCalculationForm.controls['payableAmount'].value ? this.financialCalculationForm.controls['payableAmount'].value : '',
        loanPendingAmount: this.financialCalculationForm.controls['loanPendingAmount'].value ? this.financialCalculationForm.controls['loanPendingAmount'].value : 0,
        loanreceivedAmount: this.financialCalculationForm.controls['loanreceivedAmount'].value ? this.financialCalculationForm.controls['loanreceivedAmount'].value : 0,
        loanInstallmentAmount: this.financialCalculationForm.controls['loanInstallmentAmount'].value ? this.financialCalculationForm.controls['loanInstallmentAmount'].value : 0,
        noOfSponsor: this.financialCalculationForm.controls['noOfSponsor'].value ? this.financialCalculationForm.controls['noOfSponsor'].value : 0,
        yearOfService: this.financialCalculationForm.controls['yearOfService'].value ? this.financialCalculationForm.controls['yearOfService'].value : 0,
        totalAmount: this.financialCalculationForm.controls['totalAmount'].value ? this.financialCalculationForm.controls['totalAmount'].value : 0,
        financialAidAmount: this.financialCalculationForm.controls['financialAidAmount'].value ? this.financialCalculationForm.controls['financialAidAmount'].value : 0,
        UpdateToDate: this.financialCalculationForm.controls['UpdateToDate'].value ? this.financialCalculationForm.controls['UpdateToDate'].value : 0,
        mySeq: this.financialCalculationForm.controls['mySeq'].value ? this.financialCalculationForm.controls['mySeq'].value : 1,
        mytransid: this.financialCalculationForm.controls['mytransid'].value ? this.financialCalculationForm.controls['mytransid'].value : 0,
        DisplayPERIOD_CODE: this.financialCalculationForm.controls['DisplayPERIOD_CODE'].value ? this.financialCalculationForm.controls['DisplayPERIOD_CODE'].value : '20230214',
        amountMinus: this.financialCalculationForm.controls['amountMinus'].value ? this.financialCalculationForm.controls['amountMinus'].value : 0,
        amountPlus: this.financialCalculationForm.controls['amountPlus'].value ? this.financialCalculationForm.controls['amountPlus'].value : 0,
        systemRemarks: this.financialCalculationForm.controls['systemRemarks'].value ? this.financialCalculationForm.controls['systemRemarks'].value : '',
      });
      if (!this.addServiceForm.controls['installmentAmount'].value || !this.addServiceForm.controls['totinstallments'].value) {
        this.toastrService.warning("Kindly fill add service information", "Warning");
        return;
      }
    }

    // if(!this.financialCalculationForm.controls['mySeq'].value){
    //   this.toastrService.warning("Kindly get the financial calculation", "Warning");
    // }

    setTimeout(() => {
      this.setValidators(this.notSubscriber);
      // Get Tenant Id
      var data = JSON.parse(localStorage.getItem("user")!);
      const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
      const locationId = data.map((obj: { locationId: any; }) => obj.locationId);
      const username = data.map((obj: { username: any; }) => obj.username);
      const periodCode = data.map((obj: { periodCode: any; }) => obj.periodCode);
      const prevPeriodCode = data.map((obj: { prevPeriodCode: any; }) => obj.prevPeriodCode);
      const nextPeriodCode = data.map((obj: { nextPeriodCode: any; }) => obj.nextPeriodCode);

      let formData = {
        ...this.parentForm.value.addServiceForm,
        ...this.parentForm.value.approvalDetailsForm,
        ...this.parentForm.value.employeeForm,
        ...this.parentForm.value.financialForm,
        ...this.financialCalculationForm.value,
        //...this.parentForm.value.financialFormArray,
        tenentID: tenantId, cruP_ID: 0, locationID: locationId, userId: username,
        periodCode: periodCode, prevPeriodCode: prevPeriodCode, nextPeriodCode: nextPeriodCode
      }

      formData['installmentsBegDate'] = moment(formData['installmentsBegDate'] ? formData['installmentsBegDate'] : 0).format("yyyy-MM-DD");
      formData['untilMonth'] = moment(formData['untilMonth']).format("yyyy-MM-DD");
      formData['deliveryDate'] = moment(formData['deliveryDate']).format("yyyy-MM-DD");
      // formData['transDate'] = moment(formData['transDate']).format("yyyy-MM-DD");//2023-03-01
      formData['discountType'] = this.allowedDiscountType ? this.allowedDiscountType : 0;
      formData['eachInstallmentsAmt'] = this.addServiceForm.get('installmentAmount')?.value;
      formData['downPayment'] = this.addServiceForm.get('downPayment')?.value ? this.addServiceForm.get('downPayment')?.value : 0;
      formData['discountedGiftAmount'] = this.addServiceForm.get('allowDiscountAmount')?.value;
      formData['installmentAmount'] = this.addServiceForm.get('installmentAmount')?.value;
      formData['totinstallments'] = this.addServiceForm.get('totinstallments')?.value;
      formData['allowDiscountDefault'] = this.addServiceForm.controls['allowDiscountDefault'].value ? this.addServiceForm.controls['allowDiscountDefault'].value : false;
      formData['mytransid'] = this.mytransid ? this.mytransid : 0;
      formData['AttachmentRemarks'] = "this is Remark";
      formData['Subject'] = "this is subject";
      formData['MetaTags'] = "add";
      formData['personalPhotoDocType'] = "1";
      formData['personalPhotoDocument'] = null;

      // formData['appplicationFileDocType'] = this.getForm.get('appplicationFileDocType')?.value;
      // formData['appplicationFileDocument'] = this.getForm.get('appplicationFileDocument')?.value;
      // formData['workIdDocType'] = this.getForm.get('workIdDocType')?.value;
      // formData['workIdDocument'] = this.getForm.get('workIdDocument')?.value;
      // formData['civilIdDocType'] = this.getForm.get('civilIdDocType')?.value;
      // formData['civilIdDocument'] = this.getForm.get('civilIdDocument')?.value;
      // formData['salaryDataDocType'] = this.getForm.get('salaryDataDocType')?.value;
      // formData['salaryDataDocument'] = this.getForm.get('salaryDataDocument')?.value;
      // var date = formData['transDate'];
      // let transactionDate =  date.split("-").reverse().join("-");
      formData['transDate'] = moment(new Date()).format("DD-MM-yyyy").split("-").reverse().join("-");
      // To get the values of disabled controls. If we are in Edit mode. 
      if (this.mytransid) {
        formData['discountedGiftAmount'] = this.addServiceForm.get('allowDiscountAmount')?.value;
        formData['installmentAmount'] = this.addServiceForm.get('installmentAmount')?.value;
      }
      // if (this.activatedRout.snapshot.paramMap.get('ServiceTypeId')) {
      //   this.addServiceForm.controls['allowDiscountDefault'].setValue(1);
      //   formData['allowDiscountDefault'] = this.addServiceForm.get('allowDiscountDefault')?.value;
      //   formData['subscriptionDueAmount'] = 0;
      // }
      let finalformData = new FormData();
      Object.keys(formData).forEach(key => finalformData.append(key, formData[key]));

      if (this.mytransid) {

        //console.log('edit click',formData);
        this.financialService.UpdateFinancialService(finalformData).subscribe((response: any) => {
          if (response.isSuccess == false) {
            this.toastrService.error(response.message, 'Error');
          } else {
            this.toastrService.success('Updated successfully', 'Success');

            setTimeout(() => {
              this.onOkayClick();
            }, 2000);
          }
        })
      } 
      else {
        //console.log('add click',formData);
        this.financialService.AddFinacialService(finalformData).subscribe((response: any) => {
          if (response.isSuccess == false) {
            this.toastrService.error(response.message, 'Error');
          }
          else {
            this.toastrService.success(response.message, 'Success');
            this.searchForm.controls['pfId'].setValue(response.pfId)
            // console.log('save response',response)
            this.popUpForm.patchValue({
              transactionId: response.transactionId,
              attachId: response.attachId,
              pfid: response.pfId,
            })
            this.parentForm.reset();
            this.financialCalculationForm.reset();
            this.openPopUpModal(this.popupModal);
          }
          //this.saveFinancialArray();   
        })
      }
    })

  }

  saveFinancialArray() {
    this.financialService.saveCOA(this.parentForm.value.financialFormArray, {}).subscribe(() => {
      this.toastrService.success('Saved successfully', 'Success');
      this.parentForm.reset();
    })
  }
  cancelClick() {
    // Clear search form 
    this.searchForm.reset();
    // Clear search form 
    this.parentForm.reset();
    this.financialCalculationForm.reset();

    // Setting current date to trans date...    
    this.employeeForm?.get('transDate')?.setValue(moment(new Date()).format("yyyy-MM-DD"));
    // Clear serviceTypeSelected
    this.selectServiceType = [];
    this.selectServiceSubType = [];
  }
  calculateUntilMonth(selectedDate: Date) {
    if (selectedDate !== undefined) {
      let noOfinstallments = this.addServiceForm.get('totinstallments')?.value;
      var newDate = moment(selectedDate).add(noOfinstallments + 1, 'M').format('MMM-YYYY');
      this.addServiceForm.patchValue({
        untilMonth: newDate
      });
    }
  }

  // Calculate Installments based on Installment Months...allowDiscountAmount
  calculateInstallments() {
    //
    let amount = this.addServiceForm.get('totamt')?.value;
    let noOfinstallments = this.addServiceForm.get('totinstallments')?.value;
    let allowDiscountAmount = this.addServiceForm.get('allowDiscountAmount')?.value;
    let downPayment = this.addServiceForm.get('downPayment')?.value;
    let allowDiscountDefault = this.addServiceForm.get('allowDiscountDefault')?.value;
    //
    let calculatedAmount = 0;
    let netAmount = 0;


    //
    if (amount == 0 || amount == '') {
      this.toastrService.error('Please enter amount', 'Error');
    }
    else if (noOfinstallments == '' && this.addServiceForm.get('discountType')?.value === 1 && this.selectedServiceSubType != 1) {
      this.toastrService.error('Please enter installments', 'Error');
    } else {
      this.calculatedtotalAmount = amount - downPayment - allowDiscountAmount;

      // If 1 Percentage...
      if (allowDiscountDefault && this.addServiceForm.get('discountType')?.value === 1) {
        calculatedAmount = ((amount - allowDiscountAmount) - downPayment);
        netAmount = (calculatedAmount / noOfinstallments);
        this.addServiceForm.patchValue({
          installmentAmount: netAmount.toFixed(3)
        })
      }
      if (!allowDiscountDefault) {
        this.addServiceForm.patchValue({
          installmentAmount: this.addServiceForm.get('totamt')?.value,
          allowDiscountAmount: 0
        })
      }
      if (noOfinstallments > 0 || this.calculatedtotalAmount != 0) {
        let val = (amount - allowDiscountAmount - downPayment) / noOfinstallments
        this.addServiceForm.get('installmentAmount')?.setValue(val);

        let selectedDate = this.addServiceForm.get('installmentsBegDate')?.value;
        var newDate = moment(selectedDate).add(noOfinstallments - 1, 'M').format('MMM-YYYY');
        this.addServiceForm.patchValue({
          untilMonth: newDate
        });
      }
      if(this.calculatedtotalAmount == 0 && downPayment != null){
        this.addServiceForm.get('installmentAmount')?.setValue(0);
        this.addServiceForm.get('totinstallments')?.setValue(0);
          this.addServiceForm.patchValue({
            installmentsBegDate: moment(new Date()).format('MMM-YYYY'),
            untilMonth: moment(new Date()).format('MMM-YYYY')
          });
      }
      if(downPayment == null){
        let selectedDate = this.addServiceForm.get('installmentsBegDate')?.value;
        var newDate = moment(selectedDate).add(noOfinstallments + 1, 'M').format('MMM-YYYY');
        this.addServiceForm.patchValue({
          untilMonth: newDate
        })
      }
      // If 2 Fixed Amount and discount will be 100%...
      // else if (this.addServiceForm.get('discountType')?.value === 2) {
      //   calculatedAmount = ((amount - allowDiscountAmount) - downPayment);
      //   netAmount = (calculatedAmount / noOfinstallments);
      // }

      // this.addServiceForm.patchValue({
      //   installmentAmount: netAmount.toFixed(2)
      // })
    }
  }

  onServiceTypeChange(event: any) {
    console.log(event);
    this.selectServiceSubType = [];
    this.employeeForm?.controls['serviceSubType'].setValue(null);
    this.commonService.GetSubServiceTypeByServiceType(21, event.refId).subscribe((response: any) => {
      this.selectServiceSubType = response
      if (this.common.PFId != null
        && this.common.subscribedDate != null
        && this.common.terminationDate != null) {
        // This is Resubscribe Case
        if (response) {
          let index = this.selectServiceSubType.findIndex(x => x.refId == 1);
          if (index >= 0) {
            this.selectServiceSubType.splice(index, 1);
          }
        }
        //
        this.notSubscriber = false;
      }
      if (this.isSubscriber) {
        let index = this.selectServiceSubType.findIndex(x => x.refId == 2);
        if (index >= 0) {
          this.selectServiceSubType.splice(index, 2);
        }
        //
        this.notSubscriber = false;
      }
    });


    this.selectedServiceType = event.refId;
    this.selectedServiceTypeText = event.shortname;
  }

  onServiceSubTypeChange(serviceId: number, subServiceId: number) {
    this.financialService.GetSelectedServiceSubType(serviceId, subServiceId, this.tenantId).subscribe((response: any) => {
      // To set discount type and we will save it into TransactionHD...
      this.allowedDiscountType = response.discountType;
      // this.addServiceForm.get('downPayment')?.enable();
      this.parentForm.patchValue({
        addServiceForm: {
          allowDiscount: response.allowDiscountAmount,
          allowDiscountPer: response.allowDiscountPer,
          discountType: response.discountType,
         // totinstallments: response.maxInstallment,
          allowDiscountAmount: response.allowDiscountAmount,
          allowDiscountDefault: response.allowDiscountDefault ? response.allowDiscountDefault : false

        },
        approvalDetailsForm: {
          serApproval1: +response.serApproval1,
          approvalBy1: response.approvalBy1,
          approvedDate1: response.approvedDate1 ? new Date(response.approvedDate1) : '',

          serApproval2: +response.serApproval2,
          approvalBy2: response.approvalBy2,
          approvedDate2: response.approvedDate2 ? new Date(response.approvedDate2) : '',

          serApproval3: +response.serApproval3,
          approvalBy3: response.approvalBy3,
          approvedDate3: response.approvedDate3 ? new Date(response.approvedDate3) : '',

          serApproval4: +response.serApproval4,
          approvalBy4: response.approvalBy4,
          approvedDate4: response.approvedDate4 ? new Date(response.approvedDate4) : '',

          serApproval5: +response.serApproval5,
          approvalBy5: response.approvalBy5,
          approvedDate5: response.approvedDate5 ? new Date(response.approvedDate5) : '',
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
          otherAct5: response.otherAct5
        },
      });
      if (!this.addServiceForm.get('allowDiscountDefault')?.value) {
        this.addServiceForm.patchValue({
          installmentAmount: this.addServiceForm.get('totamt')?.value,
          totinstallments: 0,
          allowDiscountAmount: 0
        })
        //
        this.enableDisableControls(response.allowDiscountDefault)
      }
      if (this.mytransid) {
        this.calculatedtotalAmount = this.addServiceForm.controls['totamt'].value - this.addServiceForm.controls['downPayment'].value - response.allowDiscountAmount;
      }
      // To add default current date...
      var now = new Date();

      this.addServiceForm.patchValue({
        installmentsBegDate: moment(new Date(now.getFullYear(), now.getMonth() + 1)).format("MMM-YYYY"),
        untilMonth: moment(new Date(now.getFullYear(), now.getMonth() + (this.addServiceForm.controls['totinstallments'].value == 0 ? 1 : 10))).format("MMM-YYYY"),

      })

      this.employeeForm?.patchValue({
        transDate: this.employeeForm.get('transDate')?.value
      })
      // To enable/disable PF Id text box.
      if (this.isPfIdExists) {
        this.addServiceForm.get('pfId')?.disable();
      }
      if (subServiceId == 1) {
        this.addServiceForm.patchValue({
          allowDiscountAmount: 0
        })
      }
      if (serviceId == 2 && subServiceId == 3) {
        this.parentForm.patchValue({
          addServiceForm: {
            allowDiscountAmount: 100
          }
        });
        //
        // this.addServiceForm.get('downPayment')?.disable();
      }

    })
    this.selectedServiceSubType = subServiceId;
    // this.selectedServiceSubTypeText = $event.shortName;
  }

  // To access form controls...
  get addServiceFrm() { return this.addServiceForm.controls; }

  get employeeFrm() { return this.employeeForm?.controls; }
  // Conditionally set validations.
  setValidators(isNotSubscriber: boolean) {
    const totamt = this.addServiceForm.get('totamt');
    const totinstallments = this.addServiceForm.get('totinstallments');
    const installmentAmount = this.addServiceForm.get('installmentAmount');
    const allowDiscount = this.addServiceForm.get('allowDiscount');
    const installmentsBegDate = this.addServiceForm.get('installmentsBegDate');

    const serviceType = this.employeeForm?.get('serviceType');
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
  //#region Delete operation and Modal Config
  openPopUpModal(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'yes') {
        this.onOkayClick();
      } else {
        this.location.back();
      }
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });

  }

  backToPreviousPage() {
    this.location.back();
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

  setDefaultServiceData() {
    console.log(this.serviceInformationJson)
    if (this.serviceInformationJson) {
      this.employeeForm?.patchValue({
        serviceType: this.serviceInformationJson.serviceTypeEnglishName,
        serviceSubType: this.serviceInformationJson.subServiceTypeEnglishName,
        serviceTypeId: this.serviceInformationJson.serviceTypeId,
        serviceSubTypeId: this.serviceInformationJson.subServiceTypeId,
        transDate: moment(new Date()).format("DD-MM-yyyy")
      })
      this.serviceArabicName = this.serviceInformationJson.serviceTypeArabicName;
      this.subServiceArabicName = this.serviceInformationJson.subServiceTypeArabicName;
    }
  }
  failResponse: any;
  SearchEmployee() {

    this.parentForm.reset();
    this.financialCalculationForm.reset();
    if (this.searchForm.value['employeeId'] == null) {
      this.searchForm.value['employeeId'] = 0;

    }
    this.selectServiceType = [];
    this.selectServiceSubType = [];
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { locationId: any; }) => obj.locationId);

    // To hide/show the financial calculation div
    this.isPFIdNull = false;
    this.isSearched = false;

    this.setDefaultServiceData();
    this.financialService.SearchEmployee(this.searchForm.value).subscribe((response: any) => {
      if (response.isSuccess == false) {
        this.failResponse = response;
        this.common.ifEmployeeExists = false;
        this.employeeForm?.reset();
        this.toastrService.error(response.message, 'Error');

        this.setDefaultServiceData()
      }
      else {
        // To display other Accordians
        this.isSearched = true;
        this.common.ifEmployeeExists = true;
        this.onServiceSubTypeChange(this.serviceInformationJson.serviceTypeId, this.serviceInformationJson.subServiceTypeId);
        this.showHideButton = false;
        this.showHide = false;
        this.showHideMessage = false;
        if((response.contractType == 1 || response.contractType == 2) && 
          (this.serviceInformationJson.subServiceTypeId==205 || this.serviceInformationJson.subServiceTypeId==204)){
          this.showHideButton = true;
        }
        // To check if Pf Id is already exists so will disable the control.

        // if (this.activatedRout.snapshot.paramMap.get('ServiceTypeId')) {
        //   this.employeeForm?.patchValue({
        //     serviceTypeId: JSON.parse(this.activatedRout.snapshot.paramMap.get('ServiceTypeId') || '{}'),
        //     serviceSubTypeId: JSON.parse(this.activatedRout.snapshot.paramMap.get('ServiceSubTypeId') || '{}'),
        //     discountType: 0,
        //     installmentsBegDate: 0,
        //     allowDiscountDefault: 0,
        //   })
        //   this.serviceTypeSelected = JSON.parse(this.activatedRout.snapshot.paramMap.get('ServiceTypeId') || '{}');
        //   this.onServiceTypeChange({ refId: 8 })
        //   setTimeout(() => {
        //     this.serviceSubTypeSelected = JSON.parse(this.activatedRout.snapshot.paramMap.get('ServiceSubTypeId') || '{}');
        //     this.selectedServiceSubType = JSON.parse(this.activatedRout.snapshot.paramMap.get('ServiceSubTypeId') || '{}');
        //   }, 1000)
        //   this.employeeForm?.get('serviceType')?.disable();
        //   this.employeeForm?.get('serviceSubType')?.disable();
        //   this.employeeForm?.get('transDate')?.disable();
        //   this.addServiceForm?.get('totamt')?.disable();
        //   this.addServiceForm?.get('allowDiscountAmount')?.disable();
        //   this.addServiceForm?.get('downPayment')?.disable();
        //   this.addServiceForm?.get('totalAmount')?.disable();
        //   this.addServiceForm?.get('installmentAmount')?.disable();
        //   this.addServiceForm?.get('totinstallments')?.disable();
        //   this.addServiceForm?.get('installmentsBegDate')?.disable();
        //   this.addServiceForm?.get('untilMonth')?.disable();
        //   this.addServiceForm?.get('searialNo')?.disable();
        //   this.addServiceForm?.get('pfId')?.disable();
        // }


        if (response.pfid) {
          this.isPfIdExists = true;
        }
        this.employeeForm?.patchValue({
          employeeId: response.employeeId,
          englishName: response.englishName,
          arabicName: response.arabicName,
          empGender: response.empGender,
          joinedDate: moment(response.joinedDate).format("DD-MM-yyyy"),
          empBirthday: new Date(response.empBirthday),
          mobileNumber: response.mobileNumber,
          empMaritalStatus: +response.empMaritalStatus,
          nationName: response.nationName,
          contractType: +response.contractType,
          subscriptionAmount: response.subscriptionAmount,
          subscriptionPaid: response.subscriptionPaid,
          lastSubscriptionPaid: response.lastSubscriptionPaid,
          subscriptionDueAmount: response.subscriptionDueAmount,
          subscriptionStatus: response.subscriptionStatus,
          terminationDate: response.terminationDate ? moment(response.terminationDate).format("DD-MM-yyyy") : '',
          endDate: response.endDate ? moment(response.endDate).format("DD-MM-yyyy") : '',
          employeeStatus: response.employeeStatus,
          isKUEmployee: response.isKUEmployee,
          isOnSickLeave: response.isOnSickLeave,
          isMemberOfFund: response.isMemberOfFund,
          CountryNameEnglish: response.countryNameEnglish,
          CountryNameArabic: response.countryNameArabic,
          employeePFId: response.pfid,
          employeeCID: response.empCidNum,
          employeeFormEmployeeId: response.employeeId,
          salary: response.salary,
          kinMobile: response.next2KinMobNumber,
          kinName: response.next2KinName,
        })
        this.addServiceForm.patchValue({
          pfId: response.pfid
        })
        if (response.allowDiscountDefault) {
          this.addServiceForm.get('allowDiscountAmount')?.disable();
        }
        this.common.PFId = response.pfid;
        this.common.subscribedDate = response.subscribedDate;
        this.common.terminationDate = response.terminationDate;
        // fill service type dropdown according to searched employee Id
        this.notSubscriber = false;
        this.financialService.GetServiceType(tenantId).subscribe((response: any) => {
          this.pfId = this.common.PFId;
          this.selectServiceType = response;
          if (this.common.PFId != null
            && this.common.subscribedDate == null
            && this.common.terminationDate == null) {
            // remove subscribe from servicetype & Subtype
            //if (result.trim()) {
            let index = this.selectServiceType.findIndex(x => x.refId == 1);
            if (index >= 0) {
              this.selectServiceType.splice(index, 1);
            }
            //}
            this.notSubscriber = true;
          } else if (this.common.PFId == null
            && this.common.subscribedDate == null
            && this.common.terminationDate == null) {
            this.selectServiceType = response;
            let arr = this.selectServiceType.filter(x => x.refId == 1)
            this.selectServiceType = arr;
            this.isSubscriber = true;
          }
        });
        this.employeeForm?.get('contractType')?.disable();
      }
    }, error => {
      if (error.status === 500) {
        this.toastrService.error('Please enter Employee Id or CID or PFId', 'Error');
      }
    });
  }
  // 
  SearchSponsor() {
    this.selectServiceType = [];
    this.selectServiceSubType = [];
    //
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { locationId: any; }) => obj.locationId);
    this.setDefaultServiceData();
    // To hide/show the financial calculation div
    this.isPFIdNull = false;
    this.isSearched = false;
    this.financialService.SearchSponsor(this.searchForm.value).subscribe((response: any) => {
      if (response.isSuccess == false) {
        this.common.ifEmployeeExists = false;
        this.toastrService.error(response.message, 'Error');
        this.employeeForm?.reset();
        this.setDefaultServiceData();
      } else {
        // To display other Accordians
        this.showHide=!this.showHide;
        this.showHideMessage = false;
        if(response.numberofsponsorships > 3){
          this.showHide=false;
          this.showHideMessage = true;
        }
        this.isSearched = true;
        this.common.ifEmployeeExists = true;
        this.employeeForm?.patchValue({
          employeeId: response.employeeId,
          englishName: response.englishName,
          arabicName: response.arabicName,
          empGender: response.empGender,
          joinedDate: moment(response.joinedDate).format("DD-MM-yyyy"),
          empBirthday: new Date(response.empBirthday),
          mobileNumber: response.mobileNumber,
          empMaritalStatus: +response.empMaritalStatus,
          nationName: response.nationName,
          contractType: +response.contractType,
          subscriptionAmount: response.subscriptionAmount,
          subscriptionPaid: response.subscriptionPaid,
          lastSubscriptionPaid: response.lastSubscriptionPaid,
          subscriptionDueAmount: response.subscriptionDueAmount,
          subscriptionStatus: response.subscriptionStatus,
          terminationDate: response.terminationDate ? moment(response.terminationDate).format("DD-MM-yyyy") : '',
          endDate: response.endDate ? moment(response.endDate).format("DD-MM-yyyy") : '',
          employeeStatus: response.employeeStatus,
          isKUEmployee: response.isKUEmployee,
          isOnSickLeave: response.isOnSickLeave,
          isMemberOfFund: response.isMemberOfFund,
          CountryNameEnglish: response.countryNameEnglish,
          CountryNameArabic: response.countryNameArabic,
          employeePFId: response.pfid,
          employeeCID: response.empCidNum,
          employeeFormEmployeeId: response.employeeId,
          salary: response.salary,
          kinMobile: response.next2KinMobNumber,
          kinName: response.next2KinName,
          SponserID: response.sponserId,
          SponserName: response.sponsername,
          NumberofSponsorships: response.numberofsponsorships,
          SponserRemarks: response.sponserremarks
        })
        this.addServiceForm.patchValue({
          pfId: response.pfid
        })
        this.common.PFId = response.pfid;
        this.common.subscribedDate = response.subscribedDate;
        this.common.terminationDate = response.terminationDate;
        // fill service type dropdown according to searched employee Id
        this.notSubscriber = false;
        this.financialService.GetServiceType(tenantId).subscribe((response: any) => {
          this.pfId = this.common.PFId;
          this.selectServiceType = response;

          if (this.common.PFId != null
            && this.common.subscribedDate == null
            && this.common.terminationDate == null) {
            // remove subscribe from servicetype & Subtype
            //if (result.trim()) {
            let index = this.selectServiceType.findIndex(x => x.refId == 1);
            if (index >= 0) {
              this.selectServiceType.splice(index, 1);
            }
            //}
            this.notSubscriber = true;
          } else if (this.common.PFId == null
            && this.common.subscribedDate == null
            && this.common.terminationDate == null) {
            this.selectServiceType = response;
            let arr = this.selectServiceType.filter(x => x.refId == 1)
            this.selectServiceType = arr;
            this.isSubscriber = true;
          }
        });
      }
    }, error => {
      if (error.status === 500) {
        this.toastrService.error('Please enter Employee Id or CID or PFId', 'Error');
      }
    });
  }
  SearchNewSubscriber() {
    // this.selectServiceType=[];
    // this.selectServiceSubType=[];
    //
    // this.employeeForm?.patchValue({
    //   employeeId: this.failResponse.employeeId,
    //   englishName: this.failResponse.englishName,
    //   arabicName: this.failResponse.arabicName,
    //   empGender: this.failResponse.empGender,
    //   joinedDate: moment(this.failResponse.joinedDate).format("DD-MM-yyyy"),
    //   empBirthday: new Date(this.failResponse.empBirthday),
    //   mobileNumber: this.failResponse.mobileNumber,
    //   empMaritalStatus: +this.failResponse.empMaritalStatus,
    //   nationName: this.failResponse.nationName,
    //   contractType: +this.failResponse.contractType,
    //   subscriptionAmount: this.failResponse.subscriptionAmount,
    //   subscriptionPaid: this.failResponse.subscriptionPaid,
    //   lastSubscriptionPaid: this.failResponse.lastSubscriptionPaid,
    //   subscriptionDueAmount: this.failResponse.subscriptionDueAmount,
    //   subscriptionStatus: this.failResponse.subscriptionStatus,
    //   terminationDate: this.failResponse.terminationDate ? moment(this.failResponse.terminationDate).format("DD-MM-yyyy") : '',
    //   endDate: this.failResponse.endDate ? moment(this.failResponse.endDate).format("DD-MM-yyyy") :  '',
    //   employeeStatus: this.failResponse.employeeStatus,
    //   isKUEmployee: this.failResponse.isKUEmployee,
    //   isOnSickLeave: this.failResponse.isOnSickLeave,
    //   isMemberOfFund: this.failResponse.isMemberOfFund,
    //   CountryNameEnglish: this.failResponse.countryNameEnglish,
    //   CountryNameArabic: this.failResponse.countryNameArabic,
    //   employeePFId: this.failResponse.pfid,
    //   employeeCID: this.failResponse.empCidNum,
    //   employeeFormEmployeeId: this.failResponse.employeeId,
    //   salary: this.failResponse.salary,
    //   kinMobile:this.failResponse.next2KinMobNumber,
    //   kinName:this.failResponse.next2KinName,
    // })
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { locationId: any; }) => obj.locationId);

    // To hide/show the financial calculation div
    this.isPFIdNull = false;
    this.isSearched = false;
    this.setDefaultServiceData();
    this.financialService.SearchNewSubscriber(this.searchForm.value).subscribe((response: any) => {
      if (response.isSuccess == false) {
        this.common.ifEmployeeExists = false;
        this.toastrService.error(response.message, 'Error');
        // this.employeeForm?.reset();
      } else {
        // To display other Accordians
        this.isSearched = true;

        this.common.ifEmployeeExists = true;
        console.log('search new subscriber', response);
        this.employeeForm?.patchValue({
          employeeId: response.employeeId,
          englishName: response.englishName,
          arabicName: response.arabicName,
          empGender: response.empGender,
          joinedDate: moment(response.joinedDate).format("DD-MM-yyyy"),
          empBirthday: new Date(response.empBirthday),
          mobileNumber: response.mobileNumber,
          empMaritalStatus: +response.empMaritalStatus,
          nationName: response.nationName,
          contractType: +response.contractType,
          subscriptionAmount: response.subscriptionAmount,
          subscriptionPaid: response.subscriptionPaid,
          lastSubscriptionPaid: response.lastSubscriptionPaid,
          subscriptionDueAmount: response.subscriptionDueAmount,
          subscriptionStatus: response.subscriptionStatus,
          terminationDate: response.terminationDate ? moment(response.terminationDate).format("DD-MM-yyyy") : '',
          endDate: response.endDate ? moment(response.endDate).format("DD-MM-yyyy") : '',
          employeeStatus: response.employeeStatus,
          isKUEmployee: response.isKUEmployee,
          isOnSickLeave: response.isOnSickLeave,
          isMemberOfFund: response.isMemberOfFund,
          CountryNameEnglish: response.countryNameEnglish,
          CountryNameArabic: response.countryNameArabic,
          employeePFId: response.pfid,
          employeeCID: response.empCidNum,
          employeeFormEmployeeId: response.employeeId,
          salary: response.salary,
          kinMobile: response.next2KinMobNumber,
          kinName: response.next2KinName,
        })
        this.addServiceForm.patchValue({
          pfId: response.pfid
        })

        this.common.PFId = response.pfid;
        this.common.subscribedDate = response.subscribedDate;
        this.common.terminationDate = response.terminationDate;
        // fill service type dropdown according to searched employee Id
        this.notSubscriber = false;
        this.financialService.GetServiceType(tenantId).subscribe((response: any) => {
          this.pfId = this.common.PFId;
          this.selectServiceType = response;
          // In case of existing employee/ subscriber...
          if (this.common.PFId != null
            && this.common.subscribedDate == null
            && this.common.terminationDate == null) {
            //
            let index = this.selectServiceType.findIndex(x => x.refId == 1);
            if (index >= 0) {
              this.selectServiceType.splice(index, 1);
            }
            //}
            this.notSubscriber = true;
          }
          // In case of new subscriber...
          else if (this.common.PFId == null
            && this.common.subscribedDate == null
            && this.common.terminationDate == null) {
            this.selectServiceType = response;
            let arr = this.selectServiceType.filter(x => x.refId == 1)
            this.selectServiceType = arr;
            this.isSubscriber = true;
            let salary = this.employeeForm?.controls['salary'].value;
            let amount = (salary / 100) * 1;
            this.addServiceForm?.get('totamt')?.setValue(amount);
          }

        });
      }
    }, error => {
      if (error.status === 500) {
        this.toastrService.error('Please enter Employee Id or CID or PFId', 'Error');
      }
    });
  }
  tAmountValue: number = 0;
  getFinancialCalculation() {
    // 
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { locationId: any; }) => obj.locationId);
    var date = this.employeeForm?.get('transDate')?.value;
    let transactionDate = date.split("-").reverse().join("-");
    //
    if (!this.searchForm.value.employeeId) {
      this.toastrService.error('Employee id not found', 'Error')
    } else if (transactionDate === 'Invalid date') {
      this.toastrService.error('Invalid transaction date', 'Error')
    }
    else if (this.employeeForm?.get('serviceType')?.value === 1) {
      this.toastrService.error('Invalid transaction date', 'Error')
    }
    else if (this.employeeForm?.get('serviceSubType')?.value === 2) {
      this.toastrService.error('Invalid transaction date', 'Error')
    } else {
      this.commonService.GetFinancialCalculationByEmployeeId(this.searchForm.value.employeeId, tenantId, locationId, transactionDate).subscribe((response: any) => {
        this.isPFIdNull = true;
        //
        var total = response.subscriptionPaidAmount - (response.subscriptionDueAmount + response.loanPendingAmount);
        //
        var financialAid = (total / 100) * 1;
        //
        var pfRevenue = (total / 100) * 10;
        //
        var grandTotal = total - (financialAid + pfRevenue);
        this.tAmountValue = grandTotal
        debugger;
        this.myTransId = response.myTransId
        this.financialCalculationForm.patchValue({
          noOfTransactions: response.noOfTransactions,
          subscriptionPaidAmount: response.subscriptionPaidAmount ? response.subscriptionPaidAmount.toFixed(3) : 0,
          subscriptionDueAmount: response.subscriptionDueAmount ? response.subscriptionDueAmount.toFixed(3) : 0,
          loanAmountBalance: response.balanceOfLoanAmount,
          financialAid: financialAid.toFixed(3),
          pfFundRevenue: pfRevenue.toFixed(3),
          adjustmentAmountRemarks: response.adjustmentAmountRemarks ? response.adjustmentAmountRemarks : 0,
          financialAidPercentage: response.financialAidPercentage,
          pfFundRevenuePercentage: response.pfFundRevenuePercentage,
          noOfSponsor: response.noOfSponsor,
          sponsorLoanPendingAmount: response.sponsorLoanPendingAmount,
          financialAidAmountRemarks: response.finAidAmountRemarks,
          payableAmount: response.payableAmount.toFixed(3),
          yearOfService: response.yearOfService,
          loanPendingAmount: response.loanPendingAmount.toFixed(3),
          totalAmount: grandTotal.toFixed(3),
          amountMinus: response.amountMinus ? response.amountMinus.toFixed(3) : 0,
          amountPlus: response.amountPlus ? response.amountPlus.toFixed(3) : 0,
          systemRemarks: response.systemRemarks,
          sponsorDueAmount: response.sponsorDueAmount,
          mytransid: response.myTransId,
          mySeq: 1,
          subscriptionInstalmentAmount: response.subscriptionInstalmentAmount,
          adjustmentAmount: response.adjustmentAmount ? response.adjustmentAmount : 0,
          DisplayPERIOD_CODE: '20230214',
          loanreceivedAmount: response.loanreceivedAmount,
          loanInstallmentAmount: response.loanInstallmentAmount
        })
      })

    }
  }
  calculateFinancialAmount() {
    let totalAmount = this.tAmountValue;
    let adjustmentAmount = this.financialCalculationForm.get('adjustmentAmount')?.value;
    let financialAidAmount = this.financialCalculationForm.get('financialAidAmount')?.value;
    let result = (totalAmount + (adjustmentAmount == '0.0' ? 0 : adjustmentAmount) + (financialAidAmount == '0.0' ? 0 : financialAidAmount));
    this.financialCalculationForm.get('totalAmount')?.setValue(result.toFixed(3));
  }
  openCashierInformation(content: any) {
    //
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { locationId: any; }) => obj.locationId);

    this.commonService.GetCashierInformationByEmployeeId(this.searchForm.value.employeeId, tenantId, locationId, this.myTransId).subscribe((response: any) => {
      this.cashierInformationForm.patchValue({
        payPer1: response.payPer1,
        draftNumber1: response.draftNumber1,
        draftDate1: moment(response.draftDate1).format("yyyy-MM-DD"),
        draftAmount1: response.draftAmount1,
        bankAccount1: response.bankAccount1,
        deliveryDate1: moment(response.deliveryDate1).format("yyyy-MM-DD"),
        receivedBy1: response.receivedBy1,
        deliveredBy1: response.deliveredBy1,
        payPer2: response.payPer2,
        draftNumber2: response.draftNumber2,
        draftDate2: moment(response.draftDate2).format("yyyy-MM-DD"),
        draftAmount2: response.draftAmount2,
        bankAccount2: response.bankAccount2,
        deliveryDate2: moment(response.deliveryDate2).format("yyyy-MM-DD"),
        receivedBy2: response.receivedBy2,
        deliveredBy2: response.deliveredBy2,
      })
    },
      error => {
        console.log(error);
      })
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', size: 'lg', backdrop: 'static' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;

    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });

  }
  onOkayClick() {
    // this.redirectTo(`/service-setup/service-details`);
    this.location.back();
  }
  redirectTo(uri: string) {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate([uri]));
  }

  //#region 
  // To enable/disable controls based on AllowDiscountDefault...
  enableDisableControls(isAllowDiscount: boolean) {
    if (isAllowDiscount) {
      // this.addServiceForm.get('downPayment')?.enable();
      // this.addServiceForm.get('allowDiscountAmount')?.enable();
      // this.addServiceForm.get('totinstallments')?.enable();
      this.addServiceForm.get('installmentAmount')?.enable();
      // this.addServiceForm.get('installmentsBegDate')?.enable();
      this.addServiceForm.get('untilMonth')?.enable();
      this.employeeForm?.get('serviceType')?.enable();
      this.employeeForm?.get('serviceSubType')?.enable();
    } else {
      // this.addServiceForm.get('downPayment')?.disable();
      this.addServiceForm.get('allowDiscountAmount')?.disable();
      // this.addServiceForm.get('totinstallments')?.disable();
      this.addServiceForm.get('installmentAmount')?.disable();
      // this.addServiceForm.get('installmentsBegDate')?.disable();
      this.addServiceForm.get('untilMonth')?.disable();
      this.employeeForm?.get('serviceType')?.disable();
      this.employeeForm?.get('serviceSubType')?.disable();
    }
    if (this.addServiceForm.get('serviceType')?.value == 1
      || this.addServiceForm.get('serviceSubType')?.value == 2) {
      this.addServiceForm.get('pfId')?.enable()
    }

    if (!this.mytransid) {
      this.employeeForm?.get('serviceType')?.enable();
      this.employeeForm?.get('serviceSubType')?.enable();
    }
  }
  // #endregion

}
