import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { FormTitleDt } from 'src/app/modules/models/formTitleDt';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import { EmployeeService } from 'src/app/modules/_services/employee.service';
import { AuthService } from 'src/app/modules/auth';
import { ToastrService } from 'ngx-toastr';
import { CommonService } from 'src/app/modules/_services/common.service';
import { DbCommonService } from 'src/app/modules/_services/db-common.service';
import { MatTableDataSource } from '@angular/material/table';
import { ExcelParserService } from 'src/app/modules/_services/excel-parser.service';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { MatSort } from '@angular/material/sort';
import { ChangeDetectorRef } from '@angular/core';
import { MonthlyData } from '../../../../types/employee';
import { getAttr } from 'src/app/utils/general';

interface SampleFile {
  value: string;
  text: string;
}

@Component({
  selector: 'app-import-monthlydata',
  templateUrl: './import-monthlydata.component.html',
  styleUrls: ['./import-monthlydata.component.scss'],
})
export class ImportMonthlyDataComponent implements OnInit {
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

  // formGroup
  formGroup: FormGroup;

  // Sorting
  @ViewChild(MatSort) sort!: MatSort;

  @ViewChild('fileInput') fileInput: ElementRef;

  // FormId
  title: string;
  uploadtype: string;
  formId: string;
  sampleFileTypes: SampleFile[] = [];
  selectedSampleFile: string = '';
  tenantId: any;
  locationId: any;
  userName: any;
  userId: any;
  isEdit: boolean = false;
  editingId: number = 0;
  editingData: MonthlyData = {
    YearMonth: new Date(),
    UploadType: 1,
    EmployeeId: 0,
    EmployeeName: '',
    Reference: '',
    Salary: 0,
    Amount: 0
  };
  isCheckingData: boolean = false;
  
  searchTerm: string = '';
  totalData: any[] = [];
  filteredData: MatTableDataSource<any>;

  displayedColumns: string[] = [
    // 'Action',
    'Exception',
    'YearMonth',
    'EmployeeId',
    'EmployeeName',
    'Reference',
    'Salary',
    'Amount'
  ];

  lang: string;
  periodCode: any;
  periodCodes: string[] = [];

  constructor(
    private dialog: MatDialog,
    private activatedRout: ActivatedRoute,
    private cdr: ChangeDetectorRef,
    private employeeService: EmployeeService,
    private authService: AuthService,
    private commonDbService: DbCommonService,
    public commonService: CommonService,
    private toastr: ToastrService,
    private excelParserService: ExcelParserService,
    private fb: FormBuilder
  ) {
    const now = new Date();
    const currentYear = now.getFullYear();
    const currentMonth = now.getMonth();
    const years = [currentYear, currentYear + 1];
    years.forEach(y => {
      for(let m=1; m<=12; m++) {
        this.periodCodes.push(`${y}${m.toString().padStart(2, '0')}`);
      }
    })
    this.periodCode = `${currentYear}${currentMonth.toString().padStart(2,'0')}`;
  }
  
