import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddReferenceComponent } from './add-reference/add-reference.component';
import { ReferenceDetailsComponent } from './reference-details/reference-details.component';
import { AddUniversityTenantComponent } from './add-university-tenant/add-university-tenant.component';
import { AddEmployeeDiscountComponent } from './add-employee-discount/add-employee-discount.component';
import { EmployeeDiscountDetailsComponent } from './employee-discount-details/employee-discount-details.component';
import { AddEmployeeCertificateComponent } from './add-employee-certificate/add-employee-certificate.component';
import { EmployeeCertificateDetailsComponent } from './employee-certificate-details/employee-certificate-details.component';
import { AddSubscriptionComponent } from './add-subscription/add-subscription.component';
import { SubscriptionDetailsComponent } from './subscription-details/subscription-details.component';
import { ManageFormLabelsComponent } from './manage-form-labels/manage-form-labels.component';
import { UpdateFormLabelsComponent } from './manage-form-labels/update-form-labels/update-form-labels.component';
import { UserFunctionsComponent } from '../auth/users/user-functions/user-functions.component';


const routes: Routes = [
  { path: 'add-reference', component: AddReferenceComponent },
  { path: 'reference-details', component: ReferenceDetailsComponent },
  { path: 'add-university-tenant', component: AddUniversityTenantComponent },
  { path: 'add-employee-discount', component: AddEmployeeDiscountComponent },
  { path: 'employee-discount-details', component: EmployeeDiscountDetailsComponent },
  { path: 'add-employee-certificate', component: AddEmployeeCertificateComponent },
  { path: 'employee-certificate-details', component: EmployeeCertificateDetailsComponent },
  { path: 'add-subscription', component: AddSubscriptionComponent },
  { path: 'subscription-details', component: SubscriptionDetailsComponent },
  { path: 'manage-form-labels', component: ManageFormLabelsComponent },
  { path: 'update-labels/:formID', component: UpdateFormLabelsComponent }
  

];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SetupRoutingModule { }
