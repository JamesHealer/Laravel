import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeathDisabilityComponent } from './death-disability/death-disability.component';
import { EndofServiceComponent } from './endof-service/endof-service.component';
import { MembershipWithdrawalComponent } from './membership-withdrawal/membership-withdrawal.component';

const routes: Routes = [
  {path:'death-disability', component:DeathDisabilityComponent},
  {path:'endof-service', component:EndofServiceComponent},
  {path:'membership-withdrawal', component:MembershipWithdrawalComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TerminationRoutingModule { }
