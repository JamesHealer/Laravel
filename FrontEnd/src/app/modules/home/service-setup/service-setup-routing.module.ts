import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDocumentsComponent } from './add-documents/add-documents.component';
import { AddEmployeeMovementComponent } from './add-employee-moment/add-employee-movement.component';
import { AddServiceSetupComponent } from './add-service-setup/add-service-setup.component';
import { AddServiceComponent } from './add-service/add-service.component';
import { ApprovalManagementComponent } from './approval-management/approval-management.component';
import { EmployeeMovementDetailsComponent } from './employee-moment-details/employee-movement-details.component';
import { ImportEmployeeMonthlyPaymentComponent } from './import-employee-monthly-payment/import-employee-monthly-payment.component';
import { ManageFormLabelsComponent } from '../setup/manage-form-labels/manage-form-labels.component';


import { ServiceDetailsComponent } from './service-details/service-details.component';
import { ServiceSetupDetailsComponent } from './service-setup-details/service-setup-details.component';
import { CashierApprovalComponent } from './cashier-approval/cashier-approval.component';
import { FinancialApprovalComponent } from './financial-approval/financial-approval.component';
import { CashierDeliveryComponent } from './cashier-delivery/cashier-delivery.component';
import { CashierDraftComponent } from './cashier-draft/cashier-draft.component';
import { FinancialDeliveryComponent } from './financial-delivery/financial-delivery.component';
import { FinancialDraftComponent } from './financial-draft/financial-draft.component';
import { ViewServiceDetailComponent } from './view-service-detail/view-service-detail.component';
import { VoucherComponent } from './voucher/voucher.component';
import { VoucherDetailsComponent } from './voucher-details/voucher-details.component';
import { GeneralVoucherComponent } from './general-voucher/general-voucher.component';
import { ReRegisterFormerMemberComponent } from './dynamic-service/re-register-former-member/re-register-former-member.component';
import { NewMemberRegisterationComponent } from './dynamic-service/new-member-registeration/new-member-registeration.component';
import { AddAllTheServicesComponent } from './dynamic-service/add-all-the-services/add-all-the-services.component';
import { ModifyServicesComponent } from './dynamic-service/modify-services/modify-services.component';
import { ReturnAReservedAmountComponent } from './dynamic-service/return-a-reserved-amount/return-a-reserved-amount.component';
import { ReDeductedComponent } from './dynamic-service/re-deducted/re-deducted.component';
import { FinancialAidComponent } from './dynamic-service/financial-aid/financial-aid.component';
import { SocialLoanComponent } from './dynamic-service/social-loan/social-loan.component';
import { HajjLoanComponent } from './dynamic-service/hajj-loan/hajj-loan.component';
import { MedicalLoanComponent } from './dynamic-service/medical-loan/medical-loan.component';
import { ChaletServiceComponent } from './dynamic-service/chalet-service/chalet-service.component';
import { OmrahLoanComponent } from './dynamic-service/omrah-loan/omrah-loan.component';
import { CommunicationsEntertainmentComponent } from './dynamic-service/communications-entertainment/communications-entertainment.component';
import { TouristLeisureTripComponent } from './dynamic-service/tourist-leisure-trip/tourist-leisure-trip.component';
import { OtherLoanComponent } from './dynamic-service/other-loan/other-loan.component';
import { OmraLoanOfferComponent } from './dynamic-service/omra-loan-offer/omra-loan-offer.component';
import { ChaletServiceOfferComponent } from './dynamic-service/chalet-service-offer/chalet-service-offer.component';
import { SpringCampOfferComponent } from './dynamic-service/spring-camp-offer/spring-camp-offer.component';
import { WifiInternetOfferComponent } from './dynamic-service/wifi-internet-offer/wifi-internet-offer.component';
import { EntertainmentTvChannelOfferComponent } from './dynamic-service/entertainment-tv-channel-offer/entertainment-tv-channel-offer.component';
import { EntertainmentTicketsOfferComponent } from './dynamic-service/entertainment-tickets-offer/entertainment-tickets-offer.component';
import { HealthyFoodProgramsOfferComponent } from './dynamic-service/healthy-food-programs-offer/healthy-food-programs-offer.component';
import { HealthClubsOfferComponent } from './dynamic-service/health-clubs-offer/health-clubs-offer.component';
import { OtherLoanOfferComponent } from './dynamic-service/other-loan-offer/other-loan-offer.component';
import { ContractExpirationComponent } from './dynamic-service/contract-expiration/contract-expiration.component';
import { CancellationFreezeComponent } from './dynamic-service/cancellation-freeze/cancellation-freeze.component';
import { DeathHealthDisabilityComponent } from './dynamic-service/death-health-disability/death-health-disability.component';
import { MembershipWithdrawalComponent } from './dynamic-service/membership-withdrawal/membership-withdrawal.component';
import { CommunicationsEntertainmentOfferComponent } from './dynamic-service/communications-entertainment-offer/communications-entertainment-offer.component';

