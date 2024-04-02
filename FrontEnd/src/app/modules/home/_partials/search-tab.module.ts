import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchTabComponent } from './search-tab/search-tab.component';
import { FinancialDetialsComponent } from './financial-detials/financial-detials.component';
import { ApprovalDetialsComponent } from './approval-detials/approval-detials.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { SharedModule } from '../../_sharedModule/SharedModule';
import { SortPipe } from '../Pipes/sort.pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditFinancialDetailsComponent } from './edit-financial-details/edit-financial-details.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgSelectModule } from '@ng-select/ng-select';
import { HtmlFormsComponent } from './html-forms/html-forms.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { ElectronicFormsComponent } from './electronic-forms/electronic-forms.component';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { DocumentAttachmentComponent } from './document-attachment/document-attachment.component';
import { MaterialModule } from '../../material/material.module';



@NgModule({
  declarations: [
    SearchTabComponent,
    FinancialDetialsComponent,
    ApprovalDetialsComponent,
    ContactDetailsComponent,
    SortPipe,
    EditFinancialDetailsComponent,
    HtmlFormsComponent,
    ElectronicFormsComponent,
    DocumentAttachmentComponent,
    

  ],
  imports: [
    CommonModule,
    NgbModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    NgSelectModule,
    CKEditorModule,
    AngularEditorModule,
    TabsModule.forRoot(),
    MaterialModule
  ],
  exports: [
    SearchTabComponent,
    FinancialDetialsComponent,
    ApprovalDetialsComponent,
    ContactDetailsComponent,
    EditFinancialDetailsComponent,
    SortPipe,
    BsDatepickerModule,
    NgSelectModule,
    HtmlFormsComponent,
    ElectronicFormsComponent,
    TabsModule,
    DocumentAttachmentComponent
  ]
})
export class SearchTabModule { }
