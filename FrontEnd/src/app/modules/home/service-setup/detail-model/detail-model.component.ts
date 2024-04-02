import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { CommonService } from 'src/app/modules/_services/common.service';
import { EmployeeService } from 'src/app/modules/_services/employee.service';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';

@Component({
  selector: 'app-detail-model',
  templateUrl: './detail-model.component.html',
  styleUrls: ['./detail-model.component.scss']
})
export class DetailModelComponent implements OnInit {

  @Input() public data:any;
  modalLabels: any = [];
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
  employeeDetailsform: any;
  financialData: any;
  sponserDataArray : any;
  sponserData: any;
  financialDetails: any;
  approvalDetails: any;
  currentUserId: any;
  crupId: any;
  lang: any = '';
  tenentId: any;
  locationId: any;
  employeeActivityLog: any;
  closeResult: string = '';

  constructor(
    private modalService: NgbModal,
    private fb:FormBuilder,
    private financialService: FinancialService,
    private employeeService: EmployeeService,
    private commonService: CommonService
  ) { 
    var userValue = JSON.parse(localStorage.getItem("user")!);
    this.tenentId = userValue.map((obj: { tenantId: any; }) => obj.tenantId);
    this.locationId = userValue.map((obj: { locationId: any; }) => obj.locationId);
  }

  ngOnInit(): void {
    console.log(this.data);
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    this.currentUserId = localStorage.getItem('user');

    //#region TO SETUP THE FORM LOCALIZATION
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'ManagerApprovals';

    var modalId = 'voucherModal'
    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {

      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {
        if (labels.formID == modalId) {          
          const jsonFormTitleDTLanguage = labels.formTitleDTLanguage.reduce((result: any, element) => {
            result[element.labelId] = element;
            return result;
          }, {})
          this.modalLabels.push(jsonFormTitleDTLanguage);
        }
      }
      console.log(this.modalLabels);
    }

    this.employeeDetailsform = this.fb.group({
      employeeId: new FormControl(''),
      englishName: new FormControl(''),
      arabicName: new FormControl(''),
      empWorkEmail: new FormControl(''),
      mobileNumber: new FormControl(''),
      empGender: new FormControl(''),
      empMaritalStatus: new FormControl(''),
      departmentName: new FormControl(''),
      jobTitleName: new FormControl(''),
      //
      salary: new FormControl(''),
      joinedDate: new FormControl(''),
      empStatus: new FormControl(''),
      subscription_status: new FormControl(''),
      subscriptionDate: new FormControl(null),
      terminationId: new FormControl(''),
      terminationDate: new FormControl(''),
      termination: new FormControl(''),
      totalServices: new FormControl('0.00'),
      isMemberOfFund: new FormControl(''),
      empBirthday: new FormControl(''),
      next2KinName: new FormControl(''),
      next2KinMobNumber: new FormControl(''),
      userId: new FormControl(''),
      deviceId: new FormControl(''),
      imageUrl: new FormControl(''),
    })

    this.openContactModal(this.data.employeeId, this.data.data)
  }

  openContactModal(event: any, crup_id: any) {
    this.commonService.employeeId = event  //
    this.crupId = crup_id.crupId;
    this.employeeService.GetEmployeeById(event).subscribe((response: any) => {
      if (response) {
        this.employeeDetailsform.patchValue({
          employeeId: response.employeeId,
          englishName: response.englishName,
          arabicName: response.englishName,
          empWorkEmail: response.empWorkEmail,
          mobileNumber: response.mobileNumber,
          empGender: response.empGender,
          empMaritalStatus: response.empMaritalStatus,
          departmentName: response.departmentName,
          jobTitleName: response.jobTitleName,
          salary: response.salary,
          imageUrl: response.imageUrl,
          joinedDate: response.joinedDate ? moment(response.joinedDate).format("DD-MM-YYYY") : '',
          empStatus: response.empStatus,
          subscription_status: response.subscription_status,
          subscriptionDate: response.subscriptionDate ? moment(response.subscriptionDate).format("DD-MM-YYYY") : '',
          terminationId: response.terminationId,
          terminationDate: response.terminationDate ? moment(response.terminationDate).format("DD-MM-YYYY") : '',
          termination: response.termination,
          totalServices: response.totalServices,
          isMemberOfFund: response.isMemberOfFund,
          empBirthday: response.empBirthday ? moment(response.empBirthday).format("DD-MM-YYYY") : '',
          next2KinName: response.next2KinName,
          next2KinMobNumber: response.next2KinMobNumber,
          userId: response.userId,
          deviceId: response.deviceId,
          crupId: response.cruP_ID
        });
      }
    }, error => {
      console.log(error);
    });
    console.log("jp new",this.employeeDetailsform);
    type sponserInfo = {
      sponserId: number;
      sponserName: string;
   };
    //
    this.financialService.GetServiceApprovalsByEmployeeId(this.commonService.employeeId).subscribe((resp: any) => {
      if (resp) {
        this.financialData = resp;
        
        let tempArr = Array<sponserInfo>();
        var tempVar =  Object();
        for (var element of  this.financialData) {
          console.log("Element",element);
          tempVar.sponserId= element.sponserId;
          tempVar.sponserName= element.sponserName;
          itemExist : Boolean;
          let itemExist = false;
          for (var i = 0; i < tempArr.length; i++)
          {
            if (tempArr[i].sponserId ==element.sponserId)
                {
                  itemExist = true;
                }
          }
          if (itemExist==false)
            tempArr.push(tempVar);
          this.sponserDataArray =tempArr
     }
     console.log("sponser array",this.sponserDataArray);
      }
    }, error => {
      console.log(error);
    })
    //
    this.financialService.GetServiceApprovalsByEmployeeIdForManager(this.commonService.employeeId, this.tenentId, this.locationId).subscribe((response: any) => {
      this.approvalDetails = response;
    }, error => {
      console.log(error);
    });
    //
    this.financialService.GetEmployeeActivityLog(this.crupId, this.tenentId, this.locationId).subscribe((response: any) => {
      this.employeeActivityLog = response;

    }, error => {
      console.log(error);
    })

    // this.modalService.open({ ariaLabelledBy: 'modal-basic-title', modalDialogClass: 'modal-lg' }).result.then((result) => {
    //   this.closeResult = `Closed with: ${result}`;
    // }, (reason:any) => {
    //   this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    // });
  }

  // private getDismissReason(reason: any): string {
  //   if (reason === ModalDismissReasons.ESC) {
  //     return 'by pressing ESC';
  //   } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
  //     return 'by clicking on a backdrop';
  //   } else {
  //     return `with: ${reason}`;
  //   }
  // }

  openServiceDetailsModal(event: any) {
    this.financialService.GetServiceApprovalDetailByTransId(event.target.id).subscribe((response: any) => {
      if (response) {
        this.financialDetails = response;
      }
    })
  }

  dismissModal(){
    this.modalService.dismissAll();
  }

}
