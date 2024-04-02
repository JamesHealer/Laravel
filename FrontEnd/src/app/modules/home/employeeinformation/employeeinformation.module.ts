import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeinformationRoutingModule } from './employeeinformation-routing.module';
import { AddemployeeinformationComponent } from './addemployeeinformation/addemployeeinformation.component';
import { InlineSVGModule } from 'ng-inline-svg-2';
import { DropdownMenusModule, WidgetsModule } from 'src/app/_metronic/partials';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from '../../_forms/text-input/text-input.component';
import { ImportEmployeeMasterComponent } from './import-employee-master/import-employee-master.component';
import { FilterLabelsPipe } from '../Pipes/filter-labels.pipe';
import { SharedModule } from '../../_sharedModule/SharedModule';
import { ViewemployeeinformationComponent } from './viewemployeeinformation/viewemployeeinformation.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { SearchTabModule } from '../_partials/search-tab.module';
import { MaterialModule } from '../../material/material.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EditemployeeinformationComponent } from './editemployeeinformation/editemployeeinformation.component';
import { EmployeePasswordResetComponent } from './employee-password-reset/employee-password-reset.component';
import { EditEmployeeModalComponent } from './editemployeemodal/editemployeemodal.component';
import { ImportMonthlyDataComponent } from './import-monthlydata/import-monthlydata.component';

@NgModule({
  declarations: [
    AddemployeeinformationComponent,
    TextInputComponent,
    ImportEmployeeMasterComponent,
    ViewemployeeinformationComponent,
    EditemployeeinformationComponent,
    EmployeePasswordResetComponent,
    EditEmployeeModalComponent,
    ImportMonthlyDataComponent  

  ],
  imports: [
    CommonModule,
    EmployeeinformationRoutingModule,
    InlineSVGModule,
    DropdownMenusModule,
    WidgetsModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    SearchTabModule,
    MaterialModule,
    NgSelectModule,
    NgbModule
  ],
  exports:[
    BsDatepickerModule,
    BsDropdownModule,
    NgSelectModule,
  ]
})
export class EmployeeinformationModule {
  constructor(){
    console.log("Employee module")
  }
 }