  ngOnInit(): void {
    this.tenantId = JSON.parse(
      localStorage.getItem('user') || '{}'
    )[0].tenantId;
    this.locationId = JSON.parse(
      localStorage.getItem('user') || '{}'
    )[0].locationId;
    this.userName = JSON.parse(
      localStorage.getItem('user') || '{}'
    )[0].username;
    this.userId = JSON.parse(
      localStorage.getItem('user') || '{}'
    )[0].userId;
    this.periodCode = JSON.parse(
      localStorage.getItem('user') || '{}'
    )[0].periodCode;

    this.formGroup = this.fb.group({
      searchTerm: [''],
    });
  
    const searchTermControl = this.formGroup.get('searchTerm');
    if (searchTermControl) {
      searchTermControl.valueChanges.subscribe((term) => {
        this.filterRecords(term);
      });
    }

    //#region TO SETUP THE FORM LOCALIZATION
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang;
    });
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'ImportEmployeeMonthlyPayment';

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {
      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(
        localStorage.getItem('AppLabels') || '{}'
      );

      for (let labels of this.AppFormLabels) {
        if (
          labels.formID == this.formId &&
          labels.language == this.languageType
        ) {
          this.formHeaderLabels.push(labels);

          // this.formBodyLabels.push(labels.formTitleDTLanguage);
          const jsonFormTitleDTLanguage = labels.formTitleDTLanguage.reduce(
            (result: any, element) => {
              result[element.labelId] = element;
              return result;
            },
            {}
          );
          this.formBodyLabels.push(jsonFormTitleDTLanguage);
        }
      }
      console.log(this.formBodyLabels, '-----');
    }
    //#endregion
    this.getImportDataDropdown();

    this.activatedRout.params.subscribe(params => {
      this.uploadtype = params['uploadtype'];
      if(this.uploadtype == '1') {
        this.title = 'Import Membership 1% Subscribe Data';
        this.selectedSampleFile = "Import Mem Sub Data";
      } else if(this.uploadtype == '2') {
        this.title = 'Import Membership Loan Data';
        this.selectedSampleFile = "Import Loan Sub Data";
      } else if(this.uploadtype == '3') {
        this.title = 'Import Salary Changed Employee';
        this.selectedSampleFile = "Import Salary Changed Employee";
      }

      if(this.fileInput) this.fileInput.nativeElement.value = '';
      this.totalData = [];
      this.filterRecords('');
    })
  }

  getImportDataDropdown() {
    this.employeeService.GetImportDataUploader(this.tenantId).subscribe(
      (res: any) => {
        this.sampleFileTypes = res;
        console.log(this.sampleFileTypes);
      },
      (e) => {
        this.toastr.error('Something went wrong');
      }
    );
  }

  onFileChange(event: any): void {
    const file: File = event.target.files[0];
    this.excelParserService
      .parseExcelSheet(file, 'EmployeeMonthlyPFUpload')
      .then((data) => {
        this.totalData = data.rows;
        for(let i=0; i<this.totalData.length; i++) {
          this.totalData[i].exceptions = [];
          this.totalData[i].warnings = [];
        }
        this.filteredData = new MatTableDataSource([...this.totalData]);
        this.checkValidate(data.rows);
        console.log('load excel file ---------->', data);
      })
      .catch((error) => {
        this.toastr.error(error.message, 'Error');
        console.error('Error reading the file:', error);
      })
  }

  checkValidate(monthlyData: any[]) {
    const pcIndex = this.periodCodes.findIndex(pc=>pc == this.periodCode);
    const nextPeriodCode = this.periodCodes[pcIndex + 1];

    const data = {
      tenantId: this.tenantId,
      locationId: this.locationId,
      userName: this.userName,
      userId: this.userId,
      periodCode: this.periodCode,
      nextPeriodCode,
      uploadtype: this.uploadtype,
      monthlyData: this.totalData
    }

    const theThis = this;
    theThis.isCheckingData = true;
    theThis.employeeService.CheckMonthlyData(data)
    .subscribe((response: any) => {
      response.forEach((r: any) => {
        const index = theThis.totalData.findIndex(d1 => (d1.YearMonth ==r.yearMonth) && (d1.EmployeeId == r.employeeId));
        if(index >= 0) {
          theThis.totalData[index].exceptions = r.exceptions;
          theThis.totalData[index].warnings = r.warnings;
        }
      });
      theThis.filterRecords('');
      theThis.isCheckingData = false;
    });
  }

  downloadFile(): void {
    // Send a GET request to the server to download the file
    if (this.selectedSampleFile !== '') {
      this.employeeService
        .DownloadSampleFile('MonthlyDataUploader')
        .subscribe((response: any) => {
          // Create a URL for the response blob
          const url = URL.createObjectURL(response);

          // Create a link element and click it to trigger the download
          const link = document.createElement('a');
          link.href = url;
          link.download = this.selectedSampleFile;
          link.click();

          // Release the URL object
          URL.revokeObjectURL(url);
        });
    } else {
      this.toastr.warning(
        'Kindly select Uploader Type, before click on download'
      );
    }
  }

  importData(): void {
    const currentUser = this.authService.currentUserValue;
    if (currentUser && this.filteredData?.data.length) {

      for(let i=0; i<this.totalData.length; i++) {
        if( (this.totalData[i] as any).exceptions.length > 0) {
          this.toastr.warning('There must not be exception rows.', 'warning');
          return;
        }
      }

      const pcIndex = this.periodCodes.findIndex(pc=>pc == this.periodCode);
      const nextPeriodCode = this.periodCodes[pcIndex + 1];

      const data = {
        tenantId: this.tenantId,
        locationId: this.locationId,
        userName: this.userName,
        userId: this.userId,
        periodCode: this.periodCode,
        nextPeriodCode,
        uploadType: this.uploadtype,
        monthlyData: this.totalData
      }

      this.employeeService
        .ImportMonthlyData(data)
        .subscribe((response: any) => {
          if(response.result == 0) this.toastr.success(response.message);
          else this.toastr.error(response.message);
        }),
        (error: any) => {
          this.toastr.error('Something went wrong');
        };
    } else {
      this.toastr.warning('Invalid file or user information');
    }
  }
  
  filterRecords(term: string) {
    if (!term) {
      this.filteredData = new MatTableDataSource([...this.totalData]);
    } else {
      this.filteredData = new MatTableDataSource(this.totalData.filter((row) =>
        Object.values(row).some((val: any) =>
          val?.toString().toLowerCase().includes(term.toLowerCase())
        )
      ));
    }
  }

  clearFilter() {
    const searchTermControl = this.formGroup.get('searchTerm');
    if (searchTermControl) {
      searchTermControl.setValue('');
    }
  }

  removeRow(row: MonthlyData) {
    if(window.confirm("Are you sure to remove this item?") == false) return;
    let index = this.totalData.findIndex(d=>d.EmployeeId == row.EmployeeId);
    if(index >= 0) this.totalData.splice(index, 1);

    const tableData = this.filteredData.data;
    index = tableData.findIndex(d => d.EmployeeId === row.EmployeeId);
    if(index >= 0) {
      tableData.splice(index, 1);
      this.filteredData = new MatTableDataSource(tableData);
    }
  }
  editRow(row: MonthlyData) {
    this.editingId = row.EmployeeId;
    this.editingData = {...row};
  }
  applyRow() {
    let index = this.totalData.findIndex(d => d.EmployeeId === this.editingId);
    if(index >= 0) {
      this.totalData[index] = {...this.editingData};
    }

    const tableData = this.filteredData.data;
    index = tableData.findIndex(d => d.EmployeeId === this.editingId);
    if(index >= 0) {
      tableData[index] = {...this.editingData};
      this.filteredData = new MatTableDataSource(tableData);
    }

    this.editingId = 0;

    this.checkValidate([this.editingData]);
  }
  cancelEdit() {
    this.editingId = 0;
  }

  getComment() {
    if(this.uploadtype == '1') {
      return this.lang == "en"
        ? this.formBodyLabels[0].lblUploadMonthlyDataOnePercent.title
        : this.formBodyLabels[0].lblUploadMonthlyDataOnePercent.arabicTitle;
    } else if(this.uploadtype == '2') {
      return this.lang == "en"
        ? this.formBodyLabels[0].lblUploadMonthlyDataLoan.title
        : this.formBodyLabels[0].lblUploadMonthlyDataLoan.arabicTitle;
    } else if(this.uploadtype == '3') {
      return this.lang == "en"
        ? this.formBodyLabels[0].lblUploadMonthlyDataSalaryChange.title
        : this.formBodyLabels[0].lblUploadMonthlyDataSalaryChange.arabicTitle;
    }
  }

  onRowUpdated(updtOne: any) {

  }
}
