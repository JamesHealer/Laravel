import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddIncomingLettersComponent } from './add-incoming-letters/add-incoming-letters.component';
import { AddOutgoingLettersComponent } from './add-outgoing-letters/add-outgoing-letters.component';
import { ArchieveComponent } from './archieve/archieve.component';
import { GeneralAssemblyReportComponent } from './general-assembly-report/general-assembly-report.component';
import { OutgoingLetterDetailsComponent } from './outgoing-letter-details/outgoing-letter-details.component';
import { EmployeeDetailsWithHistoryComponent } from './employee-details-with-history/employee-details-with-history.component';
import { MonthlyLoansDeductionComponent } from './monthly-loans-deduction/monthly-loans-deduction.component';
import { MemberLoansStmtComponent } from './member-loan-stmt/member-loans-stmt.component';
import {SubscribersListComponent} from "./subscribers-list/subscribers-list.component";
import {MembersComponent} from "./members/members.component";
import {PrintLabelsComponent} from "./print-labels/print-labels.component";
import {IncomingLetterDetailsComponent} from "./incoming-letter-details/incoming-letter-details.component";
import {SubscribersDeductionComponent} from "./subscribers-deduction/subscribers-deduction.component";

const routes: Routes = [

  { path: 'archieve', component: ArchieveComponent },
  { path: 'add-outgoing-letter', component: AddOutgoingLettersComponent },
  { path: 'outgoing-letter-details', component: OutgoingLetterDetailsComponent },
  { path: 'add-incoming-letter', component: AddIncomingLettersComponent },
  { path: 'add-incoming-letter/:mytransid', component: AddIncomingLettersComponent },
  { path: 'add-outgoing-letter/:mytransid', component: AddOutgoingLettersComponent },
  { path: 'incoming-letter-details', component: IncomingLetterDetailsComponent },
  { path: 'report/monthly-loan-deduction', component: MonthlyLoansDeductionComponent },
  { path: 'report/member-loan-statement', component: MemberLoansStmtComponent },
  { path: 'report/members', component: MembersComponent },
  { path: 'employee-history-details', component: EmployeeDetailsWithHistoryComponent},
  { path: 'report/subscribers-list', component: SubscribersListComponent},
  { path: 'general-assembly-report', component: GeneralAssemblyReportComponent},
  { path: 'print-labels', component: PrintLabelsComponent},
  {path: 'subscribers-deduction', component: SubscribersDeductionComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CommunicationRoutingModule { }