const routes: Routes = [
  { path: 'service-setup-details', component: ServiceSetupDetailsComponent },
  { path: 'add-service-setup', component: AddServiceSetupComponent },
  { path: 'add-service-setup/:serviceId', component: AddServiceSetupComponent },
  { path: 'add-service', component: AddServiceComponent },
  { path: 'add-service/:mytransid', component: AddServiceComponent },
  { path: 'service-details', component: ServiceDetailsComponent },
  { path: 'add-documents', component: AddDocumentsComponent },
  { path: 'manage-approvals', component: ApprovalManagementComponent },
  { path: 'import-emplyee-monthly-payment', component: ImportEmployeeMonthlyPaymentComponent },
  { path: 'add-employee-movement', component: AddEmployeeMovementComponent },
  { path: 'employee-movement-details', component: EmployeeMovementDetailsComponent },
  { path: 'cashier-approval', component: CashierApprovalComponent },
  { path: 'financial-approval', component: FinancialApprovalComponent },
  { path: 'cashier-delivery', component: CashierDeliveryComponent },
  { path: 'cashier-draft', component: CashierDraftComponent },
  { path: 'financial-delivery', component: FinancialDeliveryComponent },
  { path: 'financial-draft', component: FinancialDraftComponent },
  { path: 'view-service-detail/:transId', component: ViewServiceDetailComponent },
  { path: 'voucher', component: VoucherComponent },
  { path: 'voucher-details/:voucherId', component: VoucherDetailsComponent },
  { path: 'general-voucher', component: GeneralVoucherComponent },


  { path: 'new-members-registeration', component: NewMemberRegisterationComponent },
  { path: 're-register-former-members', component: ReRegisterFormerMemberComponent },
  { path: 'add-all-the-services', component: AddAllTheServicesComponent },
  { path: 'modify-services', component: ModifyServicesComponent },
  { path: 'return-a-reserved-amount', component: ReturnAReservedAmountComponent },
  { path: 're-deducted', component: ReDeductedComponent },
  { path: 'financial-aid', component: FinancialAidComponent },
  { path: 'social-loan', component: SocialLoanComponent },
  { path: 'hajj-loan', component: HajjLoanComponent },
  { path: 'medical-loan', component: MedicalLoanComponent },
  { path: 'chalet-service', component: ChaletServiceComponent },
  { path: 'omrah-loan', component: OmrahLoanComponent },
  { path: 'communications-entertainment', component: CommunicationsEntertainmentComponent },
  { path: 'tourist-leisure-trip', component: TouristLeisureTripComponent },
  { path: 'other-loan', component: OtherLoanComponent },
  { path: 'omra-loan-offer', component: OmraLoanOfferComponent},
  { path: 'chalet-service-offer', component: ChaletServiceOfferComponent },
  { path: 'communications-entertainment-offer', component: CommunicationsEntertainmentOfferComponent },
  { path: 'spring-camp-offer', component: SpringCampOfferComponent },
  { path: 'wifi-internet-offer', component: WifiInternetOfferComponent },
  { path: 'entertainment-tv-channel-offer', component: EntertainmentTvChannelOfferComponent },
  { path: 'entertainment-tickets-offer', component: EntertainmentTicketsOfferComponent },
  { path: 'healthy-food-programs-offer', component: HealthyFoodProgramsOfferComponent },
  { path: 'health-clubs-offer', component: HealthClubsOfferComponent },
  { path: 'other-loan-offer', component: OtherLoanOfferComponent },
  { path: 'contract-expiration', component: ContractExpirationComponent },
  { path: 'cancellation-freeze', component: CancellationFreezeComponent },
  { path: 'death-health-disability', component: DeathHealthDisabilityComponent },
  { path: 'membership-withdrawal', component: MembershipWithdrawalComponent },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ServiceSetupRoutingModule { }
