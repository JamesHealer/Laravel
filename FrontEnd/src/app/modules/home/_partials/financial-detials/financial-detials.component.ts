import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { CoaDto } from 'src/app/modules/models/CoaDto';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { CommonService } from 'src/app/modules/_services/common.service';

@Component({
  selector: 'app-financial-detials',
  templateUrl: './financial-detials.component.html',
  styleUrls: ['./financial-detials.component.scss']
})
export class FinancialDetialsComponent implements OnInit {
  @Input() parentFormGroup:FormGroup;
  @Input() accordialDetails: string;

  financialForm: FormGroup | undefined;
  accountsArray: FormArray<any>;
  finanacialFormGroup : FormGroup;
  @Input() formData: FormGroup | undefined;
  @Output() onFormGroupChange: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();

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
  lang: string;

  /*----------------------------------------------------*/
  //#endregion

  constructor(private dbCommonService: DbCommonService,
    private fb:FormBuilder,
    public common: CommonService,
    private toastr: ToastrService,
    ) { }
  //addFincancialForm: FormGroup;

  // Get account number...
  accountNo: string;
  //
  coaDto: CoaDto[] = [];
  
  ngOnInit(): void {
    //#region TO SETUP THE FORM LOCALIZATION    
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
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
    this.initializeForm();
    this.addGroupToParent();
    this.financialFormGrouping();
    console.log(this.parentFormGroup);
    if (this.parentFormGroup) {
      this.parentFormGroup.setControl('financialForm', this.financialForm);
      this.parentFormGroup.setControl('financialFormArray', this.accountsArray);
      this.parentFormGroup.setControl('finanacialFormGroup',this.finanacialFormGroup);
    }
  }

  financialFormGrouping(){
    this.finanacialFormGroup= this.fb.group({
      loanOPNotPaidAmount: [],
      loanOPAmount: [],
      subOPNotPaidAmount: [],
      subOPAmount: []
    })
  }

