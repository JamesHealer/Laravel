import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { CommonService } from 'src/app/modules/_services/common.service';
import { FormTitleHd } from 'src/app/modules/models/formTitleHd';
@Component({
  selector: 'app-html-forms',
  templateUrl: './html-forms.component.html',
  styleUrls: ['./html-forms.component.scss']
})
export class HtmlFormsComponent implements OnInit {
  @Input() accordialHTMLForms: string;
 
  englishHTML: any = '';
  arabicHtml: any = '';
  
  @Input() parentFormGroup:FormGroup;
  editorForm: FormGroup;
  config: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: '15rem',
    minHeight: '5rem',
    placeholder: 'Enter text here...',
    translate: 'yes',
    defaultParagraphSeparator: 'p',
    defaultFontName: 'Arial',
    //toolbarHiddenButtons: [['bold']],
    customClasses: [
      {
        name: 'quote',
        class: 'quote',
      },
      {
        name: 'redText',
        class: 'redText',
      },
      {
        name: 'titleText',
        class: 'titleText',
        tag: 'h1',
      },
    ],
  };
  electricform1:any;
  electricform2:any;
  attachment1: File;
  attachment2: File;

  languageType: any;

  // Selected Language
  language: any;

  // We will get form lables from lcale storage and will put into array.
  AppFormLabels: FormTitleHd[] = [];

  // We will filter form header labels array
  formHeaderLabels: any[] = [];

  // We will filter form body labels array
  formBodyLabels: any = {
    en: {},
    ar: {}
  };

  // FormId
  formId: string;
  constructor(private commonService: CommonService) { }
 
lang:string;
  ngOnInit(): void { 
    this.commonService.getLang().subscribe((lang: string) => {
      this.lang = lang;
    })
    this.languageType = localStorage.getItem('langType');

    // To get the selected language...
    this.language = localStorage.getItem('lang');

    // To setup the form id so will will get form labels based on form Id
    this.formId = 'HtmlForms';

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

    this.initializeEditorForm();
    if (this.parentFormGroup) {
      this.parentFormGroup.setControl('editorForm', this.editorForm);
    }    
  }

  initializeEditorForm() {
    this.editorForm = new FormGroup({
      englishHtml: new FormControl('', Validators.required),
      arabicHtml: new FormControl('', Validators.required),
      englishWebPageName: new FormControl('', Validators.required),
      arabicWebPageName: new FormControl('', Validators.required),
      // electronicForm1: new FormControl('', Validators.required),
      electronicForm1URL: new FormControl('', Validators.required),
      // electronicForm2: new FormControl('', Validators.required),
      electronicForm2URL: new FormControl('', Validators.required),
      webEnglish: new FormControl('', Validators.required),
      webArabic: new FormControl('', Validators.required),
      isElectronicForm:new FormControl(true)
    })
    
  }
  get editorformVal(){
    console.log(this.editorForm.controls);
    return this.editorForm.controls
  }
  //
  
  // 
  onElectronicForm1Select(event: any) {    
    if (event.target.files.length > 0) {
      const file = event.target.files[0];

      this.attachment1 = file;
      this.electricform1 = file.name;      
      this.commonService.attachment1 = this.attachment1;
      
    }
  }
  onElectronicForm2Select(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.attachment2 = file;
      this.electricform2 = file.name;      
      this.commonService.attachment2 = this.attachment2;
    }
  }
}
