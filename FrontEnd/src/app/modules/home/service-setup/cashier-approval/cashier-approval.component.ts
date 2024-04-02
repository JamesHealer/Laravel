import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CashierApprovalDto } from 'src/app/modules/models/FinancialService/CashierApprovalDto';
import { ReturnTransactionHdDto } from 'src/app/modules/models/FinancialService/ReturnTransactionHdDto';
import { CommonService } from 'src/app/modules/_services/common.service';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Pagination } from 'src/app/modules/models/pagination';
import { UserParams } from 'src/app/modules/models/UserParams';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';


@Component({
  selector: 'app-cashier-approval',
  templateUrl: './cashier-approval.component.html',
  styleUrls: ['./cashier-approval.component.scss']
})

export class CashierApprovalComponent implements OnInit {

  //#region
  // To display table column headers
  columnsToDisplay: string[] = ['action', 'transId', 'employee', 'mobile', 'service'];

  JvcolumnsToDisplay: string[] = ['accountid', 'accountname', 'cr', 'dr'];
  // Getting data as abservable.
  cashierApprovalDto$: Observable<CashierApprovalDto[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  cashierApprovalDto: MatTableDataSource<CashierApprovalDto> = new MatTableDataSource<any>([]);
  JvDatasource: MatTableDataSource<any> = new MatTableDataSource<any>([]);
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
  isShowAllChecked: boolean = false;

  userParams: UserParams;
  pagination: Pagination;
  //
  currentPage = 0;
  totalRows = 0;
  pageSizeOptions: number[] = [10, 20, 50, 100];
  cashierApprovalHeaders: any = {};
  lang: string;
  formHeaderLabels: any[] = [];
  formBodyLabels: any[] = [];
  formId: string;
  AppFormLabels: FormTitleHd[] = [];

  constructor(private financialService: FinancialService,
    private modalService: NgbModal,
    private toastrService: ToastrService,
    private router: Router,
    private commonService: CommonService) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl("")
    })

    this.userParams = this.financialService.getUserParams();
  }
  modalLabels: any = [];
  ngOnInit(): void {
    //
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    this.formId = 'CashierApprovals';
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
      console.log(this.modalLabels)
    }
    this.loadData(0);

  }
  navigateToCashierDraft(mytransId: number, employeeId: number) {
    this.router.navigateByUrl(`/service-setup/cashier-draft?mytransId=${mytransId}&employeeId=${employeeId}`);
  }
  navigateToCashierDelivery(mytransId: number, employeeId: number) {
    this.router.navigateByUrl(`/service-setup/cashier-delivery?mytransId=${mytransId}&employeeId=${employeeId}`);
  }
  onDetailsClick(transId: number) {
    //this.commonService.isViewOnly = true;
    this.redirectTo(`/service-setup/view-service-detail/${transId}`);
  }
  redirectTo(uri: string) {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate([uri]));
  }
  loadData(pageIndex: any, isShowAll: boolean = false) {

    this.userParams.pageNumber = pageIndex + 1;
    this.financialService.setUserParams(this.userParams);
    //
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    const locationId = data.map((obj: { locationId: any; }) => obj.locationId);
    const periodCode = data.map((obj: { periodCode: any; }) => obj.periodCode);
    const prevPeriodCode = data.map((obj: { prevPeriodCode: any; }) => obj.prevPeriodCode);
    //
    this.financialService.GetCashierApprovals(this.userParams, periodCode, tenantId, locationId, isShowAll, this.formGroup.value.searchTerm).subscribe((response: any) => {
      console.log(response)

      this.cashierApprovalHeaders = JSON.parse(response.headers.get('pagination'));

      this.cashierApprovalDto = new MatTableDataSource<CashierApprovalDto>(response.body);
      this.cashierApprovalDto.paginator = this.paginator;
      this.cashierApprovalDto.sort = this.sort;
      this.isLoadingCompleted = true;
      setTimeout(() => {
        this.paginator.pageIndex = pageIndex;
        this.paginator.length = this.cashierApprovalHeaders.totalItems;
      });
    }, error => {
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }
  onShowAllChange(event: any) {
    this.isShowAllChecked = event.target.checked;
    this.loadData(0, event.target.checked)
  }
  //#region Material Search and Clear Filter
  filterRecords(pageIndex: number = -1) {
    if (this.formGroup.value.searchTerm != null && this.cashierApprovalDto) {
      this.formGroup.value.searchTerm = this.cashierApprovalDto.filter = this.formGroup.value.searchTerm.trim();
    }
    if (pageIndex == 0) this.loadData(0, this.isShowAllChecked);
    else this.loadData(this.paginator.pageIndex, this.isShowAllChecked);
  }
  clearFilter() {
    this.formGroup?.patchValue({ searchTerm: "" });

    this.loadData(0, this.isShowAllChecked);
    this.userParams.pageNumber = 1;
    this.userParams.pageSize = 10;
  }
  //#endregion
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
    this.financialService.setUserParams(this.userParams);
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

  jvDetail: any;
  crTotal: number = 0;
  drTotal: number = 0;
  rowValue:any;
  openJvModal(content: any, val: any) {
    this.rowValue = val;
    this.financialService.GetVoucherByTransId(val.transId).subscribe((res: any) => {
      if (res.length == 0) {
        this.toastrService.warning("No data found", "Warning");
      } else {
        this.JvDatasource = new MatTableDataSource<CashierApprovalDto>(res);

        res.map((x: any) => {
          this.crTotal += x.cr;
          this.drTotal += x.dr;
        })
        // this.jvDetail = res;
        this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', modalDialogClass: 'modal-lg' });
      }
    })
  }
  selectedBtn:string = 'jvView';
  selectedId:number;
  actionBtnSelect(val:string, id:number){
    this.selectedBtn = val;
    this.selectedId = id;
  }

  onPrintClick(val: any) {
    console.log(val);
    this.financialService.GetVoucherReport(val).subscribe((res: any) => {
      var newWin = window.open('', 'Print-Window');
      newWin?.document.open();
      newWin?.document.write('<html><link rel="stylesheet" type="text/css" media="print"/><body onload="window.print()">' + res.reportContent + '</body></html>');
      newWin?.document.close();
      setTimeout(function () {
        newWin?.close();
      }, 10);
    }, e=>{
      this.toastrService.error("Kindly try after sometime", "Error")
    }
    )
  }
}