  initializeForm() {
    this.accountsArray = new FormArray<any>([]);
    //this.accountsArray.controls[0]['loanAct']
    this.accountsArray.push(
      new FormGroup({
          loanAct: new FormControl('', Validators.required),
          lblloanActNameInEnglish: new FormControl(''),
          lblloanActNameInArabic: new FormControl('')
        })
    );
    this.accountsArray.push(
      new FormGroup({
        hajjAct: new FormControl('', Validators.required),
        lblHajjActNameInEnglish: new FormControl(''),
        lblHajjActNameInArabic: new FormControl('')
      })
    );
    this.accountsArray.push(
      new FormGroup({
        persLoanAct: new FormControl('', Validators.required),
        lblPersLoanActNameInEnglish: new FormControl(''),
        lblPersLoanNameInArabic: new FormControl('')
      })
    );
    this.accountsArray.push(
      new FormGroup({
        consumerLoanAct: new FormControl('', Validators.required),
        lblConsumerLoanActNameInEnglish: new FormControl(''),
        lblConsumerLoanNameInArabic: new FormControl('')
      })
    );
    this.accountsArray.push(
      new FormGroup({
        otherAct1: new FormControl('', Validators.required),
        lblOtherAct1NameInEnglish: new FormControl(''),
        lblOtherAct1NameInArabic: new FormControl('')
      })
    );
    this.accountsArray.push(
      new FormGroup({
        otherAct2: new FormControl('', Validators.required),
        lblOtherAct2NameInEnglish: new FormControl(''),
        lblOtherAct2NameInArabic: new FormControl('')
      })
    );
    this.accountsArray.push(
      new FormGroup({
        otherAct3: new FormControl('', Validators.required),
        lblOtherAct3NameInEnglish: new FormControl(''),
        lblOtherAct3NameInArabic: new FormControl('')
      })
    );
    this.accountsArray.push(
      new FormGroup({
        otherAct4: new FormControl('', Validators.required),
        lblOtherAct4NameInEnglish: new FormControl(''),
        lblOtherAct4NameInArabic: new FormControl('')
      })
    );
    this.accountsArray.push(
      new FormGroup({
        otherAct5: new FormControl('', Validators.required),
        lblOtherAct5NameInEnglish: new FormControl(''),
        lblOtherAct5NameInArabic: new FormControl('')
      })
    );
    this.financialForm = new FormGroup({
      loanAct: new FormControl('', Validators.required),
      lblloanActNameInEnglish: new FormControl(''),
      lblloanActNameInArabic: new FormControl(''),

      hajjAct: new FormControl('', Validators.required),
      lblHajjActNameInEnglish: new FormControl(''),
      lblHajjActNameInArabic: new FormControl(''),

      persLoanAct: new FormControl('', Validators.required),
      lblPersLoanActNameInEnglish: new FormControl(''),
      lblPersLoanNameInArabic: new FormControl(''),

      consumerLoanAct: new FormControl('', Validators.required),
      lblConsumerLoanActNameInEnglish: new FormControl(''),
      lblConsumerLoanNameInArabic: new FormControl(''),

      otherAct1: new FormControl('', Validators.required),
      lblOtherAct1NameInEnglish: new FormControl(''),
      lblOtherAct1NameInArabic: new FormControl(''),

      otherAct2: new FormControl('', Validators.required),
      lblOtherAct2NameInEnglish: new FormControl(''),
      lblOtherAct2NameInArabic: new FormControl(''),

      otherAct3: new FormControl('', Validators.required),
      lblOtherAct3NameInEnglish: new FormControl(''),
      lblOtherAct3NameInArabic: new FormControl(''),

      otherAct4: new FormControl('', Validators.required),
      lblOtherAct4NameInEnglish: new FormControl(''),
      lblOtherAct4NameInArabic: new FormControl(''),

      otherAct5: new FormControl('', Validators.required),
      lblOtherAct5NameInEnglish: new FormControl(''),
      lblOtherAct5NameInArabic: new FormControl(''),
    })
  }
  fillWithText() {
    this.financialForm?.patchValue({
      child: 'This is an exmple.'
    });
  }

  clearText(): void {
    //this.financialForm.get('child').setValue('');
  }
  private addGroupToParent(): void {
    this.formData?.addControl('loanAct',  this.financialForm?.get('loanAct'));
    this.formData?.addControl('hajjAct',  this.financialForm?.get('hajjAct'));
    this.formData?.addControl('persLoanAct',  this.financialForm?.get('persLoanAct'));
    this.formData?.addControl('consumerLoanAct',  this.financialForm?.get('consumerLoanAct'));
    this.formData?.addControl('otherAct1',  this.financialForm?.get('otherAct1'));
    this.formData?.addControl('otherAct2',  this.financialForm?.get('otherAct2'));
    this.formData?.addControl('otherAct3',  this.financialForm?.get('otherAct3'));
    this.formData?.addControl('otherAct4',  this.financialForm?.get('otherAct4'));
    this.formData?.addControl('otherAct5',  this.financialForm?.get('otherAct5'));
    this.formData?.addControl('finanacialFormGroup', this.finanacialFormGroup);
    this.onFormGroupChange.emit(this.formData);
  }

