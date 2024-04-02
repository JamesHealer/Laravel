import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { CommonService } from 'src/app/modules/_services/common.service';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { CashierApprovalDto } from 'src/app/modules/models/FinancialService/CashierApprovalDto';
import { voucherDto } from 'src/app/modules/models/VoucherDto';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';


@Component({
  selector: 'app-voucher',
  templateUrl: './voucher.component.html',
  styleUrls: ['./voucher.component.scss']
})
export class VoucherComponent implements OnInit {

  //#region
  // To display table column headers
  columnsToDisplay: string[] = ['action', 'services', 'empname', 'cepfid', 'transid', 'jvid'];

  // Getting data as abservable.
  voucherDto$: Observable<voucherDto[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  voucherDto: MatTableDataSource<voucherDto> = new MatTableDataSource<any>([]);

  
  voucherColumnsToDisplay: string[] = ['accountId', 'accountName', 'cr', 'dr'];
  voucherDatasource: MatTableDataSource<any> = new MatTableDataSource<any>();

  // Paginator
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  // Sorting
  @ViewChild(MatSort) sort!: MatSort;

  // Hide footer while loading.
  isLoadingCompleted: boolean = true;

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
  voucherDetail: any;
  formId: string;
  formHeaderLabels: any[] = [];
  formBodyLabels: any[] = [];
  AppFormLabels: FormTitleHd[] = [];
  lang: string;
  constructor(private financialService: FinancialService, private router: Router, private modalService: NgbModal, private commonService: CommonService) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl("")
    })
  }

  ngOnInit(): void {
    this.formId = 'VoucherDetails';
    var modalId = 'voucherModal'
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang
    })

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

  selectedBtn:string = 'view';
  selectedId:number;
  actionBtnSelect(val:string, id:number){
    this.selectedBtn = val;
    this.selectedId = id;
  }

  length: number;
  pageSize: number = 10;

  loadData(pageIndex: any) {
    this.financialService.GetVouchers(pageIndex + 1, this.pageSize, this.formGroup.value.searchTerm).subscribe((response: any) => {
      this.voucherDto = new MatTableDataSource<any>(response.voucherDto);
      this.voucherDto.paginator = this.paginator;
      this.voucherDto.sort = this.sort;
      this.length = response.totalRecords;
      this.isLoadingCompleted = true;
      setTimeout(() => {
        this.paginator.pageIndex = pageIndex;
        this.paginator.length = response.totalRecords;
      });
    }, error => {
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }
  onPaginationChange(event: any) {
    this.pageSize = event.pageSize;
    this.loadData(event.pageIndex);
  }
  // navigateToVoucherDetails(voucherId: number) {
  //   this.router.navigateByUrl(`/service-setup/voucher-details?voucherId=${voucherId}`);
  // }
  // redirectTo(uri: string) {
  //   this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
  //     this.router.navigate([uri]));
  // }
  //#region Material Search and Clear Filter 
  filterRecords(pageIndex: number = -1) {
    if (this.formGroup.value.searchTerm != null && this.voucherDto) {
      this.formGroup.value.searchTerm = this.voucherDto.filter = this.formGroup.value.searchTerm.trim();
    }
    if( pageIndex == 0) this.loadData(0);
    else this.loadData(this.paginator.pageIndex);
  }
  clearFilter() {
    this.formGroup?.patchValue({ searchTerm: "" });
    this.filterRecords();
  }
  //#endregion
  crTotal: number = 0;
  drTotal: number = 0;
  openVoucherModal(content: any, id: any) {
    this.financialService.GetVoucherDetails(id).subscribe((res: any) => {
      this.voucherDatasource =  new MatTableDataSource<any>(res);
      res.map((x: any) => {
        this.crTotal += x.cr;
        this.drTotal += x.dr;
      })
     var voucherModalVal = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', modalDialogClass: 'modal-lg' });
     voucherModalVal.result.then((data)=>{
     },(r)=>{
      this.crTotal = 0;
      this.drTotal = 0;
     })
    })
  }
  closeVoucharModal(){
    this.crTotal = 0;
      this.drTotal = 0;
  }


  onPrintClick(val: any) {
    this.financialService.GetVoucherReport(val).subscribe((res: any) => {
      var newWin = window.open('', 'Print-Window');
      newWin?.document.open();
      newWin?.document.write('<html><link rel="stylesheet" type="text/css" media="print"/><body onload="window.print()">' + res.reportContent + '</body></html>');
      newWin?.document.close();
      setTimeout(function () {
        newWin?.close();
      }, 10);
    })
  }
}
