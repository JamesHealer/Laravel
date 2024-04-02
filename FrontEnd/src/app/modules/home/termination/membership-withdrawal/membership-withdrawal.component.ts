import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { ReturnTransactionHdDto } from 'src/app/modules/models/FinancialService/ReturnTransactionHdDto';
import { FormTitleDt } from 'src/app/modules/models/formTitleDt';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { CommonService } from 'src/app/modules/_services/common.service';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { Pagination } from 'src/app/modules/models/pagination';
import { UserParams } from 'src/app/modules/models/UserParams';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-membership-withdrawal',
  templateUrl: './membership-withdrawal.component.html',
  styleUrls: ['./membership-withdrawal.component.scss']
})
export class MembershipWithdrawalComponent implements OnInit {



  //#region  Form Language Setting
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
  FilterArray: any = [
    { id: 1, name: 'Subscribed', arabicName: 'مشترك' },
    { id: 2, name: 'Rejected', arabicName: 'مرفوض' },
    { id: 3, name: 'Terminated', arabicName: 'تم إنهاؤه' },
    { id: 0, name: "Show all", arabicName: 'عرض الكل' }
  ];

  ApproveFilterArray: any = [
    { id: 1, name: 'Aprroved', arabicName: 'موافقة' },
    { id: 2, name: 'Rejected', arabicName: 'مرفوض' },
    { id: 0, name: "Show all", arabicName: 'عرض الكل' }
  ];

  DraftFilterArray: any = [
    { id: 1, name: 'Draft Prepared', arabicName: 'تم إعداد المسودة' },
    { id: 2, name: 'Draft Delivered', arabicName: 'تم تسليم المسودة' },
    { id: 3, name: "Draft Not Delivered", arabicName: 'لم يتم تسليم المسودة' },
    { id: 0, name: "Show all", arabicName: 'عرض الكل' }
  ];

  /*----------------------------------------------------*/
  //#endregion

  //#region
  // To display table column headers
  columnsToDisplay: string[] = ['action', 'transId', 'employeeName', 'services', 'installments', 'amount', 'dated', 'paid', 'payDate'];

