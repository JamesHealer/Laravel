import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { UserMstDto } from 'src/app/modules/models/UserMst.ts/UserMstDto';
import { CommonService } from 'src/app/modules/_services/common.service';
import { UserMstService } from 'src/app/modules/_services/user-mst.service';
import { ConfirmedValidator } from 'src/app/modules/_services/confimed.validator';
import { SelectUsersDto } from 'src/app/modules/models/SelectUsersDto';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { UserParams } from 'src/app/modules/models/UserParams';
@Component({
  selector: 'app-user-mst',
  templateUrl: './user-mst.component.html',
  styleUrls: ['./user-mst.component.scss']
})
export class UserMstComponent implements OnInit {

  //#region
  // 
  languageType: any;

// Selected Language
language: any;

// We will get form lables from lcale storage and will put into array.
AppFormLabels: FormTitleHd[] = [];

// We will filter form header labels array
formHeaderLabels: any[] = [];

// We will filter form body labels array
formBodyLabels: any[] = [];

modalLabels: any = [];

// FormId
formId: string;
lang:any;
  columnsToDisplay: string[] = ['action', 'firstName', 'lastName', 'loginId', 'isActive'];
  //
  userMst$: Observable<UserMstDto[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  userMst: MatTableDataSource<any> = new MatTableDataSource<any>([]);

  // Paginator
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;

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
  // Modal close result...
  closeResult = '';
  //
  changePasswordForm: FormGroup;
  //
  userForm: FormGroup;
  //
  selectedVal: any;
  //
  users$: Observable<SelectUsersDto[]>;
  //
  isFormSubmitted = false;
  pageSize: number = 10;
  userParams: UserParams;
  //
  constructor(
    private userMstService: UserMstService,
    private router: Router,
    private modalService: NgbModal,
    private commonService:CommonService,
    private toastrService: ToastrService,
    private fb: FormBuilder,
    private dbCommonService: DbCommonService) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl("")
    })

    this.userParams = this.userMstService.getUserParams();

  }
  // Change UserPassword
  @ViewChild('content', { static: true }) modalContent: ElementRef;
  //
  @ViewChild('deleteModal', { static: true }) deleteModal: ElementRef;


  ngOnInit(): void {
    console.log(this.paginator)
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'SetupUserMaster';
    var modalId = 'voucherModal'
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

    //
    this.users$ = this.dbCommonService.GetUsers();
    //
    this.initializeChangePasswordForm();
    // 
    this.initializeUserForm();
    
    this.LoadData(0);
  }
  // On Submit User Form
  onUserFormSubmit() {
    this.isFormSubmitted = true;
    if (this.userForm.controls['userId'].value === '' || this.userForm.controls['userId'].value === 0) {
      // Add New record
      this.userMstService.AddUserMST(this.userForm.value).subscribe(response => {
        if (response === 500) {
          this.toastrService.error('Something went wrong. please again latter', 'Error');
        } else {
          this.toastrService.success('Saved successfully', 'Success');
          this.isFormSubmitted = false;
          this.userForm.reset();
          // Refresh Grid
          this.LoadData(0);
        }
      });
    } else {
      //Update existing record
      this.userMstService.UpdateUserMST(this.userForm.value).then(response => {
        if (response === 500) {
          this.toastrService.error('Something went wrong. please again latter', 'Error');
        } else {
          this.toastrService.success('Updated successfully', 'Success');
          this.isFormSubmitted = false;
          this.userForm.reset();
          // Refresh Grid
          this.LoadData(0);
        }
      });
    }
  }

  // Cancel Button Click...
  resetForm() {
    this.userForm.reset();
  }

  //
  get u() { return this.userForm.controls; }

  //
  get f() { return this.changePasswordForm.controls; }

  // OnSubmit Update Password
  onFormSubmit() {
    this.isFormSubmitted = true;
    this.userMstService.UpdateUserPassword(this.changePasswordForm.value).then(response => {
      if (response === 0) {
        this.toastrService.error('Password not found', 'Error');
      } else {
        this.toastrService.success('Password updated successfully', 'Success');
        this.isFormSubmitted = false;
        this.changePasswordForm.reset();
        this.modalService.dismissAll();
      }
    });
  }
  //
  initializeUserForm() {
    this.userForm = this.fb.group({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required,Validators.email]),
      mobile: new FormControl('', Validators.required),
      userType: new FormControl('', Validators.required),
      loginId: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      cpassword: new FormControl('', Validators.required),
      userId: new FormControl(0)
    }, {
      validator: ConfirmedValidator('password', 'cpassword')
    })
  }

  //
  initializeChangePasswordForm() {
    this.changePasswordForm = this.fb.group({
      oldPassword: new FormControl('', Validators.required),
      newPassword: new FormControl('', Validators.required),
      confirmPassword: new FormControl('', Validators.required),
      UserId: new FormControl('', Validators.required)
    }, {
      validator: ConfirmedValidator('newPassword', 'confirmPassword')
    })
  }


  // ON DropDown Change...
  onChange(event: any) {
    let selectedOption = event.target.options[event.target.options.selectedIndex].text
    this.selectedVal = event.target.value;
    this.changePasswordForm.patchValue({ UserId: this.selectedVal })
    if (selectedOption === 'User Rights') {
      this.router.navigateByUrl("/users/user-functions/" + this.selectedVal);
    } else if (selectedOption === 'Change Password') {
      this.open(this.modalContent, this.selectedVal);
    } else if (selectedOption === 'Edit') {
      this.userMstService.GetUserMstById(this.selectedVal).subscribe((response: any) => {
        this.userForm.patchValue({
          firstName: response.firstName,
          lastName: response.lastName,
          email: response.email,
          mobile: response.mobile,
          userType: response.userType,
          loginId: response.loginId,
          password: response.password,
          cpassword: response.password,
          userId: response.userId
        })
        this.isFormSubmitted = true;
      }, error => {
        console.log(error);
      });
    } else if (selectedOption === 'Delete') {
      this.openDeleteModal(this.deleteModal, this.selectedVal);
    }

  }


  LoadData(pageIndex: any) {
    this.userParams.pageNumber = pageIndex + 1;
    this.userMstService.setUserParams(this.userParams);

    this.userMstService.GetUsersFromUserMst(this.userParams, this.formGroup.value.searchTerm).subscribe((response: any) => {
      this.userMst = new MatTableDataSource<any>(response.body.userMstDto);
      this.userMst.paginator = this.paginator;
      this.userMst.sort = this.sort;
      this.isLoadingCompleted = true;
      setTimeout(() => {
        this.paginator.pageIndex = pageIndex;
        this.paginator.length = response.body.totalRecords;
      });
    }, error => {
      console.log(error);
      this.dataLoadingStatus = 'Error fetching the data';
      this.isError = true;
    })
  }

  //#region Material Search and Clear Filter
  filterRecords(pageIndex: number = -1) {
    if (this.formGroup.value.searchTerm != null && this.userMst) {
      this.userMst.filter = this.formGroup.value.searchTerm.trim();
    }
    if( pageIndex == 0) this.LoadData(0);
    else this.LoadData(this.paginator.pageIndex);
  }
  onPaginationChange(event: any) {
    this.pageSize = event.pageSize;
    this.LoadData(event.pageIndex);
  }
  clearFilter() {
    this.formGroup?.patchValue({ searchTerm: "" });
    this.filterRecords();
  }
  //#endregion

  //#region Delete operation and Modal Config


  open(content: any, id: number) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'update') {

      }
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });

  }
  // Delete recored...
  openDeleteModal(content: any, id: number) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'yes') {
        this.userMstService.DeleteUserMST(id).subscribe(response => {
          if (response === 1) {
            this.toastrService.success('User deleted successfully', 'Success');
            // Refresh Grid
            this.LoadData(0);
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
  //#endregion

}

