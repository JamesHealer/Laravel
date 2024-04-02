import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CommunicationRoutingModule } from './communication-routing.module';
import { ArchieveComponent } from './archieve/archieve.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddOutgoingLettersComponent } from './add-outgoing-letters/add-outgoing-letters.component';
import { OutgoingLetterDetailsComponent } from './outgoing-letter-details/outgoing-letter-details.component';
import { AddIncomingLettersComponent } from './add-incoming-letters/add-incoming-letters.component';
import { MonthlyLoansDeductionComponent } from './monthly-loans-deduction/monthly-loans-deduction.component';
import { EmployeeDetailsWithHistoryComponent } from './employee-details-with-history/employee-details-with-history.component';


import { SharedModule } from '../../_sharedModule/SharedModule';
import { MaterialModule } from '../../material/material.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SearchTabModule } from '../_partials/search-tab.module';
import { QRCodeModule } from 'angularx-qrcode';
import {MatPaginatorModule} from '@angular/material/paginator';
import { MemberLoansStmtComponent } from './member-loan-stmt/member-loans-stmt.component';
import { MembersComponent } from './members/members.component';
import { SubscribersListComponent } from './subscribers-list/subscribers-list.component';
import { GeneralAssemblyReportComponent } from './general-assembly-report/general-assembly-report.component';
import {NgxTranslateModule} from "../../i18n";
import { PrintLabelsComponent } from './print-labels/print-labels.component';
import { IncomingLetterDetailsComponent } from './incoming-letter-details/incoming-letter-details.component';
import { SubscribersDeductionComponent } from './subscribers-deduction/subscribers-deduction.component';

@NgModule({
  declarations: [

    ArchieveComponent,
    AddOutgoingLettersComponent,
    OutgoingLetterDetailsComponent,
    AddIncomingLettersComponent,
    MonthlyLoansDeductionComponent,
    EmployeeDetailsWithHistoryComponent,
    MemberLoansStmtComponent,
    MembersComponent,
    SubscribersListComponent,
    GeneralAssemblyReportComponent,
    PrintLabelsComponent,
    IncomingLetterDetailsComponent,
    SubscribersDeductionComponent,
  ],
  imports: [
    CommonModule,
    CommunicationRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
    NgxTranslateModule,
    SearchTabModule,
    MaterialModule,
    NgSelectModule,
    NgbModule,
    QRCodeModule,
    MatPaginatorModule
  ]
})
export class CommunicationModule { }
