import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CoaDto } from 'src/app/modules/models/CoaDto';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';

@Component({
  selector: 'app-edit-financial-details',
  templateUrl: './edit-financial-details.component.html',
  styleUrls: ['./edit-financial-details.component.scss']
})
export class EditFinancialDetailsComponent implements OnInit {
  financialForm: FormGroup | undefined;
  @Input() formData: FormGroup | undefined;
  @Output() onFormGroupChange: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();
  @Output()
  formReady = new EventEmitter<FormGroup>();
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
  // Get account number...
  accountNo: string;
  //
  coaDto: CoaDto[] = [];
  constructor(private dbCommonService: DbCommonService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.initializeForm();
    this.addGroupToParent();
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'FinancialDetails';

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
  }
  initializeForm() {
    this.financialForm = new FormGroup({
      loanAct: new FormControl('', Validators.required),
      hajjAct: new FormControl('', Validators.required),
      persLoanAct: new FormControl('', Validators.required),
      consumerLoanAct: new FormControl('', Validators.required),
      otherAct1: new FormControl('', Validators.required),
      otherAct2: new FormControl('', Validators.required),
      otherAct3: new FormControl('', Validators.required),
      otherAct4: new FormControl('', Validators.required),
      otherAct5: new FormControl('', Validators.required)
    })
  }
  //#region Account Verification Code  
  verifyLoanAccount() {   
    this.accountNo = (<HTMLInputElement>document.getElementById("loanAct")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyLoanAct(this.accountNo).subscribe((response=>{
        this.coaDto = response;    
        if(this.coaDto.length != 0){
          (<HTMLInputElement>document.getElementById("lblloanActNameInEnglish")).innerHTML = this.coaDto[0].accountName;  
          (<HTMLInputElement>document.getElementById("lblloanActNameInArabic")).innerHTML = this.coaDto[0].arabicAccountName;        
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
          (<HTMLInputElement>document.getElementById("lblHajjActNameInEnglish")).innerHTML = this.coaDto[0].accountName;  
          (<HTMLInputElement>document.getElementById("lblHajjActNameInArabic")).innerHTML = this.coaDto[0].arabicAccountName;        
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
        (<HTMLInputElement>document.getElementById("lblPersLoanActNameInEnglish")).innerHTML = this.coaDto[0].accountName;  
        (<HTMLInputElement>document.getElementById("lblPersLoanNameInArabic")).innerHTML = this.coaDto[0].arabicAccountName;        
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
    this.accountNo = (<HTMLInputElement>document.getElementById("consumerLoan")).value;    
    if(this.accountNo != ''){
      this.dbCommonService.VerifyConsumerLoanAct(this.accountNo).subscribe((response=>{
        this.coaDto = response;  
        if(this.coaDto.length != 0){
          (<HTMLInputElement>document.getElementById("lblConsumerLoanActNameInEnglish")).innerHTML = this.coaDto[0].accountName;  
          (<HTMLInputElement>document.getElementById("lblConsumerLoanNameInArabic")).innerHTML = this.coaDto[0].arabicAccountName;        
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
          (<HTMLInputElement>document.getElementById("lblOtherAct1NameInEnglish")).innerHTML = this.coaDto[0].accountName;  
          (<HTMLInputElement>document.getElementById("lblOtherAct1NameInArabic")).innerHTML = this.coaDto[0].arabicAccountName;        
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
          (<HTMLInputElement>document.getElementById("lblOtherAct2NameInEnglish")).innerHTML = this.coaDto[0].accountName;  
          (<HTMLInputElement>document.getElementById("lblOtherAct2NameInArabic")).innerHTML = this.coaDto[0].arabicAccountName;        
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
          (<HTMLInputElement>document.getElementById("lblOtherAct3NameInEnglish")).innerHTML = this.coaDto[0].accountName;  
          (<HTMLInputElement>document.getElementById("lblOtherAct3NameInArabic")).innerHTML = this.coaDto[0].arabicAccountName;        
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
          (<HTMLInputElement>document.getElementById("lblOtherAct4NameInEnglish")).innerHTML = this.coaDto[0].accountName;  
          (<HTMLInputElement>document.getElementById("lblOtherAct4NameInArabic")).innerHTML = this.coaDto[0].arabicAccountName;        
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
          (<HTMLInputElement>document.getElementById("lblOtherAct5NameInEnglish")).innerHTML = this.coaDto[0].accountName;  
          (<HTMLInputElement>document.getElementById("lblOtherAct5NameInArabic")).innerHTML = this.coaDto[0].arabicAccountName;        
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
    this.onFormGroupChange.emit(this.formData);
  }
}