  // Getting data as abservable.
  returnTransactionHdDto$: Observable<ReturnTransactionHdDto[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  returnTransactionHdDto: MatTableDataSource<ReturnTransactionHdDto> = new MatTableDataSource<any>([]);

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
  modalLabels: any = [];
  // Search Term
  searchTerm: string = '';
  //#endregion

  formTitle: string;
  selectedOpt: string = '';
  lang: any = '';
  // Modal close result...
  closeResult = '';
  ServiceTypeId=8;
  ServiceSubTypeId=10;

  userParams: UserParams;
  pagination: Pagination;
  currentPage = 0;
  totalRows = 0;
  pageSizeOptions: number[] = [10, 20, 50, 100];
  financialHeaders: any = {};

  //filterd value
  selectedStringValue: number = 0;
  ServiceStatusFilterVal: number = 0;
  DraftStatusFilterVal: number = 0;

  selectedAttributesDraft:string = "Show all";
  selectedAttributesApprove:string = "Show all";
  selectedAttributesFilter:string = "Show all";

  constructor(private common: CommonService,
    private router: Router,
    private financialService: FinancialService,
    private commonService: CommonService,
    private modalService: NgbModal,
    private toastrService: ToastrService) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl(null)
    })
    this.userParams = this.financialService.getUserParams();
  }

  ngOnInit(): void {
    this.formTitle = this.common.getFormTitle();
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang;
    })
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'ServiceDetails';
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
      console.log(this.modalLabels)
    }
    //#endregion

    //
    this.loadData(0, 0, 0, 0);
    //

  }
  selectedBtn: string = 'edit';
  selectedId: number;
  actionBtnSelect(val: string, id: number) {
    this.selectedBtn = val;
    this.selectedId = id;
  }
  onDetailsClick(transId: number) {
    //this.commonService.isViewOnly = true;
    // this.redirectTo(`/service-setup/view-service-detail/${transId}`);

    
  }
  loadData(pageIndex: any, val: number, val1: number, val2: number, ) {
    this.financialService.setUserParams(this.userParams);
    //this.detailedEmployee = [];
    this.financialService.GetFinancialServicesByServiceTypeAndServiceSubType(this.userParams, "", val, val1, val2, this.ServiceTypeId, this.ServiceSubTypeId).subscribe((response: any) => {

      this.financialHeaders = JSON.parse(response.headers.get('pagination'));
      this.returnTransactionHdDto = new MatTableDataSource<ReturnTransactionHdDto>(response.body);
      this.returnTransactionHdDto.paginator = this.paginator;
      this.returnTransactionHdDto.sort = this.sort;
      this.isLoadingCompleted = true;
      setTimeout(() => {
        this.paginator.pageIndex = pageIndex;
        this.paginator.length = this.financialHeaders.totalItems;
      });
    }, error => {
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }

  //#region Material Search and Clear Filter
  filterRecords(pageIndex: any) {
    if (this.formGroup.value.searchTerm != null && this.returnTransactionHdDto) {
      this.returnTransactionHdDto.filter = this.formGroup.value.searchTerm.trim();
    }

    this.userParams.pageNumber = pageIndex + 1;
    this.financialService.setUserParams(this.userParams);
    this.financialService.GetFinancialServicesByServiceTypeAndServiceSubType(this.userParams, this.formGroup.value.searchTerm, 0, 0, 0,  this.ServiceTypeId, this.ServiceSubTypeId).subscribe((response: any) => {
      this.financialHeaders = JSON.parse(response.headers.get('pagination'));
      this.returnTransactionHdDto = new MatTableDataSource<ReturnTransactionHdDto>(response.body);
      this.returnTransactionHdDto.paginator = this.paginator;
      this.returnTransactionHdDto.sort = this.sort;
      this.isLoadingCompleted = true;
      setTimeout(() => {
        this.paginator.pageIndex = pageIndex;
        this.paginator.length = this.financialHeaders.totalItems;
      });
    }, error => {
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
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
    this.financialService.setUserParams(this.userParams);
    if (this.formGroup.value.searchTerm == null) {
      this.loadData(event.pageIndex, 0, 0, 0);
    }
    else if (this.formGroup.value.searchTerm.length > 0) {
      this.filterRecords(event.pageIndex);
    }
    else {
      this.loadData(event.pageIndex, 0, 0, 0);
    }
  }

  onFilterItemSelect(e: any) {
    console.log(e);
    this.selectedStringValue = e;
    this.loadData(0, e, this.ServiceStatusFilterVal, this.DraftStatusFilterVal);
  }
  onApproveFilterArray(e: any) {
    console.log(e);
    this.ServiceStatusFilterVal = e;
    this.loadData(0, this.selectedStringValue, e, this.DraftStatusFilterVal);

  }
  onDraftFilterArray(e: any) {
    console.log(e);
    this.DraftStatusFilterVal = e
    this.loadData(0, this.selectedStringValue, this.ServiceStatusFilterVal, e);
  }
  clearFilter() {
    this.formGroup?.patchValue({ searchTerm: "" });
    this.loadData(0, 0, 0, 0);
    this.userParams.pageNumber = 1;
    this.userParams.pageSize = 10;
  }
  //#endregion

  //#region
  openLoanForm() {
    // this.redirectTo('/service-setup/add-service');
    this.router.navigate(['/service-setup/add-service', {ServiceTypeId: this.ServiceTypeId, ServiceSubTypeId:this.ServiceSubTypeId}])
  }
  getSelectedService(event: any) {
    this.selectedOpt = event.target.value;
    this.common.sendFormTitle(this.selectedOpt);
  }
  // Manually redirect to URL to dynamicall change title of form
  redirectTo(uri: string) {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate([uri]));
  }
  //#endregion

  //#region Delete operation and Modal Config
  openDeleteModal(content: any, id: number) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'yes') {
        console.log(id);
        this.financialService.DeleteFinancialService(id).subscribe(response => {
          if (response === 11) {
            this.toastrService.success('Record deleted successfully', 'Success');
            // Refresh Grid
            this.loadData(this.paginator.pageIndex, 0, 0, 0);
          } else {
            this.toastrService.error('Something went wrong', 'Error');
          }
        });
      }
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
      return `with: ${reason}`;
    }
  }
  //#endregion

  exportToExcel() {
    this.financialService.GetFinancialServicesToExportExcel(this.selectedStringValue, this.ServiceStatusFilterVal, this.DraftStatusFilterVal).subscribe((res: any) => {
      if (res.length > 0) {
        this.exportJsonToExcel(res, 'exported_data');
      } else {
        this.toastrService.warning("No data found to export!!")
      }

    })
  }

  exportJsonToExcel(jsonData: any[], fileName: string) {
    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(jsonData);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, `${fileName}.xlsx`);
  }



}
