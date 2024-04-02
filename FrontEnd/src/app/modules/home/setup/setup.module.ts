import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SetupRoutingModule } from './setup-routing.module';
import { ReferenceDetailsComponent } from './reference-details/reference-details.component';
import { AddUniversityTenantComponent } from './add-university-tenant/add-university-tenant.component';
import { AddEmployeeDiscountComponent } from './add-employee-discount/add-employee-discount.component';
import { EmployeeDiscountDetailsComponent } from './employee-discount-details/employee-discount-details.component';
import { AddEmployeeCertificateComponent } from './add-employee-certificate/add-employee-certificate.component';
import { EmployeeCertificateDetailsComponent } from './employee-certificate-details/employee-certificate-details.component';
import { AddSubscriptionComponent } from './add-subscription/add-subscription.component';
import { SubscriptionDetailsComponent } from './subscription-details/subscription-details.component';
import { SearchTabModule } from '../_partials/search-tab.module';
import { SharedModule } from '../../_sharedModule/SharedModule';
import { ManageFormLabelsComponent } from './manage-form-labels/manage-form-labels.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UpdateFormLabelsComponent } from './manage-form-labels/update-form-labels/update-form-labels.component';
import { MaterialModule } from '../../material/material.module';
import { ToastrModule } from 'ngx-toastr';
import { UserFunctionsComponent } from '../auth/users/user-functions/user-functions.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgSelectModule } from '@ng-select/ng-select';
import {MatMenuModule} from '@angular/material/menu';


@NgModule({
  declarations: [
    ReferenceDetailsComponent,
    AddUniversityTenantComponent,
    AddEmployeeDiscountComponent,
    EmployeeDiscountDetailsComponent,
    AddEmployeeCertificateComponent,
    EmployeeCertificateDetailsComponent,
    AddSubscriptionComponent,
    SubscriptionDetailsComponent,
    ManageFormLabelsComponent,
    UpdateFormLabelsComponent
  ],
  imports: [
    CommonModule,
    SetupRoutingModule,
    SearchTabModule,
    SharedModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    NgbModule,
    NgSelectModule,
    MatMenuModule
  ],
  exports:[
    NgSelectModule,
  ]
})
export class SetupModule { }
