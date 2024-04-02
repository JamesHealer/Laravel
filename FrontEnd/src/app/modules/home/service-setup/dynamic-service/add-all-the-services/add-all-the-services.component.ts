import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { ServiceSetupDto } from 'src/app/modules/models/ServiceSetup/ServiceSetupDto';
import { CommonService } from 'src/app/modules/_services/common.service';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import { ServiceSetupService } from 'src/app/modules/_services/service-setup.service';
import { Pagination } from 'src/app/modules/models/pagination';
import { UserParams } from 'src/app/modules/models/UserParams';
import { Router } from '@angular/router';
import { FinancialService } from 'src/app/modules/_services/financial.service';

@Component({
  selector: 'app-add-all-the-services',
  templateUrl: './add-all-the-services.component.html',
  styleUrls: ['./add-all-the-services.component.scss']
})
export class AddAllTheServicesComponent implements OnInit {

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
  modalLabels: any = [];
  /*----------------------------------------------------*/
  //#endregion

  //#region
  // To display table column headers
  columnsToDisplay: string[] = ['action', 'services', 'serviceType'];

  // Getting data as abservable.
  serviceSetupDto$: Observable<ServiceSetupDto[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  serviceSetupDto: MatTableDataSource<any> = new MatTableDataSource<any>([]);

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
  lang: any = '';
  //
  closeResult: string = '';

  //
  userParams: UserParams;
  pagination: Pagination;
  //
  currentPage = 0;
  totalRows = 0;
  pageSizeOptions: number[] = [10, 20, 50, 100];
  serviceHeaders: any = {};
  // 
  formTitle: string;
  constructor(
    private common: CommonService,
    private serviceSetup: ServiceSetupService,
    private modalService: NgbModal,
    private router: Router,
    private financialService:FinancialService,
    private toastrService: ToastrService) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl("")
    })

    this.userParams = this.serviceSetup.getUserParams();
  }

  ngOnInit(): void {
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang;
    })
    this.formTitle = this.common.getFormTitle();
    this.formTitle = '';
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'ServiceSetupDetail';
    var modalId = 'voucherModal'

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {

      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {

        if (labels.formID == this.formId && labels.language == this.languageType) {

          this.formHeaderLabels.push(labels);

          this.formBodyLabels.push(labels.formTitleDTLanguage);

        }
        if (labels.formID == modalId) {
          const jsonFormTitleDTLanguage = labels.formTitleDTLanguage.reduce((result: any, element) => {
            result[element.labelId] = element;
            return result;
          }, {})
          this.modalLabels.push(jsonFormTitleDTLanguage);
        }
      }
    }

    //#endregion
    this.loadData(0);
  }

  selectedBtn: string = 'edit';
  selectedId: number;
  actionBtnSelect(val: any) {
    let urlServiceData = val
    // {
    //   serviceTypeName: val.serviceName1,
    //   subServiceTypeName: val.serviceName2,
    //   serviceTypeId: val.serviceType,
    //   subServiceTypeId: val.serviceSubType,
    // }
    this.router.navigate(['/service-setup/add-service', { serviceInformation: JSON.stringify(urlServiceData) }])
  }

  loadData(pageIndex: any) {
    // this.userParams.pageNumber = pageIndex + 1;
    // this.serviceSetup.setUserParams(this.userParams);

    // this.serviceSetup.GetAllServiceSetupRecords(this.userParams, this.formGroup.value.searchTerm).subscribe((response: any) => {

    //   this.serviceHeaders = JSON.parse(response.headers.get('pagination'));

    //   this.serviceSetupDto = new MatTableDataSource<ServiceSetupDto>(response.body);
    //   this.serviceSetupDto.paginator = this.paginator;
    //   this.serviceSetupDto.sort = this.sort;
    //   this.isLoadingCompleted = true;
    //   setTimeout(() => {
    //     this.paginator.pageIndex = pageIndex;
    //     this.paginator.length = this.serviceHeaders.totalItems;
    //   });
    // }, error => {
    //   console.log(error);
    //   this.dataLoadingStatus = 'Error fetching the data';
    //   this.isError = true;
    // })
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    this.financialService.GetServiceTypeSubServiceTypeByTenentId(tenantId).subscribe((res: any) => {
      this.isLoadingCompleted = true;
      this.serviceSetupDto = new MatTableDataSource<any>(res);
    })
  }
  // Delete recored...
  openDeleteModal(content: any, id: number) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'yes') {
        this.serviceSetup.DeleteServiceSetup(id).subscribe(response => {
          if (response === 1) {
            this.toastrService.success('Record deleted successfully', 'Success');
            // Refresh Grid
            this.loadData(this.paginator.pageIndex);
          } else {
            this.toastrService.error('Something went wrong', 'Errro');
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
    this.serviceSetup.setUserParams(this.userParams);
    if (this.formGroup.value.searchTerm == null) {
      this.loadData(event.pageIndex);
    }
    else if (this.formGroup.value.searchTerm.length > 0) {
      this.filterRecords(event.pageIndex);
    }
    else {
      this.loadData(event.pageIndex);
    }
  }

  //#region Material Search and Clear Filter
  filterRecords(pageIndex: number = -1) {
    if (this.formGroup.value.searchTerm != null && this.serviceSetupDto) {
      this.formGroup.value.searchTerm = this.serviceSetupDto.filter = this.formGroup.value.searchTerm.trim();
    }
    if (pageIndex == 0) this.loadData(0);
    else this.loadData(this.paginator.pageIndex);
  }
  clearFilter() {
    this.formGroup?.patchValue({ searchTerm: "" });
    this.loadData(0);
    this.userParams.pageNumber = 1;
    this.userParams.pageSize = 10;
    // this.filterRecords(0);
  }
  //#endregion

}
