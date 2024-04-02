import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CommonService } from 'src/app/modules/_services/common.service';
import { EmployeeService } from 'src/app/modules/_services/employee.service';
import { FinancialService } from 'src/app/modules/_services/financial.service';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.scss']
})
export class ContactDetailsComponent implements OnInit {

  closeResult: string = '';
  //
  contactDetials:FormGroup;
  employeeData:any;
  financialData:any
  financialDetails:any;
  serviceType:any;
  subServiceType:any;
  lang:any;
  employeeDetailsform:FormGroup;
  constructor(
    private modalService: NgbModal,
    private fb: FormBuilder,
    private employeeService:EmployeeService,
    public commonService: CommonService,
    private financialService:FinancialService) {}

  ngOnInit(): void {
    this.lang = localStorage.getItem('lang');
    // 
    this.initEmployeeForm();
   
    //  this.employeeService.GetEmployeeById(this.commonService.employeeId).subscribe((response: any) => {
    //   if(response){        
    //     this.employeeData = response;
    //   }
    // });
    this.financialService.GetServiceApprovalsByEmployeeId(this.commonService.employeeId).subscribe((resp:any)=>{
      if(resp){
        //console.log(resp);
        this.financialData = resp;
      }
    }) 
    
  }
  initEmployeeForm(){
    this.employeeDetailsform = this.fb.group({
      employeeId:new FormControl(''),
      englishName:new FormControl(''),
      arabicName:new FormControl(''),
      empWorkEmail:new FormControl(''),
      mobileNumber:new FormControl(''),
      empGender:new FormControl(''),
      empMaritalStatus:new FormControl(''),
      departmentName:new FormControl(''),
      jobTitleName:new FormControl(''),
    })
  }
  openServiceDetailsModal(event: any){
    this.financialService.GetServiceApprovalDetailByTransId(event.target.id).subscribe((response:any) =>{
      if(response){
        this.financialDetails = response;
      }
    })    
  }

  open(content:any) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title',modalDialogClass:'modal-lg'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  } 
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }
}
