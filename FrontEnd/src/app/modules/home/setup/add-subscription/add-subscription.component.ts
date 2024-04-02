import { Component, ElementRef, OnInit, ViewChild, Input } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable } from 'rxjs';
import { FormTitleDt } from 'src/app/modules/models/formTitleDt';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
import { LocalizationService } from 'src/app/modules/_services/localization.service';
import { CommonService } from 'src/app/modules/_services/common.service';

@Component({
  selector: 'app-add-subscription',
  templateUrl: './add-subscription.component.html',
  styleUrls: ['./add-subscription.component.scss']
})
export class AddSubscriptionComponent implements OnInit {
  // /*********************/
  // formHeaderLabels$: Observable<FormTitleHd[]>;
  // formBodyLabels$: Observable<FormTitleDt[]>;
  // formBodyLabels: FormTitleDt[] = [];
  // id: string = '';
  // languageId: any;
  // // FormId to get form/App language
  // @ViewChild('AddSubscription') hidden: ElementRef;
  // /*********************/
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

    /*----------------------------------------------------*/  
  //#endregion
  
  closeResult: string = '';
  constructor(private modalService: NgbModal,
    private localizationService: LocalizationService,
    private router: Router,
    public commonService:CommonService,
    private activatedRout:ActivatedRoute) {
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }
lang:string;
  ngOnInit(): void {
    
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang;
    })
    //#region TO SETUP THE FORM LOCALIZATION    
    // TO GET THE LANGUAGE ID e.g. 1 = ENGLISH and 2 =  ARABIC
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'AddSubscription';

    // Check if LocalStorage is Not NULL
    if (localStorage.getItem('AppLabels') != null) {

      // Get data from LocalStorage
      this.AppFormLabels = JSON.parse(localStorage.getItem('AppLabels') || '{}');

      for (let labels of this.AppFormLabels) {

        if (labels.formID == this.formId && labels.language == this.languageType) {

          this.formHeaderLabels.push(labels);

          this.formBodyLabels.push(labels.formTitleDTLanguage);

        }
      }
      console.log(this.formBodyLabels);
    }
    //#endregion

    // this.languageId = localStorage.getItem('langType');

    // // // Get form header labels
    // this.formHeaderLabels$ = this.localizationService.getFormHeaderLabels('AddSubscription', this.languageId);

    // // Get form body labels
    // this.formBodyLabels$ = this.localizationService.getFormBodyLabels('AddSubscription', this.languageId)

    // // Get observable as normal array of items
    // this.formBodyLabels$.subscribe((data) => {
    //   this.formBodyLabels = data
    //   console.log(data);
    // }, error => {
    //   console.log(error);
    // })
    
  }


  open(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title', modalDialogClass: 'modal-lg' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
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
  







}