  //#region Account Verification Code  
  verifyLoanAccount() {   
    this.accountNo = (<HTMLInputElement>document.getElementById("loanAct")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyLoanAct(this.accountNo).subscribe((response=>{
        this.coaDto = response;    
        if(this.coaDto.length != 0){
          this.financialForm?.controls.lblloanActNameInEnglish.setValue(this.coaDto[0].accountName);
          this.financialForm?.controls.lblloanActNameInArabic.setValue(this.coaDto[0].arabicAccountName);
          this.accountsArray?.controls[0]?.get('lblloanActNameInEnglish')?.setValue(this.coaDto[0].accountName);
          this.accountsArray?.controls[0]?.get('lblloanActNameInArabic')?.setValue(this.coaDto[0].arabicAccountName);
        }else{
          this.toastr.error('Account number not found');
        }
      }),error=>{
        console.log(error);
      });
    }else{
      this.toastr.error('Please enter a valid account number');
    }    
  }
  verifyHajjAccount() {   
    this.accountNo = (<HTMLInputElement>document.getElementById("hajjAct")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyHajjAct(this.accountNo).subscribe((response=>{
        this.coaDto = response;   
        if(this.coaDto.length != 0){
          this.financialForm?.controls.lblHajjActNameInEnglish.setValue(this.coaDto[0].accountName);
          this.financialForm?.controls.lblHajjActNameInArabic.setValue(this.coaDto[0].arabicAccountName);      
          this.accountsArray?.controls[1]?.get('lblHajjActNameInEnglish')?.setValue(this.coaDto[0].accountName);
          this.accountsArray?.controls[1]?.get('lblHajjActNameInArabic')?.setValue(this.coaDto[0].arabicAccountName);      
        }else{
          this.toastr.error('Account number not found');
        }       
        
      }),error=>{
        console.log(error);
      });
    }else{
      this.toastr.error('Please enter a valid account number');
    }    
  }
  verifyPerLoanAct() {   
    this.accountNo = (<HTMLInputElement>document.getElementById("persLoanAct")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyPerLoanAct(this.accountNo).subscribe((response=>{
        this.coaDto = response;        
        if(this.coaDto.length != 0){
          this.financialForm?.controls.lblPersLoanActNameInEnglish.setValue(this.coaDto[0].accountName);
          this.financialForm?.controls.lblPersLoanNameInArabic.setValue(this.coaDto[0].arabicAccountName);    
          this.accountsArray?.controls[2]?.get('lblPersLoanActNameInEnglish')?.setValue(this.coaDto[0].accountName);
          this.accountsArray?.controls[2]?.get('lblPersLoanNameInArabic')?.setValue(this.coaDto[0].arabicAccountName);    
        }else{
          this.toastr.error('Account number not found');
        }         
      }),error=>{
        console.log(error);
      });
    }else{
      this.toastr.error('Please enter a valid account number');
    }    
  }
  verifyConsumerLoanAct() {   
    this.accountNo = (<HTMLInputElement>document.getElementById("consumerLoanAct")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyConsumerLoanAct(this.accountNo).subscribe((response=>{
        this.coaDto = response;  
        if(this.coaDto.length != 0){
          this.financialForm?.controls.lblConsumerLoanActNameInEnglish.setValue(this.coaDto[0].accountName);
          this.financialForm?.controls.lblConsumerLoanNameInArabic.setValue(this.coaDto[0].arabicAccountName);  
          this.accountsArray?.controls[3]?.get('lblConsumerLoanActNameInEnglish')?.setValue(this.coaDto[0].accountName);
          this.accountsArray?.controls[3]?.get('lblConsumerLoanNameInArabic')?.setValue(this.coaDto[0].arabicAccountName);    
        }else{
          this.toastr.error('Account number not found');
        } 
      }),error=>{
        console.log(error);
      });
    }else{
      this.toastr.error('Please enter a valid account number');
    }    
  }
  verifyOtherAct1() {   
    this.accountNo = (<HTMLInputElement>document.getElementById("otherAct1")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyOtherAct1(this.accountNo).subscribe((response=>{
        this.coaDto = response;
        if(this.coaDto.length != 0){
          this.financialForm?.controls.lblOtherAct1NameInEnglish.setValue(this.coaDto[0].accountName);
          this.financialForm?.controls.lblOtherAct1NameInArabic.setValue(this.coaDto[0].arabicAccountName);    
          this.accountsArray?.controls[4]?.get('lblOtherAct1NameInEnglish')?.setValue(this.coaDto[0].accountName);
          this.accountsArray?.controls[4]?.get('lblOtherAct1NameInArabic')?.setValue(this.coaDto[0].arabicAccountName);    
        }else{
          this.toastr.error('Account number not found');
        }  
      }),error=>{
        console.log(error);
      });
    }else{
      this.toastr.error('Please enter a valid account number');
    }    
  }
  verifyOtherAct2() {   
    this.accountNo = (<HTMLInputElement>document.getElementById("otherAct2")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyOtherAct2(this.accountNo).subscribe((response=>{
        this.coaDto = response;
        if(this.coaDto.length != 0){
          this.financialForm?.controls.lblOtherAct2NameInEnglish.setValue(this.coaDto[0].accountName);
          this.financialForm?.controls.lblOtherAct2NameInArabic.setValue(this.coaDto[0].arabicAccountName);    
          this.accountsArray?.controls[5]?.get('lblOtherAct2NameInEnglish')?.setValue(this.coaDto[0].accountName);
          this.accountsArray?.controls[5]?.get('lblOtherAct2NameInArabic')?.setValue(this.coaDto[0].arabicAccountName);    
        }else{
          this.toastr.error('Account number not found');
        }          
        
      }),error=>{
        console.log(error);
      });
    }else{
      this.toastr.error('Please enter a valid account number');
    }    
  }
  verifyOtherAct3() {   
    this.accountNo = (<HTMLInputElement>document.getElementById("otherAct3")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyOtherAct2(this.accountNo).subscribe((response=>{
        this.coaDto = response;     
        if(this.coaDto.length != 0){
          this.financialForm?.controls.lblOtherAct3NameInEnglish.setValue(this.coaDto[0].accountName);
          this.financialForm?.controls.lblOtherAct3NameInArabic.setValue(this.coaDto[0].arabicAccountName);    
          this.accountsArray?.controls[6]?.get('lblOtherAct3NameInEnglish')?.setValue(this.coaDto[0].accountName);
          this.accountsArray?.controls[6]?.get('lblOtherAct3NameInArabic')?.setValue(this.coaDto[0].arabicAccountName);    
        }else{
          this.toastr.error('Account number not found');
        }    
        
      }),error=>{
        console.log(error);
      });
    }else{
      this.toastr.error('Please enter a valid account number');
    }    
  }
  verifyOtherAct4() {   
    this.accountNo = (<HTMLInputElement>document.getElementById("otherAct4")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyOtherAct4(this.accountNo).subscribe((response=>{
        this.coaDto = response;  
        if(this.coaDto.length != 0){
          this.financialForm?.controls.lblOtherAct4NameInEnglish.setValue(this.coaDto[0].accountName);
          this.financialForm?.controls.lblOtherAct4NameInArabic.setValue(this.coaDto[0].arabicAccountName);    
          this.accountsArray?.controls[7]?.get('lblOtherAct4NameInEnglish')?.setValue(this.coaDto[0].accountName);
          this.accountsArray?.controls[7]?.get('lblOtherAct4NameInArabic')?.setValue(this.coaDto[0].arabicAccountName);    
        }else{
          this.toastr.error('Account number not found');
        }        
        
      }),error=>{
        console.log(error);
      });
    }else{
      this.toastr.error('Please enter a valid account number');
    }    
  }  
  verifyOtherAct5() {   
    this.accountNo = (<HTMLInputElement>document.getElementById("otherAct5")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyOtherAct4(this.accountNo).subscribe((response=>{
        this.coaDto = response;  
        if(this.coaDto.length != 0){
          this.financialForm?.controls.lblOtherAct5NameInEnglish.setValue(this.coaDto[0].accountName);
          this.financialForm?.controls.lblOtherAct5NameInArabic.setValue(this.coaDto[0].arabicAccountName);     
          this.accountsArray?.controls[8]?.get('lblOtherAct5NameInEnglish')?.setValue(this.coaDto[0].accountName);
          this.accountsArray?.controls[8]?.get('lblOtherAct5NameInArabic')?.setValue(this.coaDto[0].arabicAccountName);    
        }else{
          this.toastr.error('Account number not found');
        }        
        
      }),error=>{
        console.log(error);
      });
    }else{
      this.toastr.error('Please enter a valid account number');
    }    
  }
  //#endregion
  
}
