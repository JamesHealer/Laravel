import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { Observable } from 'rxjs/internal/Observable';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import { Pagination } from 'src/app/modules/models/pagination';
import { UserParams } from 'src/app/modules/models/UserParams';
import { CommonService } from 'src/app/modules/_services/common.service';


@Component({
  selector: 'app-manage-form-labels',
  templateUrl: './manage-form-labels.component.html',
  styleUrls: ['./manage-form-labels.component.scss']
})
export class ManageFormLabelsComponent implements OnInit {

  /* Material Table Configuration */

  //#region
  // To display table column headers
  columnsToDisplay: string[] = ['action', 'formID', 'formName', 'headerNameEn', 'subHeaderNameEn'];

  // Getting data as abservable.
  formTitleHd$: Observable<FormTitleHd[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  formTitleHd: MatTableDataSource<FormTitleHd> = new MatTableDataSource<any>([]);

  // Paginator
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  // Sorting
  @ViewChild(MatSort) sort!: MatSort;

  // Hide footer while loading.
  isLoadingCompleted: boolean = false;

  userParams: UserParams;
  pagination: Pagination;
  //
  currentPage = 0;
  totalRows = 0;
  pageSizeOptions: number[] = [10, 20, 50, 100];
  formLabelHeaders: any = {};

  // Incase of any error will display error message.
  dataLoadingStatus: string = '';

  // True of any error
  isError: boolean = false;

  // formGroup
  formGroup: FormGroup;

  // Search Term
  searchTerm: string = '';
  //#endregion
  direction = '';
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
lang:any;
  constructor(private localizationService: LocalizationService,
    private commonService:CommonService
    ) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl("")
    })

    this.userParams = this.localizationService.getUserParams(); 
  }

  ngOnInit(): void {
    //#region    
    if (localStorage.getItem('lang') == 'ar') {
      this.direction = 'rtl'
    }
    if (localStorage.getItem('lang') == 'en') {
      this.direction = 'ltr';
    }

    this.loadData(0);
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'SetupManageFormLabels';

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {

      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {
        if (labels.formID == this.formId ) {
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
  }
  

  loadData(pageIndex: any) {
    this.userParams.pageNumber = pageIndex + 1;
    this.localizationService.setUserParams(this.userParams);
    this.localizationService.getAllFormHeaderLabels(this.userParams, this.formGroup.value.searchTerm).subscribe((response: any) => {
      this.formLabelHeaders.totalItems = response.totalRecords;
      this.formTitleHd = new MatTableDataSource<FormTitleHd>(response.formTitleHDLanguageDto);
      this.formTitleHd.paginator = this.paginator;
      this.formTitleHd.sort = this.sort;
      this.isLoadingCompleted = true;

      setTimeout(() => {
        this.paginator.length = this.formLabelHeaders.totalItems;
        this.paginator.pageIndex = pageIndex;
      });      
    }, error => {
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }

  //#region Material Search and Clear Filter
  filterRecords(pageIndex: number = -1) {
    if (this.formGroup.value.searchTerm != null && this.formTitleHd) {
      this.formGroup.value.searchTerm = this.formTitleHd.filter = this.formGroup.value.searchTerm.trim();
    }
    if( pageIndex == 0) this.loadData(0);
    else this.loadData(this.paginator.pageIndex);
  }
  clearFilter() {
    this.formGroup?.patchValue({ searchTerm: "" });
    this.filterRecords();
  }
  //#endregion
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
    this.localizationService.setUserParams(this.userParams);
    if (this.formGroup.value.searchTerm == null) {
      this.loadData(event.pageIndex);
    }
    else if (this.formGroup.value.searchTerm.length > 0) {
      this.filterRecords();
    }
    else {
      this.loadData(event.pageIndex);
    }
  }

}
function next(next: any, arg1: (resoponse: FormTitleHd[]) => void, arg2: (error: any) => void) {
  throw new Error('Function not implemented.');
}

