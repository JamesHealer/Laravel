import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { find, Observable } from 'rxjs';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { ServiceSetupDto } from 'src/app/modules/models/ServiceSetup/ServiceSetupDto';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { ServiceSetupService } from 'src/app/modules/_services/service-setup.service';
import { SelectServiceSubTypeDto } from 'src/app/modules/models/ServiceSetup/SelectServiceSubTypeDto';
import { SelectMasterServiceTypeDto } from 'src/app/modules/models/ServiceSetup/SelectMasterServiceTypeDto';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { filter } from 'lodash';
import { CommonService } from 'src/app/modules/_services/common.service';
import { SelectServiceTabDto } from 'src/app/modules/models/SelectServiceTabDto';

@Component({
  selector: 'app-add-service-setup',
  templateUrl: './add-service-setup.component.html',
  styleUrls: ['./add-service-setup.component.scss']
})
export class AddServiceSetupComponent implements OnInit {


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

  electronicFile1: File;
  electronicFile2: File;
  /*----------------------------------------------------*/
  //#endregion

  //
  serviceType$: any;
  //
  serviceSubType$: Observable<SelectServiceSubTypeDto[]>;
  //
  tab1$: Observable<SelectServiceTabDto[]>;
  //
  editServiceSetup$: Observable<ServiceSetupDto[]>;
  //SelectMasterServiceTypeDto
  masterServiceType$: any[] = [];
  //
  editServiceSetup: ServiceSetupDto[];

  masterServices: any;

  //
  parentForm: FormGroup;
  addServiceSetupForm: FormGroup;
  ///
  serviceId: any;
  //
  masterIds: any[] = [];
  selected: any;
  // Array for Minimum Month Of Service
  tabSelectionCount = [
    { id: "1", name: '1' },
    { id: "2", name: '2' },
    { id: "3", name: '3' },
  ]
  minimumMonthOfServices = [
    { id: "1", name: '1' },
    { id: "2", name: '2' },
    { id: "3", name: '3' },
    { id: "4", name: '4' },
    { id: "5", name: '5' },
    { id: "6", name: '6' },
    { id: "7", name: '7' },
    { id: "8", name: '8' },
    { id: "9", name: '9' },
    { id: "10", name: '10' },
    { id: "11", name: '11' },
    { id: "12", name: '12' },
    { id: "13", name: '13' },
    { id: "14", name: '14' },
    { id: "15", name: '15' },
    { id: "16", name: '16' },
    { id: "17", name: '17' },
    { id: "18", name: '18' },
    { id: "19", name: '19' },
    { id: "20", name: '20' },
    { id: "21", name: '21' },
    { id: "22", name: '22' },
    { id: "23", name: '23' },
    { id: "24", name: '24' },
    { id: "25", name: '25' },
    { id: "26", name: '26' },
    { id: "27", name: '27' },
    { id: "28", name: '28' },
    { id: "29", name: '29' },
    { id: "30", name: '30' },
    { id: "31", name: '31' },
    { id: "32", name: '32' },
    { id: "33", name: '33' },
    { id: "34", name: '34' },
    { id: "35", name: '35' },
    { id: "36", name: '36' },
  ];
  minInstallment = [
    { id: "1", name: "1" },
    { id: "2", name: "2" },
    { id: "3", name: "3" },
    { id: "4", name: "4" },
    { id: "5", name: "5" },
    { id: "6", name: "6" },
    { id: "7", name: "7" },
    { id: "8", name: "8" },
    { id: "9", name: "9" },
    { id: "10", name: "10" },
    { id: "11", name: "11" },
    { id: "12", name: "12" }
  ]
  maxInstallment = [
    { id: "1", name: "12" },
    { id: "2", name: "11" },
    { id: "3", name: "10" },
    { id: "4", name: "9" },
    { id: "5", name: "8" },
    { id: "6", name: "7" },
    { id: "7", name: "6" },
    { id: "8", name: "5" },
    { id: "9", name: "4" },
    { id: "10", name: "3" },
    { id: "11", name: "2" },
    { id: "12", name: "1" }
  ]
  //
  discountTypeArray = [
    { id: 1, name: "Percent" },
    { id: 2, name: "Fixed Amount" }
  ]

