import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { SelectServiceTypeDto } from 'src/app/modules/models/ServiceSetup/SelectServiceTypeDto';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { MatAutocomplete, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { JsonPipe } from '@angular/common';
import * as moment from 'moment';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { CommonService } from 'src/app/modules/_services/common.service';
import { ActivatedRoute } from '@angular/router';
import { FinancialService } from 'src/app/modules/_services/financial.service';

export interface Fruit {
  name: string;
}

@Component({
  selector: 'app-document-attachment',
  templateUrl: './document-attachment.component.html',
  styleUrls: ['./document-attachment.component.scss']
})
export class DocumentAttachmentComponent implements OnInit {
  @Input() parentFormGroup: FormGroup;
  @Input() documentAccordialDetails: string;
  documentAttachmentForm: FormArray<any>;
  selectDocTypeDto: any;

  addOnBlur = true;
  visible = true;
  selectable = true;
  removable = true;

  fruitCtrl = new FormControl();
  filteredFruits: Observable<string[]>;
  metaTag: string[] = [];
  allFruits: string[] = ['Apple', 'Lemon', 'Lime', 'Orange', 'Strawberry'];
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  // We will get form lables from lcale storage and will put into array.
  AppFormLabels: FormTitleHd[] = [];

  // We will filter form header labels array
  formHeaderLabels: any[] = [];
  ApplicantDoc$: Observable<SelectServiceTypeDto[]>;
  // We will filter form body labels array
  formBodyLabels: any = {
    en: {},
    ar: {}
  };
  formId: string;

  formTitle: string;
  lang: string;
  totalAllowedDocuemnts: number;
  languageType: any;
  mytransid: any;
  tenantId: any;
  // Selected Language
  language: any;
  subject: any;
  
  getForm!: FormGroup;
  @ViewChild('fruitInput', { static: false }) fruitInput!: ElementRef<HTMLInputElement>;
  @ViewChild('auto', { static: false }) matAutocomplete!: MatAutocomplete;

  constructor(private fb: FormBuilder,
    public common: CommonService,
    private dbCommonService: DbCommonService,
    private activatedRout: ActivatedRoute,
    private toastrService: ToastrService,
    private financialService: FinancialService) {
      this.mytransid = this.activatedRout.snapshot.paramMap.get('mytransid');
    this.filteredFruits = this.fruitCtrl.valueChanges.pipe(
      startWith(null),
      map((fruit: string | null) => fruit ? this._filter(fruit) : this.allFruits.slice()));
  }

  ngOnInit(): void {
    //
    this.getFormdvalue();
    //
    this.GetDocType();
    this.GetDocApplicantType();
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');


    this.formId = 'AddService';
    

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {

      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {

        if (labels.formID == this.formId) {

          const jsonFormTitleDTLanguage = labels.formTitleDTLanguage.reduce((result: any, element) => {
            result[element.labelId] = element;
            return result;
          }, {})
          if(labels.language == 1 ) {
            this.formBodyLabels['en'] = jsonFormTitleDTLanguage;
          } else if (labels.language == 2) {
            this.formBodyLabels['ar'] = jsonFormTitleDTLanguage;
          }
          // this.formBodyLabels.push(jsonFormTitleDTLanguage);
          console.log(this.formHeaderLabels)
          console.log(this.formBodyLabels);

        }
      }
    }
    if(this.mytransid){
      this.financialService.GetDocumentAttachmentById(this.mytransid).subscribe((response: any) => {
        var val = response.find((x: any) => {
          return x.serialno == "6" && x.documentType == "1"
        })
        // var MetaValue = this.add(val.metaTags)
        this.getForm.patchValue({
          subject: val.subject,
          attachmentRemarks: val.remarks,
          createdDate:  val.createdDate,
          attachId: val.attachId,
          // mtag: MetaValue,
          appplicationFileDocType: val.documentType,
          applicationSelectFile: val.attachmentPath,
          appplicationFileDocument: val.attachmentByName,
        });
      })
    }
    // Get Tenant Id
    var data = JSON.parse(localStorage.getItem("user")!);
    this.tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);

    this.financialService.GetFinancialServiceById(this.mytransid).subscribe((response: any) => {
      this.GetServiceTypeSubServiceTypeByTenentId(response.serviceTypeId, response.serviceSubTypeId);
      // this.serviceTypeSelected = response.serviceType;
      // this.onServiceSubTypeChange(response.serviceTypeId, response.serviceSubTypeId);

    })

  }
  GetServiceTypeSubServiceTypeByTenentId(a1: any, b1: any) {
    var data = JSON.parse(localStorage.getItem("user")!);
    const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
    this.financialService.GetServiceTypeSubServiceTypeByTenentId(tenantId).subscribe((res: any) => {
      var val = res.find((x: any) => {
        return x.serviceTypeId == a1 && x.subServiceTypeId == b1
      })
      console.log(" this.totalAllowedDocuemnts",val);

      this.totalAllowedDocuemnts= val.documentsCount;
      console.log("totalAllowedDocuemnts", this.totalAllowedDocuemnts);
      // this.getForm.patchValue({
      //   //
      // });
      console.log(val);
    })
  }
  GetDocType() {
    this.dbCommonService.GetDocTypes(21).subscribe((response: any) => {
      console.log(response);
      this.selectDocTypeDto = response;
    }, error => {
      console.log(error);
    });
  }
  GetDocApplicantType() {
    this.dbCommonService.GetDocApplicantType().subscribe((res: any) => {
      this.ApplicantDoc$ = res
    });
  }
  applicationSelectFile: any;
  onTheApplicationSelect(event: any) {
    if (event.target.files.length > 0) {
      const file: File = event.target.files[0];
      this.getForm?.get('appplicationFileDocument')?.setValue(file);
      this.applicationSelectFile = file.name;
    }
  }
  personPhotofile: any;
  onPersonalPhotoSelect(event: any) {
    if (event.target.files.length > 0) {
      const file: File = event.target.files[0];
      this.getForm?.get('personalPhotoDocument')?.setValue(file);
      this.personPhotofile = file.name;

    }
  }
  workIdfile: any;
  onWorkIdSelect(event: any) {
    if (event.target.files.length > 0) {
      const file: File = event.target.files[0];
      this.getForm?.get('workIdDocument')?.setValue(file);
      this.workIdfile = file.name;
    }
  }
  civilIdfile: any;
  onCivilIdSelect(event: any) {
    if (event.target.files.length > 0) {
      const file: File = event.target.files[0];
      this.getForm?.get('civilIdDocument')?.setValue(file);
      this.civilIdfile = file.name;
    }
  }
  salarydateFile: any;
  onSalaryDataSelect(event: any) {
    if (event.target.files.length > 0) {
      const file: File = event.target.files[0];
      this.getForm?.get('salaryDataDocument')?.setValue(file);
      this.salarydateFile = file.name;
    }
  }
  // Initialize form
  metatagarr: any;
  add(event: MatChipInputEvent): void {
    // Add fruit only when MatAutocomplete is not open
    // To make sure this does not conflict with OptionSelected Event
    if (!this.matAutocomplete.isOpen) {
      const input = event.input;
      const value = event.value;

      // Add our fruit

      if ((value || '').trim()) {
        this.metaTag.push(value.trim());
        JSON.stringify(this.metaTag);
      }
      // Reset the input value
      if (input) {
        input.value = '';
      }
      this.fruitCtrl.setValue(null);
    }
  }

  remove(fruit: string): void {
    const index = this.metaTag.indexOf(fruit);
    if (index >= 0) {
      this.metaTag.splice(index, 1);
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.metaTag.push(event.option.viewValue);
    this.fruitInput.nativeElement.value = '';
    this.fruitCtrl.setValue(null);
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.allFruits.filter(fruit => fruit.toLowerCase().indexOf(filterValue) === 0);
  }
  saveDocumentAttachements(){
    //this.isFormSubmitted = true;
    this.getForm.patchValue({
      // mytransid: new FormControl('0'),
      subject: this.getForm.controls['subject'].value ? this.getForm.controls['subject'].value : "",
    });
    setTimeout(() => {
      //this.setValidators(this.notSubscriber);
      // Get Tenant Id
      var data = JSON.parse(localStorage.getItem("user")!);
      const tenantId = data.map((obj: { tenantId: any; }) => obj.tenantId);
      const locationId = data.map((obj: { locationId: any; }) => obj.locationId);
      const username = data.map((obj: { username: any; }) => obj.username);
      const periodCode = data.map((obj: { periodCode: any; }) => obj.periodCode);
      const prevPeriodCode = data.map((obj: { prevPeriodCode: any; }) => obj.prevPeriodCode);
      const nextPeriodCode = data.map((obj: { nextPeriodCode: any; }) => obj.nextPeriodCode);

      let formData = {
        ...this.getForm.value,
        tenentID: tenantId, cruP_ID: 0, locationID: locationId, userId: username,
        periodCode: periodCode, prevPeriodCode: prevPeriodCode, nextPeriodCode: nextPeriodCode
      };
      formData['subject'] = this.getForm.get('subject')?.value;

      let finalformData = new FormData();
      Object.keys(formData).forEach(key => finalformData.append(key, formData[key]));

      if (this.mytransid) {

        //console.log('edit click',formData);
        this.financialService.UpdateDocumentAttachmentService(finalformData).subscribe((response: any) => {
          if (response.isSuccess == false) {
            this.toastrService.error(response.message, 'Error');
          } else {
            this.toastrService.success('Updated successfully', 'Success');
          }
        })
      } 
      else {
        //console.log('add click',formData);
        this.financialService.AddDocumentAttachmentService(finalformData).subscribe((response: any) => {
          if (response.isSuccess == false) {
            this.toastrService.error(response.message, 'Error');
          }
          else {
            this.toastrService.success(response.message, 'Success');
          }
        })
      }
      this.toastrService.warning("Save click of docu att", 'Warning');
    })
  }

  getFormdvalue() {
    this.getForm = this.fb.group({
      subject: ['', Validators.required],
      attachmentRemarks: ['', Validators.required],

      appplicationFileDocType: ['', Validators.required],
      appplicationFileDocument: ['', Validators.required],

      civilIdDocType: ['', Validators.required],
      civilIdDocument: ['', Validators.required],

      workIdDocType: ['', Validators.required],
      workIdDocument: ['', Validators.required],

      personalPhotoDocType: ['', Validators.required],
      personalPhotoDocument: ['', Validators.required],

      salaryDataDocType: ['', Validators.required],
      salaryDataDocument: ['', Validators.required],
      mtag: ['', Validators.required],
      attachId: [''],
      createdDate: ['']
    })
  }

  value:any;
  setValueofDocForm(res: any) {
    console.log(res);
    this.value= res.transactionHDDMSDtos;
    let val = res.transactionHDDMSDtos;
    this.applicationSelectFile = val[0].attachmentByName;
    this.personPhotofile = val[1].attachmentByName;
    this.workIdfile = val[2].attachmentByName;
    this.civilIdfile = val[3].attachmentByName;
    this.salarydateFile = val[4].attachmentByName;
    this.metaTag = (val[0].metaTags).split(',');
    this.getForm.controls['subject'].setValue(val[0].subject);
    this.getForm.controls['attachmentRemarks'].setValue(val[0].remarks);
    this.getForm.controls['attachId'].setValue(val[0].attachId);
    this.getForm.controls['createdDate'].setValue(moment(val[0].createdDate).format("DD-MM-yyyy"));
    //
    this.getForm.controls['appplicationFileDocType'].setValue(val[0].documentType);
    this.getForm.controls['civilIdDocType'].setValue(val[1].documentType);
    this.getForm.controls['workIdDocType'].setValue(val[2].documentType);
    this.getForm.controls['personalPhotoDocType'].setValue(val[3].documentType);
    this.getForm.controls['salaryDataDocType'].setValue(val[4].documentType);
    this.convertTofile();
    //   
  }

  file0:any;
  file1:any;
  file2:any;
  file3:any;
  file4:any;
 convertTofile(){
  // console.log((this.value[0].attachmentByName).substring(this.value[0].attachmentByName.lastIndexOf(".") , this.value[0].attachmentByName.length));
  // this.file0 = new File([this.value[0].attachment], this.value[0].attachmentByName,{type : (this.value[0].attachmentByName).substring(this.value[0].attachmentByName.lastIndexOf("."), this.value[0].attachmentByName.length)});
  // this.file1 = new File([this.value[1].attachment], this.value[1].attachmentByName, {type : (this.value[1].attachmentByName).substring(this.value[1].attachmentByName.lastIndexOf("."), this.value[1].attachmentByName.length)});
  // this.file2 = new File([this.value[2].attachment], this.value[2].attachmentByName, {type : (this.value[2].attachmentByName).substring(this.value[2].attachmentByName.lastIndexOf("."), this.value[2].attachmentByName.length)});
  // this.file3 = new File([this.value[3].attachment], this.value[3].attachmentByName, {type : (this.value[3].attachmentByName).substring(this.value[3].attachmentByName.lastIndexOf("."), this.value[3].attachmentByName.length)});
  // this.file4 = new File([this.value[4].attachment], this.value[4].attachmentByName, {type : (this.value[4].attachmentByName).substring(this.value[4].attachmentByName.lastIndexOf("."), this.value[4].attachmentByName.length)});
  this.file0 = [this.value[0].attachment];
  this.file1 = [this.value[1].attachment];
  this.file2 = [this.value[2].attachment];
  this.file3 = [this.value[3].attachment];
  this.file4 = [this.value[4].attachment];
}

  formVal() {
    this.getForm.controls['mtag'].setValue(this.metaTag);
  }


}
