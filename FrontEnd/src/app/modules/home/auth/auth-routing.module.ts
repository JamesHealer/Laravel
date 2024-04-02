import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddUserComponent } from './users/add-user/add-user.component';
import { LoginComponent } from './login/login.component';
import { UserDetailsComponent } from './users/user-details/user-details.component';
import { UserFunctionsComponent } from './users/user-functions/user-functions.component';
import { UserMstComponent } from './users/user-mst/user-mst.component';
import { FunctionMstComponent } from './users/function-mst/function-mst.component';
import { YearlyProcessComponent } from '../setup/yearly-process/yearly-process.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'add-user', component: AddUserComponent },
  { path: 'user-details', component: UserDetailsComponent },
  { path: 'user-functions', component: UserFunctionsComponent },
  { path: 'user-mst', component: UserMstComponent },
  { path: 'function-mst', component: FunctionMstComponent },
  { path: 'yearly-process', component: YearlyProcessComponent },
  { path: 'user-functions/:id', component: UserFunctionsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
