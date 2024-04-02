import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CommonService } from 'src/app/modules/_services/common.service';
import { EmployeeService } from 'src/app/modules/_services/employee.service';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';

@Component({
  selector: 'app-employee-password-reset',
  templateUrl: './employee-password-reset.component.html',
  styleUrls: ['./employee-password-reset.component.scss']
})
export class EmployeePasswordResetComponent implements OnInit {

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
  lang: string;
  rowData: any;
  rowDataParse: any;
  resetForm!: FormGroup;
  isFormSubmitted: boolean = false;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: FormBuilder,
    private _employeeService: EmployeeService,
    private commonService: CommonService,
    private toast: ToastrService) {
    this.rowData = this.route.snapshot.paramMap.get('data')
  }

  ngOnInit(): void {
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang;
    })
    var data = JSON.parse(localStorage.getItem("user")!);
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = "EmployeePasswordReset";

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
          this.formBodyLabels.push(jsonFormTitleDTLanguage);

        }
      }
      console.log(this.formBodyLabels)
    }
    this.rowDataParse = JSON.parse(this.rowData);
    console.log(this.rowDataParse)
    this.resetFormValue();
  }

  resetFormValue() {
    this.isFormSubmitted = true;
    this.resetForm = this.fb.group({
      eName: [this.rowDataParse.englishName],
      aName: [this.rowDataParse.arabicName],
      mobile: [this.rowDataParse.mobileNumber, Validators.required],
      email: [this.rowDataParse.empWorkEmail, Validators.required],
      eLoginId: [this.rowDataParse.employeeLoginId, Validators.required],
      password: ['', Validators.required],
      cPassword: ['', Validators.required],
    })
  }

  get resetFormData() { return this.resetForm.controls; }

  changePassword() {
    var formData = {
      employeeId: this.rowDataParse.employeeId,
      Password: this.resetForm.controls['password'].value,
      MobileNo: this.resetForm.controls['mobile'].value,
      Emailid: this.resetForm.controls['email'].value,
      EmployeeLoginId: this.resetForm.controls['eLoginId'].value
    }
    if (this.resetForm.valid && (this.resetFormData.cPassword.value == this.resetFormData.password.value)) {
      this._employeeService.ResetEmployeePassword(formData).subscribe((res: any) => {
        console.log(res);
        if (res == 1) {
          this.toast.success("Changes done successfully", "Success");
          this.router.navigate(['/employee/view-employee'])
        } else {
          this.toast.error("Something went wrong", "Error");
        }
      },
        error => {
          this.toast.error("Something went wrong", "Error");
        }
      )
    } else {
      this.toast.warning("Kindly fill required fields", "Warning")
    }

  }

}
