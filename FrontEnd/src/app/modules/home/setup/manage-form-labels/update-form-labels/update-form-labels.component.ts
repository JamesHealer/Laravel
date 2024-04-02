import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, Observable } from 'rxjs';
import { FormTitleDt } from 'src/app/modules/models/formTitleDt';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import { CommonService } from 'src/app/modules/_services/common.service';
import { UserParams } from 'src/app/modules/models/UserParams';
import { Pagination } from 'src/app/modules/models/pagination';

@Component({
  selector: 'app-update-form-labels',
  templateUrl: './update-form-labels.component.html',
  styleUrls: ['./update-form-labels.component.scss']
})
export class UpdateFormLabelsComponent implements OnInit {

  /* Material Table Configuration */
  //#region
  // To display table column headers
  headerColumnsToDisplay: string[] = ['language', 'id', 'headerName', 'subHeaderName', 'action'];
  bodyColumnsToDisplay: string[] = ['language', 'id', 'title', 'arabicTitle', 'action2'];
  // Getting data as abservable.
  formTitleHd$: Observable<FormTitleHd[]>;
  formTitleDt$: Observable<FormTitleDt[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  formTitleHd: MatTableDataSource<FormTitleHd> = new MatTableDataSource<any>([]);
  formTitleDt: MatTableDataSource<FormTitleDt> = new MatTableDataSource<any>([]);

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

  searchText: string = '';

  // Language Type e.g. 1 = ENGLISH and 2 =  ARABIC
  languageType: any;

  searchField = new FormControl('')

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
  lang: any;
  //#endregion
  totalRows = 0;
  pageSizeOptions: number[] = [10, 20, 50];
  employeeHeaders: any = {};
  userParams: UserParams;
  pagination: Pagination;

  refreshFormTitleHd$ = new BehaviorSubject<boolean>(true);

  constructor(private activatedRouter: ActivatedRoute,
    private localizationService: LocalizationService,
    private commonService: CommonService,
    private toastrService: ToastrService, private router: Router) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl(null)
    })
    this.userParams = this.localizationService.getUserParams(); 
  }

  ngOnInit(): void {
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'SetupManageFormHeaderLanguage';

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
      }

    }
    console.log(this.formBodyLabels)

    //#region    
    this.formTitleHd$ = this.localizationService.GetFormHeaderLabelsByFormId(this.activatedRouter.snapshot.params.formID);
    this.formTitleHd$.subscribe((resoponse: FormTitleHd[]) => {
      this.formTitleHd = new MatTableDataSource<FormTitleHd>(resoponse);
      this.isLoadingCompleted = true;
    }, error => {
      // Incase of any error
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
    //#endregion  
    this.loadData(0, '');
  }

  pageNumber = 1;
  pageSize = 10;

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
    if (this.formGroup.value.searchTerm == null) {
      this.loadData(event.pageIndex, '');
    }
    else if (this.formGroup.value.searchTerm.length > 0) {
      this.filterRecords(event.pageIndex);
    }
    else {
      this.loadData(event.pageIndex, '');
    }
  }

  loadData(pageIndex: any, query:any) {
    this.userParams.pageNumber = pageIndex + 1;
    
    this.formTitleDt$ = this.localizationService.GetFormBodyLabelsByFormId(this.activatedRouter.snapshot.params.formID, this.userParams, query);
    this.formTitleDt$.subscribe((resoponse: any) => {
      console.log(resoponse)
      this.formTitleDt = new MatTableDataSource<FormTitleDt>(resoponse.formTitleDTLanguageDto);
      this.formTitleDt.paginator = this.paginator;
      this.formTitleDt.sort = this.sort;
      this.isLoadingCompleted = true;

      setTimeout(() => {
        this.paginator.pageIndex = pageIndex;
        this.paginator.length = resoponse.totalRecords;
      });
    }, error => {
      // Incase of any error
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }


  //#region Material Search and Clear Filter
  filterRecords(event: any) {
    if (event.target.value != null && this.formTitleDt) {
      this.formTitleDt.filter = event.target.value.trim();
    }
  }
  clearFilter() {
    this.formTitleDt.filter = "";
    this.searchField.setValue('')
    this.loadData(0, '');
  }
  backSpaceEvent(event: any) {
    if (event.target.value != null && this.formTitleDt) {
      this.formTitleDt.filter = event.target.value.trim();
    }
  }

  //#endregion

  // If user want to edit header labels
  onHeaderEditClick(item: any) {
    // 
    this.formTitleHd.data.forEach(element => {
      element.isHeaderEdit = false;
    })
    item.isHeaderEdit = true;
  }

  // If user want to update header labels
  onHeaderUpdateClick(item: FormTitleHd) {
    this.localizationService.UpdateFormHeaderLabelsId(item).subscribe(() => {
      this.toastrService.success('Updated Successfully', 'Success');
    })
    item.isHeaderEdit = false;
  }

  // If user want to edit body labels
  onBodyEditClick(item: any) {
    // 
    this.formTitleDt.data.forEach(element => {
      element.isBodyEdit = false;
    })
    item.isBodyEdit = true;
  }

  // If user want to update body labels
  onBodyUpdateClick(formBodyLabel: FormTitleDt) {
    this.localizationService.UpdateFormBodyLabelsId(formBodyLabel).subscribe(() => {
      this.toastrService.success('Updated Successfully', 'Success');
    })
    formBodyLabel.isBodyEdit = false;
  }

  // If user wants to cancel edit mode.
  refreshPage() {
    // // TO REFRESH / RELOAD THE PAGE WITHOUT REFRESH THE WHOLE PAGE.
    let currentUrl = this.router.url;
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate([currentUrl]);
  }


}
