import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { FunctionMst } from 'src/app/modules/models/FunctionMst';
import { Login } from 'src/app/modules/models/login';
import { FunctionMstService } from 'src/app/modules/_services/function-mst.service';
import { UserParams } from 'src/app/modules/models/UserParams';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { CommonService } from 'src/app/modules/_services/common.service';

@Component({
  selector: 'app-function-mst',
  templateUrl: './function-mst.component.html',
  styleUrls: ['./function-mst.component.scss']
})
export class FunctionMstComponent implements OnInit {


  //#region
  // To display table column headers
  columnsToDisplay: string[] = ['action', 'ModuleId', 'MenuName1', 'MenuName2', 'menuid', 'Link'];

  // Getting data as abservable.
  functionMst$: Observable<FunctionMst[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  functionMst: MatTableDataSource<FunctionMst> = new MatTableDataSource<any>([]);

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
  functionMstHeaders: any = {};

  // formGroup
  formGroup: FormGroup;

  // Search Term
  searchTerm: string = '';
  //#endregion

  datePickerConfig: Partial<BsDatepickerConfig> | undefined;
  //
  mainFormGroup!: FormGroup;
  //
  isLinear = false;
  //
  // Modal close result...
  closeResult = '';
  //
  singleFunctionMst: FunctionMst[] = [];

  activeMenuStatus: number | undefined;
  activeMenuStatusArray = [
    { id: 0, name: 'No' },
    { id: 1, name: 'Yes' }
  ];
  userParams: UserParams;

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
  lang: any;

  constructor(
    private functionMstService: FunctionMstService,
    private toastr: ToastrService,
    private commonService: CommonService,
    private modalService: NgbModal,
  ) {

    this.formGroup = new FormGroup({
      searchTerm: new FormControl("")
    })
    this.datePickerConfig = Object.assign({}, { containerClass: 'theme-dark-blue' })
    this.userParams = this.functionMstService.getUserParams();
  }


  modalLabels: any = [];
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
    this.formId = 'SetupFunctionMst';
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

    }
    console.log(this.modalLabels)
    console.log(this.formBodyLabels)

    // Initialize Form
    this.initializeForm();

