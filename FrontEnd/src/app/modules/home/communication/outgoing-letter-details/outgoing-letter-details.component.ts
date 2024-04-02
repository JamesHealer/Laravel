import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { IncommingCommunicationDto } from 'src/app/modules/models/CommunicationDto';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { CommonService } from 'src/app/modules/_services/common.service';
import { CommunicationService } from 'src/app/modules/_services/communication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-outgoing-letter-details',
  templateUrl: './outgoing-letter-details.component.html',
  styleUrls: ['./outgoing-letter-details.component.scss']
})
export class OutgoingLetterDetailsComponent implements OnInit {

  letterNo:number;
  userDocumentNoArray:string[]=[];
  columnsToDisplay: string[] = ['action', 'letterdated', 'lettertype', 'filledat', 'searchtag', 'description','userDocumentNo'];

  incommingCommunicationDto$: Observable<IncommingCommunicationDto[]>;

  incommingCommunicationDto: MatTableDataSource<IncommingCommunicationDto> = new MatTableDataSource<any>([]);


  @ViewChild(MatPaginator) paginator!: MatPaginator;

  // Sorting
  @ViewChild(MatSort) sort!: MatSort;

  isLoadingCompleted: boolean = false;

  // Incase of any error will display error message.
  dataLoadingStatus: string = '';

  // True of any error
  isError: boolean = false;

  // formGroup
  formGroup: FormGroup;

  // Search Term
  searchTerm: string = '';
  closeResult: string = '';
  // 
  formTitle: string;
  lang: any = '';
  
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
  pageSize: number = 10;

  /*----------------------------------------------------*/
  //#endregion

  constructor(private common: CommonService,
    private _communicationService: CommunicationService,
    private modalService: NgbModal,
    private toastrService: ToastrService,
    private router : Router
    ) {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl("")
    })
  }
  ngOnInit(): void {
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang;      
    })
    this.formTitle = this.common.getFormTitle();
    this.formTitle = '';

    this.loadData(0);
    //console.log(this.incommingCommunicationDto);
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'IncomingLetterDetails';

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {

      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {
        if (labels.formID == this.formId && labels.language == this.languageType) {
          this.formHeaderLabels.push(labels);
          this.formBodyLabels.push(labels.formTitleDTLanguage);
          console.log(this.formBodyLabels);
        }
      }   
    }
    //#endregion
  }
  selectedBtn:string = 'edit';
  selectedId:number;
  actionBtnSelect(val:string, id:number){
    this.selectedBtn = val;
    this.selectedId = id;
  }

  loadData(pageIndex: number) {
    this._communicationService.GetOutgoingLetters(pageIndex + 1, this.pageSize, this.formGroup.value.searchTerm).subscribe((response: any) => {
      this.incommingCommunicationDto = new MatTableDataSource<IncommingCommunicationDto>(response.body);
     console.log(response.body)
      this.incommingCommunicationDto.paginator = this.paginator;
      this.incommingCommunicationDto.sort = this.sort;
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
  filterRecords(pageIndex: number = -1) {
    if (this.formGroup.value.searchTerm != null && this.incommingCommunicationDto) {
      this.incommingCommunicationDto.filter = this.formGroup.value.searchTerm.trim();
    }
    if( pageIndex == 0) this.loadData(0);
    else this.loadData(this.paginator.pageIndex);
  }
  clearFilter() {
    this.formGroup?.patchValue({ searchTerm: "" });
    this.filterRecords();
  }
  onPaginationChange(event: any) {
    this.pageSize = event.pageSize;
    this.loadData(event.pageIndex);
  }

  openDeleteModal(content: any, id: number) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      if (result === 'yes') {
        console.log(id);
        this._communicationService.DeleteIncomingLetter(id).subscribe(response => {
          if (response === 1) {
              this.toastrService.success('Record deleted successfully', 'Success');
            // Refresh Grid
            this.loadData(0);
          } else {
            this.toastrService.error('Something went wrong', 'Error');
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
  
public pushCheckBoxValue(userDocumentNo:any){
  
  if(this.userDocumentNoArray.indexOf(userDocumentNo) === -1)
  {
    this.userDocumentNoArray.push(userDocumentNo);
  }
  else{
    const index =  this.userDocumentNoArray.indexOf(userDocumentNo);
    this.userDocumentNoArray.splice(index, 1);
  }
  console.log(this.userDocumentNoArray);
}
public printReport(letterNos:any){
  
  console.log(this.userDocumentNoArray);
   this.router.navigateByUrl('/communication/outgoing-barcode-Report', { state: {lNos:letterNos,uNos:this.userDocumentNoArray} });
}
}