  showHide: boolean;
  DocumentLength: boolean=true;
  // Getting base URL of Api from enviroment.
  baseUrl = environment.KUPFApiUrl;
  constructor(private fb: FormBuilder,
    private commonDbService: DbCommonService,
    private commonService: CommonService,
    private setupService: ServiceSetupService,
    private toastr: ToastrService,
    private activatedRout: ActivatedRoute,
    private router: Router,
    private http: HttpClient) {
    this.setUpParentForm();
    // Getting record by from URL
    this.serviceId = this.activatedRout.snapshot.paramMap.get('serviceId');
  }

  lang: string;
  data_Service_Selected: number;
  ngOnInit(): void {
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    this.initializeForm();

    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'AddServiceSetup';

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
        }
      }

    }
    console.log(this.formBodyLabels)
    //#endregion

    //
    this.commonDbService.GetMaterServiceTypes().subscribe((result) => {
      this.masterServiceType$ = result;
    });
    this.commonDbService.GetServiceTab().subscribe((res: any) => {
      this.tab1$ = res
    });


    // Fillout all controls to update record.
    if (this.serviceId != null) {
      this.editServiceSetup$ = this.setupService.GetServiceSetupById(this.serviceId);
      this.editServiceSetup$.subscribe((response: any) => {
        if(response.allowDiscountPer){
          this.showHide = !this.showHide; 
        }
        this.parentForm.patchValue({
          addServiceSetupForm:
          {
            serviceId: response.serviceId,
            serviceName1: response.serviceName1,
            serviceName2: response.serviceName2,
            allowedNonEmployes: response.allowedNonEmployes,
            serviceType: +response.serviceType,
            serviceSubType: +response.serviceSubType,
            minMonthsService: response.minMonthsService,
            minInstallment: response.minInstallment,
            maxInstallment: response.maxInstallment,
            frozen: response.frozen,
            previousEmployees: response.previousEmployees,
            masterServiceId: response.masterServiceId,
            allowDiscountPer: response.allowDiscountPer,
            allowDiscountAmount: response.allowDiscountAmount,
            discountType: response.discountType,
            tab1: +response.tab1,
            tab2: +response.tab2,
            tab3: +response.tab3,
            tab4: +response.tab4,
            tab5: +response.tab5,
            tab6: +response.tab6,
            allowSponser: response.allowSponser > 0,
            documentsCount: response.documentsCount
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
          editorForm: {
            englishHtml: response.englishHTML || {},
            arabicHtml: response.arabicHTML || {},
            englishWebPageName: response.englishWebPageName,
            arabicWebPageName: response.arabicWebPageName
          },
          electronicForm: {
            electronicForm1: response.electronicForm1,
            electronicForm1URL: response.electronicForm1URL,
            electronicForm2: response.electronicForm2,
            electronicForm2URL: response.electronicForm2URL,
          }
        });

        //Filling service Types
        this.masterIds = response.masterServiceId.split(',');
        let masterServiceNumberArray = this.masterIds.map(Number);
        this.parentForm.get('addServiceSetupForm')?.patchValue({
          masterServiceId: masterServiceNumberArray
        })
       
        this.commonDbService.GetServiceTypeByMasterIds(this.masterIds).subscribe((resp: any) => {
          this.serviceType$ = resp
        });

        // Filling service Sub Types
        this.commonDbService.GetServiceSubTypes(response.serviceType).subscribe((res: any) => {
          this.serviceSubType$ = res
        });
          
        
      }, error => {
        console.log(error);
      })
    }
  }

  setUpParentForm() {
    this.parentForm = this.fb.group({});
  }

  initializeForm() {
    this.addServiceSetupForm = this.fb.group({
      serviceId: new FormControl('', Validators.required),
      serviceName1: new FormControl('', Validators.required),
      serviceName2: new FormControl('', Validators.required),
      allowedNonEmployes: new FormControl('', Validators.required),
      masterServiceId: new FormControl('', Validators.required),
      serviceSubType: new FormControl('', Validators.required),
      serviceType: new FormControl('', Validators.required),
      minMonthsService: new FormControl('', Validators.required),
      minInstallment: new FormControl('', Validators.required),
      maxInstallment: new FormControl('', Validators.required),
      frozen: new FormControl('', Validators.required),
      previousEmployees: new FormControl('', Validators.required),
      allowDiscountPer: new FormControl(''),
      discountType: new FormControl(''),
      allowDiscountAmount: new FormControl('0.0'),
      tab1: new FormControl(''),
      tab2: new FormControl(''),
      tab3: new FormControl(''),
      tab4: new FormControl(''),
      tab5: new FormControl(''),
      tab6: new FormControl(''),
      allowSponser: [false],
      documentsCount: []
    })
    this.parentForm.setControl('addServiceSetupForm', this.addServiceSetupForm);
  }
  onfileSelect1Event(val: any) {
    this.electronicFile1 = val;
  }
  onfileSelect2Event(val: any) {
    this.electronicFile2 = val;
  }
  addServiceSetup() {
    let arr = this.addServiceSetupForm?.controls['masterServiceId'];

    this.addServiceSetupForm.patchValue({
      masterServiceId: arr.value.toString()
    });

    // Get Tenant Id
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);

    //  TO CONVER OBJECT ARRAY AS SIMPLE ARRAY. 
    let formData = {
      ...this.parentForm.value.addServiceSetupForm,
      ...this.parentForm.value.approvalDetailsForm,
      ...this.parentForm.value.financialForm,
      tenentID: tenantId[0], cruP_ID: 0
    }

    if(!formData.allowDiscountPer){
      formData.discountType = null;
      formData.allowDiscountAmount = 0;
    }
    formData.allowSponser = formData.allowSponser ? 1 : 0;

    // const finalformData = new FormData();

    // finalformData.append('File1', this.electronicFile1);
    // finalformData.append('File2', this.electronicFile2);
    // Object.keys(formData).forEach(key => finalformData.append(key, formData[key]));

    if (!this.serviceId) {
      this.setupService.AddServiceSetup(formData).subscribe({
        next: () => {
          this.toastr.success('Saved successfully', 'Success');
          this.parentForm.reset();
          this.parentForm.get('addServiceSetupForm')?.patchValue({
            allowDiscountPer: '',
            allowDiscountAmount: '0.0',
            serviceId: ''
          });
          this.parentForm.get('approvalDetailsForm')?.patchValue({
            approvedDate1: '',
            approvedDate2: '',
            approvedDate3: '',
            approvedDate4: '',
            approvedDate5: ''
          });
        },
        error: (error) => {
          if (error.status === 500) {
            this.toastr.error('Duplicate value found', 'Error');
          }
        }
      });
    } else {

      this.setupService.UpdateServiceSetup(formData).subscribe((res: any) => {
        console.log(res);
        this.toastr.success('Updated successfully', 'Success');
        this.router.navigateByUrl('/service-setup/service-setup-details')
        }, error => {
          if (error.status === 500) {
            this.toastr.error('Something went wrong', 'Error');
          }
      });

      // this.http.put(this.baseUrl + `ServiceSetup/EditServiceSetup`, finalformData).subscribe({
      //   next: () => {
      //     this.toastr.success('Updated successfully', 'Success');
      //     //this.parentForm.reset();
      //     this.router.navigateByUrl('/service-setup/service-setup-details')
      //   },
      //   error: (error) => {
      //     if (error.status === 500) {
      //       this.toastr.error('Something went wrong', 'Error');
      //     }
      //   }
      // });
    }
  }

  allowDiscountPerChangeStatus(event: Event) {
    const isChecked = (<HTMLInputElement>event.target).checked;
    this.showHide = !this.showHide;
  }

  DocumentsCountLength() {
    let tempformData = {
      ...this.parentForm.value.addServiceSetupForm,
      ...this.parentForm.value.approvalDetailsForm,
      ...this.parentForm.value.financialForm 
    }

    this.DocumentLength = true;
    
    if(tempformData.documentsCount>5){
    this.DocumentLength = !this.DocumentLength;
    }
    
  }
 
  selection: any;
  onServiceTypeChange(switchNo: any) {
    //
    this.commonDbService.GetServiceSubTypes(switchNo).subscribe((response: any) => {
      this.serviceSubType$ = response
    });

  }
  onMasterServiceChange(e: any[]) {
    this.masterIds = [];
    for (let i = 0; i < e.length; i++) {
      this.masterIds.push(e[i].refId)
    }
    // Filling ServiceTypes against MasterIds.
    this.commonDbService.GetServiceTypeByMasterIds(this.masterIds).subscribe((response: any) => {
      this.serviceType$ = response
    });
  }

}
