import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { SelectBankAccount } from 'src/app/modules/models/SelectBankAccount';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { FinancialService } from 'src/app/modules/_services/financial.service';

@Component({
  selector: 'app-financial-draft',
  templateUrl: './financial-draft.component.html',
  styleUrls: ['./financial-draft.component.scss']
})
export class FinancialDraftComponent implements OnInit {

  //
  financialDraftForm: FormGroup;
  transId: number;
  employeeId: number
  //
  isFormSubmitted=false;
  //
  selectBankAccount$: Observable<SelectBankAccount[]>;
  
  constructor(private fb: FormBuilder,
    private dbCommonService: DbCommonService,
    private activatedRoute: ActivatedRoute,
    private financialService:FinancialService,
    private toastrService:ToastrService
  ) {
    this.activatedRoute.queryParams.subscribe(params => {
      this.transId = params['mytransId'];
      this.employeeId = params['employeeId'];
    });
  }

  ngOnInit(): void {
    // Get Tenant Id
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { locationId: any; }) => obj.locationId);
    const username = data.map((obj: { username: any; }) => obj.username);
    //
    this.initializeFinancialDraftForm();
    //
    this.selectBankAccount$ = this.dbCommonService.GetBankAccounts(tenantId, locationId);
    //
    this.dbCommonService.GetDraftInformationByEmployeeId(this.employeeId, tenantId, locationId, this.transId).subscribe((response: any) => {
      this.financialDraftForm.patchValue({
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
        transId:this.transId,
        employeeId:this.employeeId
      })
    }, error => {
      console.log(error);
    })
  }

  onSaveClick(){
    this.isFormSubmitted = true;
    if(this.financialDraftForm.valid){
      this.financialService.CreateCahierDelivery(this.financialDraftForm.value).subscribe((response:any)=>{
        if(response === 1){
          this.toastrService.success('Saved successfully','Success');
        }else{
          this.toastrService.error('Something went wrong','Error');
        }
      },error=>{
        console.log(error)
      })
    }    
  }
  initializeFinancialDraftForm() {
    this.financialDraftForm = this.fb.group({
      totalAmount: new FormControl('0'),
      bankAccount1: new FormControl('',Validators.required),
      draftNumber1: new FormControl('0'),
      draftDate1: new FormControl(null),
      receivedBy1: new FormControl(''),
      receivedDate1: new FormControl(null),
      deliveredBy1: new FormControl(),
      pfid: new FormControl(),
      empCidNum: new FormControl(),
      employeeId: new FormControl(),
      arabicName: new FormControl(),
      englishName: new FormControl(),
      deliveryDate1: new FormControl(null),
      transId:new FormControl('')
    })
  }
  onBankAccountSelect($event:any){    
    this.financialDraftForm.patchValue({
      bankDetails:$event.accountNumber
    })
  }
  // To access form controls...
  get financialDraftFrm() { return this.financialDraftForm.controls; }

}
