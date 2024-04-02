import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import * as moment from 'moment';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { CashierApprovalDto } from 'src/app/modules/models/FinancialService/CashierApprovalDto';
import { ReturnTransactionHdDto } from 'src/app/modules/models/FinancialService/ReturnTransactionHdDto';
import { RefTableDto } from 'src/app/modules/models/ReferenceDetails/RefTableDto';
import { CommonService } from 'src/app/modules/_services/common.service';
import { EmployeeService } from 'src/app/modules/_services/employee.service';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { Pagination } from 'src/app/modules/models/pagination';
import { UserParams } from 'src/app/modules/models/UserParams';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { DetailModelComponent } from '../detail-model/detail-model.component';

@Component({
  selector: 'app-financial-approval',
  templateUrl: './financial-approval.component.html',
  styleUrls: ['./financial-approval.component.scss']
})
export class FinancialApprovalComponent implements OnInit {

  //#region
  // To display table column headers
  columnsToDisplay: string[] = ['action', 'transId', 'employee', 'mobile', 'service'];

  // Getting data as abservable.
  financialApprovalDto$: Observable<CashierApprovalDto[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  financialApprovalDto: MatTableDataSource<CashierApprovalDto> = new MatTableDataSource<any>([]);

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
  //
  employeeDetailsform: FormGroup;
  closeResult: string = '';

  userParams: UserParams;
  pagination: Pagination;
  //
  currentPage = 0;
  totalRows = 0;
  pageSizeOptions: number[] = [10, 20, 50, 100];
  financialApprovalHeaders: any = {};

  currentUserId: any;
  //
  isFormSubmitted = false;
  rejectionType$: Observable<RefTableDto[]>;
  employeeId: any;
  tenentId: any;
  locationId: any
  periodCode: any;
  prevPeriodCode: any
  roleId: any;
  username: any;
  formId: string;
  financialData: any;
  financialDetails: any;
  approvalDetails: any;
  employeeActivityLog: any;
  crupId: any;
  AppFormLabels: FormTitleHd[] = [];
  isShowAllChecked: boolean = false;
  formHeaderLabels: any[] = [];
  formBodyLabels: any[] = [];
  lang: string;
  constructor(private financialService: FinancialService,
    private router: Router,
    private commonService: CommonService,
    private fb: FormBuilder,
    private datepipe: DatePipe,
    private modalService: NgbModal,
    private toastrService: ToastrService,
    private employeeService: EmployeeService,
  ) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl("")
    })
    var data = JSON.parse(localStorage.getItem("user")!);
    this.tenentId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    this.locationId = data.map((obj: { locationId: any; }) => obj.locationId);
    this.periodCode = data.map((obj: { periodCode: any; }) => obj.periodCode);
    this.prevPeriodCode = data.map((obj: { prevPeriodCode: any; }) => obj.prevPeriodCode);
    this.roleId = data.map((obj: { roleId: any; }) => obj.roleId);
    this.username = data.map((obj: { username: any; }) => obj.username);

    this.userParams = this.financialService.getUserParams(); 
  }
  modalLabels: any = [];
  ngOnInit(): void {
    //
    this.loadData(0);
    //
    this.initApproveServiceForm();
    //
    this.initRejectionServiceForm();
    //
    this.rejectionType$ = this.financialService.GetRejectionType();
    //
    this.initEmployeeForm();
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    this.formId = 'FinancialApprovals';
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
      console.log(this.formBodyLabels)
      console.log(this.formHeaderLabels)
    }
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
      roleId: new FormControl(''),
    })
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
  // navigateToFinancialDraft(mytransId:number,employeeId:number) {
  //   this.router.navigateByUrl(`/service-setup/financial-draft?mytransId=${mytransId}&employeeId=${employeeId}`);
  // }
  // navigateToFinancialDelivery(mytransId:number,employeeId:number) {
  //   this.router.navigateByUrl(`/service-setup/financial-delivery?mytransId=${mytransId}&employeeId=${employeeId}`);
  // }
  // onDetailsClick(transId:number){
  //   this.commonService.isViewOnly = true;
  //   this.redirectTo(`/service-setup/view-service-detail/${transId}`);
  // }
  redirectTo(uri: string) {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate([uri]));
  }
  loadData(pageIndex: any, isShowAll: boolean = false) {
    this.userParams.pageNumber = pageIndex + 1;
    //   
    this.financialService.setUserParams(this.userParams);

    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { locationId: any; }) => obj.locationId);
    const periodCode = data.map((obj: { periodCode: any; }) => obj.periodCode);
    const prevPeriodCode = data.map((obj: { prevPeriodCode: any; }) => obj.prevPeriodCode);
    //
    this.financialService.GetFinancialApprovals(this.userParams, periodCode, tenantId, locationId, isShowAll, this.formGroup.value.searchTerm).subscribe((response: any) => {
      this.financialApprovalHeaders = JSON.parse(response.headers.get('pagination'));

      this.financialApprovalDto = new MatTableDataSource<CashierApprovalDto>(response.body);
      this.financialApprovalDto.paginator = this.paginator;
      this.financialApprovalDto.sort = this.sort;
      this.isLoadingCompleted = true;
      setTimeout(() => {
        console.log(this.paginator)
        this.paginator.pageIndex = pageIndex;
        this.paginator.length = this.financialApprovalHeaders.totalItems;
      });
    }, error => {
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })

    this.financialService.setUserParams(this.userParams);
    //this.detailedEmployee = [];
    this.employeeService.GetEmployees(this.userParams, "").subscribe((response: any) => {

    }, error => {
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }

  openDetailsModal(id:number, data:any){
    const modalref = this.modalService.open(DetailModelComponent, { size: 'lg', backdrop: 'static', keyboard: false});
    modalref.componentInstance.data = {employeeId: id, data: data};
  }

  pageChanged(event: any) {
    if (event.pageIndex == 0) {
      this.userParams.pageNumber = event.pageIndex + 1
    } else if (event.length <= (event.pageIndex * event.pageSize + event.pageSize)) {
      this.userParams.pageNumber = event.pageIndex + 1;
    }
    else if (event.previousPageIndex > event.pageIndex) {
      this.userParams.pageNumber = event.pageIndex;
    } else {
      this.userParams.pageNumber = event.pageIndex + 1
    }
    this.userParams.pageSize = event.pageSize;
    this.employeeService.setUserParams(this.userParams);
    if (this.formGroup.value.searchTerm == null) {
      this.loadData(event.pageIndex, this.isShowAllChecked);
    }
    else if (this.formGroup.value.searchTerm.length > 0) {
      this.filterRecords(event.pageIndex);
    }
    else {
      this.loadData(event.pageIndex, this.isShowAllChecked);
    }
  }

  get approvalForm() { return this.approveServiceForm.controls; }
  get rejectionForm() { return this.rejectServiceForm.controls; }

  onShowAllChange(event: any) {
    this.isShowAllChecked = event.target.checked;
    this.loadData(this.paginator.pageIndex, event.target.checked)
    console.log(this.isShowAllChecked);
  }

  openContactModal(content: any, event: any, crup_id: any) {
    console.log(crup_id);
    this.commonService.employeeId = event   //
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
  openApproveServiceModal(content: any, event: any) {
    let currentDate = this.datepipe.transform((new Date));
    this.isFormSubmitted = true;
    this.financialService.GetServiceApprovalsByTransIdAsync(this.tenentId, this.locationId, event).subscribe((response: any) => {
      if (response) {
        this.approveServiceForm.patchValue({
          mytransId: event,
          serviceType: response.serviceType,
          serviceSubType: response.serviceSubType,
          totamt: response.totamt,
          englishName: response.englishName,
          arabicName: response.arabicName
        })
      }
    });
    //
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', modalDialogClass: 'modal-md' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'yes') {

        let currentDate = this.datepipe.transform((new Date));
        let currentTime = this.datepipe.transform((new Date), 'h:mm:ss');
        this.approveServiceForm.controls['approvalDate']?.setValue(currentDate);
        this.approveServiceForm.controls['entryDate']?.setValue(currentDate);
        this.approveServiceForm.controls['entryTime']?.setValue(currentTime);
        this.approveServiceForm.controls['userId']?.setValue(this.username[0]);
        this.approveServiceForm.controls['tenentId'].setValue(this.tenentId[0]);
        this.approveServiceForm.controls['locationId'].setValue(this.locationId[0]);//
        this.approveServiceForm.controls['roleId'].setValue(this.roleId[0]);
        //
        this.financialService.FinanceApproveService(this.approveServiceForm.value).subscribe(response => {
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
        this.rejectServiceForm.controls['userId']?.setValue(1);
        this.rejectServiceForm.controls['tenentId'].setValue(this.tenentId[0]);
        this.rejectServiceForm.controls['locationId'].setValue(this.locationId[0]);

        this.financialService.FinanceRejectServiceAsync(this.rejectServiceForm.value).subscribe(response => {
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

  //#region Material Search and Clear Filter 
  filterRecords(pageIndex: any) {
    if (this.formGroup.value.searchTerm != null && this.financialApprovalDto) {
      this.financialApprovalDto.filter = this.formGroup.value.searchTerm.trim();
    }
    this.userParams.pageNumber = pageIndex + 1;
    this.financialService.setUserParams(this.userParams);

    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { locationId: any; }) => obj.locationId);
    const periodCode = data.map((obj: { periodCode: any; }) => obj.periodCode);
    const prevPeriodCode = data.map((obj: { prevPeriodCode: any; }) => obj.prevPeriodCode);

    this.financialService.GetFinancialApprovals(this.userParams, periodCode, tenantId, locationId, this.isShowAllChecked, this.formGroup.value.searchTerm).subscribe((response: any) => {
      this.financialApprovalHeaders = JSON.parse(response.headers.get('pagination'));
      this.financialApprovalDto = new MatTableDataSource<CashierApprovalDto>(response.body);
      this.financialApprovalDto.paginator = this.paginator;
      this.financialApprovalDto.sort = this.sort;
      this.isLoadingCompleted = true;
      setTimeout(() => {
        this.paginator.pageIndex = pageIndex;
        this.paginator.length = this.financialApprovalHeaders.totalItems;
      });
    }, error => {
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }
  clearFilter() {
    this.formGroup?.patchValue({ searchTerm: "" });

    this.loadData(0, this.isShowAllChecked);
    this.userParams.pageNumber = 1;
    this.userParams.pageSize = 10;
  }
  //#endregion
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
}