    // Load Data
    this.loadData(0);

  }

  selectedBtn: string = 'edit';
  selectedId: number;
  actionBtnSelect(val: string, id: number) {
    this.selectedBtn = val;
    this.selectedId = id;
  }
  // // Initialize Form
  initializeForm() {
    this.mainFormGroup = new FormGroup({
      menuFormGroup: new FormGroup({
        menU_ID: new FormControl(null, [Validators.required]),
        masteR_ID: new FormControl(null, [Validators.required]),
        modulE_ID: new FormControl(null, [Validators.required]),
        menU_TYPE: new FormControl(null, [Validators.required]),
        MENU_NAMEEnglish: new FormControl(null, [Validators.required]),
        menU_NAMEArabic: new FormControl(null, [Validators.required]),
        menU_NAME3: new FormControl(null, [Validators.required]),
      }),
      managementFormGroup: new FormGroup({
        link: new FormControl(null, [Validators.required]),
        urloption: new FormControl(null, [Validators.required]),
        urlrewrite: new FormControl(null, [Validators.required]),
        menU_LOCATION: new FormControl(null, [Validators.required]),
        menU_ORDER: new FormControl(null, [Validators.required]),
        doC_PARENT: new FormControl(null, [Validators.required]),
      }),

      activeMenuFormGroup: new FormGroup({
        activemenu: new FormControl(null, [Validators.required]),
        activetilldate: new FormControl(null, [Validators.required]),
      }),
      basicFlagsFormGroup: new FormGroup({
        addflage: new FormControl(null, [Validators.required]),
        editflage: new FormControl(null, [Validators.required]),
        delflage: new FormControl(null, [Validators.required]),
        mypersonal: new FormControl(null, [Validators.required]),
      }),
      extendedFlagsFormGroup: new FormGroup({
        sP1: new FormControl(null, [Validators.required]),
        sP2: new FormControl(null, [Validators.required]),
        sP3: new FormControl(null, [Validators.required]),
        sP4: new FormControl(null, [Validators.required]),
        sP5: new FormControl(null, [Validators.required]),
      })
    });
  }

  // Add new function mst...
  AddNewFunctionMst() {
    // Get Tenant Id
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    if (this.mainFormGroup.invalid) {
      this.toastr.warning('Kindly fill all the fields', 'Warning');
    } else {
      //  TO CONVER OBJECT ARRAY AS SIMPLE ARRAY. 
      let functionData = {
        ...this.mainFormGroup.value.menuFormGroup,
        ...this.mainFormGroup.value.managementFormGroup,
        ...this.mainFormGroup.value.activeMenuFormGroup,
        ...this.mainFormGroup.value.basicFlagsFormGroup,
        ...this.mainFormGroup.value.extendedFlagsFormGroup,
        tenentID: tenantId[0], cruP_ID: 0
      }
      //
      this.functionMstService.AddFunctionMst(functionData).subscribe(() => {
        this.toastr.success('Saved successfully', 'Success');
        this.mainFormGroup.reset();
      }, error => {
        if (error.status === 500) {
          this.toastr.error('Something went wrong', 'Error');
        }
      })
    }

  }

  createFunctionMst() {

  }

  //
  editButton: boolean = false;
  ngbId="";
  GetFunctionMstById(id: number) {
    this.ngbId="ngb-panel-1";
    this.editButton = true;
    this.functionMst$ = this.functionMstService.GetFunctionMstById(id);
    this.functionMst$.subscribe((response: any) => {
      this.singleFunctionMst = response;
      this.mainFormGroup.patchValue({
        menuFormGroup: ({
          menU_ID: response.menU_ID,
          masteR_ID: response.masteR_ID,
          modulE_ID: response.modulE_ID,
          menU_TYPE: response.menU_TYPE,
          MENU_NAMEEnglish: response.menU_NAMEEnglish,
          menU_NAMEArabic: response.menU_NAMEArabic,
          menU_NAME3: response.menU_NAME3,
        }),
        managementFormGroup: ({
          link: response.link,
          urloption: response.urloption,
          urlrewrite: response.urlrewrite,
          menU_LOCATION: response.menU_LOCATION,
          menU_ORDER: response.menU_ORDER,
          doC_PARENT: response.doC_PARENT,
        }),

        activeMenuFormGroup: ({
          activemenu: response.activemenu,
          activetilldate: response.activetilldate,
        }),
        basicFlagsFormGroup: ({
          addflage: response.addflage,
          editflage: response.editflage,
          delflage: response.delflage,
          mypersonal: response.mypersonal,
        }),
        extendedFlagsFormGroup: ({
          sP1: response.sP1,
          sP2: response.sP2,
          sP3: response.sP3,
          sP4: response.sP4,
          sP5: response.sP5,
        })
      });
    }, error => {
      this.toastr.error("Something went wrong",)
    })

  }
  //#region Delete operation and Modal Config
  open(content: any, id: number) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'yes') {
        console.log(id);
        this.functionMstService.DeleteFunctionMst(id).subscribe(
          res => {
            this.loadData(0);
            this.toastr.success('Deleted Successfully', 'Deleted')
          },
          error => {
            console.log(error);
          }, () => {

          })
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

  //#region
  loadData(pageIndex: number) {
    this.userParams.pageNumber = pageIndex + 1;
    this.functionMstService.setUserParams(this.userParams);

    this.functionMstService.getAllFunctionMst(this.userParams, this.formGroup.value.searchTerm).subscribe((response: any) => {
      this.functionMstHeaders = JSON.parse(response.headers.get('pagination'));
      console.log(this.functionMstHeaders.totalItems)
      this.functionMst = new MatTableDataSource<FunctionMst>(response.body);
      this.functionMst.paginator = this.paginator;
      this.functionMst.sort = this.sort;
      this.isLoadingCompleted = true;

      setTimeout(() => {
        console.log(this.paginator)
        this.paginator.pageIndex = pageIndex;
        this.paginator.length = this.functionMstHeaders.totalItems;
      });
    }, error => {
      // Incase of any error
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }
  //
  filterRecords(pageIndex: number = -1) {
    if (this.formGroup.value.searchTerm != null && this.functionMst) {
      this.formGroup.value.searchTerm = this.functionMst.filter = this.formGroup.value.searchTerm.trim();
    }
    if (pageIndex == 0) this.loadData(0);
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
    this.functionMstService.setUserParams(this.userParams);
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

  updateFunctionMst() {
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);

    //  TO CONVER OBJECT ARRAY AS SIMPLE ARRAY. 
    let functionData = {
      ...this.mainFormGroup.value.menuFormGroup,
      ...this.mainFormGroup.value.managementFormGroup,
      ...this.mainFormGroup.value.activeMenuFormGroup,
      ...this.mainFormGroup.value.basicFlagsFormGroup,
      ...this.mainFormGroup.value.extendedFlagsFormGroup,
      tenentID: tenantId[0], cruP_ID: 0
    }
    //
    this.functionMstService.UpdateFunctionMst(functionData).subscribe(() => {
      this.toastr.success('Updated successfully', 'Success');
      this.mainFormGroup.reset();
    }, error => {
      if (error) {
        this.toastr.error('Something went wrong', 'Error');
      }
    })
  }

}
