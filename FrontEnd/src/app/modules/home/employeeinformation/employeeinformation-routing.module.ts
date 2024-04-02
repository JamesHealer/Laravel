import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AddemployeeinformationComponent } from './addemployeeinformation/addemployeeinformation.component';
import { EditemployeeinformationComponent } from './editemployeeinformation/editemployeeinformation.component';

import { ImportEmployeeMasterComponent } from './import-employee-master/import-employee-master.component';
import { ViewContactComponent } from './view-contact/view-contact.component';
import { ViewemployeeinformationComponent } from './viewemployeeinformation/viewemployeeinformation.component';
import { EmployeePasswordResetComponent } from './employee-password-reset/employee-password-reset.component';
import { ImportMonthlyDataComponent } from './import-monthlydata/import-monthlydata.component';

const routes: Routes = [
  { path: 'add-employee', component: AddemployeeinformationComponent },
  { path: 'view-employee', component: ViewemployeeinformationComponent },
  { path: 'view-contact', component: ViewContactComponent },
  { path: 'import-employee-master', component: ImportEmployeeMasterComponent },
  { path: 'import-monthlydata/:uploadtype', component: ImportMonthlyDataComponent },
  { path: 'add-employee/:employeeId', component: AddemployeeinformationComponent },
  { path: 'employee-password-reset', component: EmployeePasswordResetComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class EmployeeinformationRoutingModule {
  constructor() {
    console.log("Employee routing component")
  }
 }
