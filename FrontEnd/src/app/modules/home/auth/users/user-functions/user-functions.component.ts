import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SelectMasterIdDto } from 'src/app/modules/models/SelectMasterIdDto';
import { SelectUsersDto } from 'src/app/modules/models/SelectUsersDto';
import { UserFunctionDto } from 'src/app/modules/models/UserFunctions/UserFunctionDto';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { UserFunctionsService } from 'src/app/modules/_services/user-functions.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import * as _ from 'lodash';
import { FunctionForUserDto } from 'src/app/modules/models/FunctionForUserDto';
import { CommonService } from 'src/app/modules/_services/common.service';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';

@Component({
  selector: 'app-user-functions',
  templateUrl: './user-functions.component.html',
  styleUrls: ['./user-functions.component.scss']
})
export class UserFunctionsComponent implements OnInit {
  //
  checkBox = true;
  SelectedMenuId: any = 1;
  //
  users$: Observable<SelectUsersDto[]>;
  //
  masterIds$: Observable<SelectMasterIdDto[]>;
  //
  userFunctions$: Observable<UserFunctionDto[]>;
  //
  allUserFunctions: UserFunctionDto[] = [];
  //
  moduleWiseMenuItems$: Observable<UserFunctionDto[]>;
  //
  moduleWiseMenuSubItems$: Observable<UserFunctionDto[]>;
  //
  selectedMenuItem: string;
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
  lang: any = '';
  //
  checkData: any;

  // To get and put selected user info e.g. location Id, user id, role id etc.
  selectedUserInfo: SelectUsersDto;
  selectedUserMenu: any = [];
  userId: any;
  tenantId: number = 21;
  locationId: number = 1;
  isSubmitted: boolean = false;

  headerCheckboxForm: FormGroup;
  constructor(private dbCommonService: DbCommonService,
    private userFunctionService: UserFunctionsService,
    private toastr: ToastrService,
    private common: CommonService,
    private activatedRout: ActivatedRoute,
    private cd: ChangeDetectorRef,
    private fb: FormBuilder) {
    // this.userId = this.activatedRout.snapshot.paramMap.get('id');
    this.userId = parseInt(JSON.parse(localStorage.getItem('user') || '{}')[0].userId);
    this.createHeaderCheckboxForm();
  }

  createHeaderCheckboxForm() {
    this.headerCheckboxForm = this.fb.group({
      AdminFlg: [false],
      AddFlg: [false],
      EditFlg: [false],
      DelFlg: [false],
      PrintFlg: [false],
      EmptyFlg: [false],
      Sp1Flg: [false],
      Sp2Flg: [false],
      Sp3Flg: [false],
      Sp4Flg: [false],
      Sp5Flg: [false],
      ActiveFlg: [false]
    })
  }
  userInfo:any;
  async ngOnInit(): Promise<void> {
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang;
    })
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'SetupUserFunctions';
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

    }
    // this.lang = localStorage.getItem('lang');
    // To display selected user...
    this.users$ = this.dbCommonService.GetUserByTenantIdAndLocationId(this.tenantId, this.locationId);
    //
    this.masterIds$ = this.dbCommonService.GetMasterId();
    let getCurrentUser: any = await this.dbCommonService.GetUserByTenantIdAndLocationId(this.tenantId, this.locationId).toPromise();
    this.userInfo = getCurrentUser;
    this.selectedUserInfo = getCurrentUser.find((x: any) => x.userId == this.userId);
    this.onMenuItemSelect({ target: { value: this.SelectedMenuId } });
    this.moduleWiseMenuItems$ = this.userFunctionService.GetModuleWiseMenuItems();
    this.moduleWiseMenuItems$.subscribe(res => {
      console.log(res);
    })
    console.log(this.selectedUserInfo)
  }




  mergeUserSelectedMenuData() {
    for (var val of this.selectedUserMenu) {
      let filterItem = this.checkData.filter((x: any) => x.fulL_NAME == val.fulL_NAME && x.menU_ID == val.menU_ID);
      if (filterItem.length > 0) {
        _.merge(filterItem[0], val);
      }
    }
  }

  savedata() {
    this.isSubmitted = true;
    if (this.userId) {
      let saveSelectedMenu: any = [];
      this.checkData.forEach((element: any) => {
        //console.log(element);
        saveSelectedMenu.push(element);
        // if (element.sP5 || element.sP4 || element.sP3 || element.sP2 || element.sP1 || element.addflage || element.delflage || element.editflage || element.printflage) {
        //   saveSelectedMenu.push(element);
        // }
      });

      console.log(saveSelectedMenu);
      if (saveSelectedMenu.length > 0) {
        this.userFunctionService.AddFunctionForUser(saveSelectedMenu).subscribe(()=>{
          this.toastr.success('Saved Successfully')
        })
      }
      // create delete api by moduleid and user id -- Pending

    }
  }

  async checkCheckBoxvalue(event: any, item: any) {
    let name = event.source.name;
    item[name] = item[name] ? 1 : 0;
  }
  //
  async checkAllCheckBoxvalue(event: any, colunmName: any) {
    let name = event.checked;
    this.checkData = this.checkData.map((e: any) => {
      return true ? { ...e, [colunmName]: event.checked == true ? 1 : 0 } : e;
    });
  }
  //
  async onMenuItemSelect(e: any) {
    console.log(this.selectedUserInfo)
    this.checkData = await this.userFunctionService.GetAllFunctionUsers().toPromise();

    for (let user of this.checkData) {
      user.locatioN_ID = this.selectedUserInfo.locationId;
      user.useR_ID = this.selectedUserInfo.userId;
      user.rolE_ID = this.selectedUserInfo.roleId;
      user.logiN_ID = this.selectedUserInfo.loginId;
      user.password = this.selectedUserInfo.password;
    }
    // Refill the existing Observable... 
    this.selectedUserMenu = await this.userFunctionService.GetFunctionUserByUserIdAsync(this.userId).toPromise();

    this.mergeUserSelectedMenuData();

    let filterData: any = this.checkData.filter((x: any) => x.modulE_ID == e.target.value);
    this.checkData = filterData;

    this.headerCheckboxForm.reset();
    this.refreshAsyncData();

  }

  async onUsertemSelect(e:any){
   this.selectedUserInfo = this.userInfo.find((x: any) => x.userId == e.target.value);
   console.log(this.selectedUserInfo)
  }

  refreshAsyncData() {
    this.cd.detectChanges();
  }
}



