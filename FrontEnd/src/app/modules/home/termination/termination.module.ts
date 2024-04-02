import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatMenuModule } from '@angular/material/menu';
import { MaterialModule } from '../../material/material.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { SearchTabModule } from '../_partials/search-tab.module';
import { SharedModule } from '../../_sharedModule/SharedModule';
import { NgxTranslateModule } from '../../i18n';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TerminationRoutingModule } from './termination-routing.module';
import { EndofServiceComponent } from './endof-service/endof-service.component';
import { DeathDisabilityComponent } from './death-disability/death-disability.component';
import { MembershipWithdrawalComponent } from './membership-withdrawal/membership-withdrawal.component';


@NgModule({
  declarations: [
    EndofServiceComponent,
    DeathDisabilityComponent,
    MembershipWithdrawalComponent
  ],
  imports: [
    CommonModule,
    TerminationRoutingModule,
    NgbModule,
    MatMenuModule,
    MaterialModule,
    NgSelectModule,
    SearchTabModule,
    SharedModule,
    NgxTranslateModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class TerminationModule { }
