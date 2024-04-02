import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { CashierApprovalDto } from 'src/app/modules/models/FinancialService/CashierApprovalDto';
import { ReturnApprovalsByEmployeeId } from 'src/app/modules/models/FinancialService/ReturnApprovalsByEmployeeId';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { RefTableDto } from 'src/app/modules/models/ReferenceDetails/RefTableDto';
import { ReturnServiceApprovals } from 'src/app/modules/models/ReturnServiceApprovals';
import { CommonService } from 'src/app/modules/_services/common.service';
import { EmployeeService } from 'src/app/modules/_services/employee.service';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { Pagination } from 'src/app/modules/models/pagination';
import { UserParams } from 'src/app/modules/models/UserParams';
import { DetailModelComponent } from '../detail-model/detail-model.component';

@Component({
  selector: 'app-approval-management',
  templateUrl: './approval-management.component.html',
  styleUrls: ['./approval-management.component.scss']
})
export class ApprovalManagementComponent implements OnInit {

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

  //#region
  // To display table column headers
  columnsToDisplay: string[] = ['action', 'transId', 'employeeName', 'serviceType', 'totalInstallment', 'amount', 'status'];

  // Getting data as abservable.
  returnServiceApprovals$: Observable<CashierApprovalDto[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  returnServiceApprovals: MatTableDataSource<CashierApprovalDto> = new MatTableDataSource<any>([]);

  // Paginator
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  // Sorting
  @ViewChild(MatSort) sort!: MatSort;

  // Hide footer while loading.
  isLoadingCompleted: boolean = false;

  // Incase of any error will display error message.
  dataLoadingStatus: string = '';

  // True of any error
  isError: boolean = false;

  // formGroup
  formGroup: FormGroup;

  // Search Term
  searchTerm: string = '';
  //#endregion

  //
  approveServiceForm: FormGroup;

  //
  rejectServiceForm: FormGroup;

  lang: any = '';
  closeResult: string = '';
  currentUserId: any;
  //
  isFormSubmitted = false;
  rejectionType$: Observable<RefTableDto[]>;
  employeeId: any;
  tenentId: any;
  locationId: any
  periodCode: any;
  prevPeriodCode: any;
  username: any;
  userId: any;
  employeeDetailsform: FormGroup;
  financialData: any;
  financialDetails: any;
  approvalDetails: any;
  employeeActivityLog: any;
  crupId: any;
  isShowAllChecked: boolean = false;
  userParams: UserParams;
  pagination: Pagination;
  ButtonShowHide: boolean;
  //
  currentPage = 0;
  totalRows = 0;
  pageSizeOptions: number[] = [10, 20, 50, 100];
  manageApprovalHeaders: any = {};

  constructor(
    private modalService: NgbModal,
    private financialService: FinancialService,
    private fb: FormBuilder,
    private datepipe: DatePipe,
    private toastrService: ToastrService,
    private employeeService: EmployeeService,
    private commonService: CommonService) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl("")
    });
    var data = JSON.parse(localStorage.getItem("user")!);
    this.tenentId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    this.locationId = data.map((obj: { locationId: any; }) => obj.locationId);
    this.periodCode = data.map((obj: { periodCode: any; }) => obj.periodCode);
    this.prevPeriodCode = data.map((obj: { prevPeriodCode: any; }) => obj.prevPeriodCode);
    this.username = data.map((obj: { username: any; }) => obj.username);
    this.userId = data.map((obj: { userId: any; }) => obj.userId);

    this.userParams = this.financialService.getUserParams();
  }
  modalLabels: any = [];
  ngOnInit(): void {
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

        if (labels.formID == this.formId) {

          this.formHeaderLabels.push(labels);

          const jsonFormTitleDTLanguage = labels.formTitleDTLanguage.reduce((result: any, element) => {
            result[element.labelId] = element;
            return result;
          }, {})
          this.formBodyLabels.push(jsonFormTitleDTLanguage);
        }

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
    //#endregion

    // Get Data...
    this.loadData(0, this.isShowAllChecked);

    //
    this.initApproveServiceForm();
    //
    this.initRejectionServiceForm();
    //
    this.rejectionType$ = this.financialService.GetRejectionType();
    //
    this.initEmployeeForm();

  }

  selectedBtn:string = 'jvView';
  selectedId:number;
  actionBtnSelect(val:string, id:number){
    this.selectedBtn = val;
    this.selectedId = id;
  }

  initApproveServiceForm() {
    this.approveServiceForm = this.fb.group({
      mytransId: new FormControl(''),
      userId: new FormControl(''),
      approvalDate: new FormControl(''),
      entryDate: new FormControl(''),
      entryTime: new FormControl(''),
      approvalRemarks: new FormControl('', Validators.required),
      currentDateTime: new FormControl(this.datepipe.transform((new Date), 'h:mm:ss dd/MM/yyyy')),
      serviceType: new FormControl(''),
      serviceSubType: new FormControl(''),
      totamt: new FormControl(''),
      tenentId: new FormControl(''),
      locationId: new FormControl(''),
      englishName: new FormControl(''),
      arabicName: new FormControl(''),
    })
  }

  openDetailsModal(id:number, data:any){
    const modalref = this.modalService.open(DetailModelComponent, { size: 'lg', backdrop: 'static', keyboard: false});
    modalref.componentInstance.data = {employeeId: id, data: data};
  }

  initRejectionServiceForm() {
    this.rejectServiceForm = this.fb.group({
      mytransId: new FormControl(''),
      userId: new FormControl(''),
      approvalDate: new FormControl(''),
      entryDate: new FormControl(''),
      entryTime: new FormControl(''),
      rejectionRemarks: new FormControl('', Validators.required),
      currentDateTime: new FormControl(this.datepipe.transform((new Date), 'h:mm:ss dd/MM/yyyy')),
      rejectionType: new FormControl('', Validators.required),
      tenentId: new FormControl(''),
      locationId: new FormControl(''),
    })
  }
  initEmployeeForm() {
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
    })
  }

  onShowAllChange(event: any) {
    this.loadData(this.paginator.pageIndex, event.target.checked)
    this.isShowAllChecked = event.target.checked;
  }
  // Get Data...
  loadData(pageIndex: any, isShowAll: boolean) {
    this.userParams.pageNumber = pageIndex + 1;
    this.financialService.setUserParams(this.userParams);

    this.financialService.GetServiceApprovals(this.userParams, this.periodCode, this.tenentId, this.locationId, isShowAll, this.formGroup.value.searchTerm).subscribe((response: any) => {
      this.manageApprovalHeaders = JSON.parse(response.headers.get('pagination'));
      this.returnServiceApprovals = new MatTableDataSource<CashierApprovalDto>(response.body);
      this.returnServiceApprovals.paginator = this.paginator;
      this.returnServiceApprovals.sort = this.sort;
      this.isLoadingCompleted = true;
      setTimeout(() => {
        console.log(this.paginator);
        this.paginator.pageIndex = pageIndex;
        this.paginator.length = this.manageApprovalHeaders.totalItems;
      });
    }, error => {
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }
  get approvalForm() { return this.approveServiceForm.controls; }
  get rejectionForm() { return this.rejectServiceForm.controls; }

  openContactModal(content: any, event: any, crup_id: any) {
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
    //
    this.financialService.GetServiceApprovalsByEmployeeId(this.commonService.employeeId).subscribe((resp: any) => {
      if (resp) {
        this.financialData = resp;
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

    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', modalDialogClass: 'modal-lg' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
  // Approve service...
  openApproveServiceModal(content: any, event: any,ShowHide:boolean) {
    let currentDate = this.datepipe.transform((new Date));
    this.isFormSubmitted = true;
    this.financialService.GetServiceApprovalsByTransIdAsync(this.tenentId, this.locationId, event).subscribe((response: any) => {
      if (response) {
        if(ShowHide){
          this.ButtonShowHide = true;
          this.approveServiceForm.patchValue({
            mytransId: event,
            serviceType: response.serviceType,
            serviceSubType: response.serviceSubType,
            totamt: response.totamt,
            englishName: response.englishName,
            arabicName: response.arabicName,
            approvalRemarks: response.approvalRemarks
          })
        }
        else{
          this.ButtonShowHide = false;
        this.approveServiceForm.patchValue({
          mytransId: event,
          serviceType: response.serviceType,
          serviceSubType: response.serviceSubType,
          totamt: response.totamt,
          englishName: response.englishName,
          arabicName: response.arabicName
        })
      }
      }
    });
    //
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', modalDialogClass: 'modal-md' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'yes') {

        console.log('test');
        let currentDate = this.datepipe.transform((new Date));
        let currentTime = this.datepipe.transform((new Date), 'h:mm:ss');
        this.approveServiceForm.controls['approvalDate']?.setValue(currentDate);
        this.approveServiceForm.controls['entryDate']?.setValue(currentDate);
        this.approveServiceForm.controls['entryTime']?.setValue(currentTime);
        this.approveServiceForm.controls['tenentId'].setValue(this.tenentId[0]);
        this.approveServiceForm.controls['locationId'].setValue(this.locationId[0]);
        this.approveServiceForm.controls['userId']?.setValue(this.username[0]);
        //
        this.financialService.ManagerApproveService(this.approveServiceForm.value).subscribe(response => {
          this.toastrService.success('.Service approved successfully', 'Success');
          this.isFormSubmitted = false;
          this.loadData(this.paginator.pageIndex, this.isShowAllChecked);
        })
      }

    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
  // Reject service...
  openRejectServiceModal(content: any, event: any) {
    this.isFormSubmitted = true;
    //
    this.rejectServiceForm.patchValue({
      mytransId: event
    })
    //
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', modalDialogClass: 'modal-md' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'yes') {

        let currentDate = this.datepipe.transform((new Date));
        let currentTime = this.datepipe.transform((new Date), 'h:mm:ss');
        this.rejectServiceForm.controls['approvalDate']?.setValue(currentDate);
        this.rejectServiceForm.controls['entryDate']?.setValue(currentDate);
        this.rejectServiceForm.controls['entryTime']?.setValue(currentTime);
        this.rejectServiceForm.controls['tenentId'].setValue(this.tenentId[0]);
        this.rejectServiceForm.controls['locationId'].setValue(this.locationId[0]);
        this.rejectServiceForm.controls['username']?.setValue(this.username[0]);
        this.rejectServiceForm.controls['userId']?.setValue(this.username[0]);

        this.financialService.ManagerRejectServiceAsync(this.rejectServiceForm.value).subscribe(response => {
          this.toastrService.success('.Service rejected successfully', 'Success');
          this.isFormSubmitted = false;
          this.rejectServiceForm.reset();
          this.rejectServiceForm.controls['approvalDate']?.setValue(currentDate);
          this.loadData(this.paginator.pageIndex, this.isShowAllChecked);
        })
      }

    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  openServiceDetailsModal(event: any) {
    this.financialService.GetServiceApprovalDetailByTransId(event.target.id).subscribe((response: any) => {
      if (response) {
        this.financialDetails = response;
      }
    })
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
  //#region Material Search and Clear Filter
  filterRecords(pageIndex: number = -1) {
    if (this.formGroup.value.searchTerm != null && this.returnServiceApprovals) {
      this.formGroup.value.searchTerm = this.returnServiceApprovals.filter = this.formGroup.value.searchTerm.trim();
    }
    if (pageIndex == 0) this.loadData(0, this.isShowAllChecked);
    else this.loadData(this.paginator.pageIndex, this.isShowAllChecked);
  }
  clearFilter() {
    this.formGroup?.patchValue({ searchTerm: "" });
    this.filterRecords();
  }

  pageChanged(event: any) {
    if (event.pageIndex == 0) {
      this.userParams.pageNumber = event.pageIndex + 1
    } else if (event.length <= (event.pageIndex * event.pageSize + event.pageSize)) {
      this.userParams.pageNumber = event.pageIndex + 1;
    } else if (event.previousPageIndex > event.pageIndex) {
      this.userParams.pageNumber = event.pageIndex;
    } else {
      this.userParams.pageNumber = event.pageIndex + 1
    }
    this.userParams.pageSize = event.pageSize;
    this.financialService.setUserParams(this.userParams);
    if (this.formGroup.value.searchTerm == null) {
      this.loadData(event.pageIndex, this.isShowAllChecked);
    }
    else if (this.formGroup.value.searchTerm.length > 0) {
      this.filterRecords();
    }
    else {
      this.loadData(event.pageIndex, this.isShowAllChecked);
    }
  }

  //#endregion
}
