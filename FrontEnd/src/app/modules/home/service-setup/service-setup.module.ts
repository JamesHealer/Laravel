import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ServiceSetupRoutingModule } from './service-setup-routing.module';
import { ServiceSetupDetailsComponent } from './service-setup-details/service-setup-details.component';
import { AddServiceSetupComponent } from './add-service-setup/add-service-setup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddServiceComponent } from './add-service/add-service.component';
import { ServiceDetailsComponent } from './service-details/service-details.component';
import { AddDocumentsComponent } from './add-documents/add-documents.component';
import { ApprovalManagementComponent } from './approval-management/approval-management.component';
import { ImportEmployeeMonthlyPaymentComponent } from './import-employee-monthly-payment/import-employee-monthly-payment.component';
import { EmployeeMovementDetailsComponent } from './employee-moment-details/employee-movement-details.component';
import { AddEmployeeMovementComponent } from './add-employee-moment/add-employee-movement.component';
import { SearchTabModule } from '../_partials/search-tab.module';
import { SharedModule } from '../../_sharedModule/SharedModule';
import { NgxTranslateModule } from '../../i18n';
import { ManageFormLabelsComponent } from '../setup/manage-form-labels/manage-form-labels.component';
import { MaterialModule } from '../../material/material.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DocumentAttachmentComponent } from '../_partials/document-attachment/document-attachment.component';
import { CashierApprovalComponent } from './cashier-approval/cashier-approval.component';
import { FinancialApprovalComponent } from './financial-approval/financial-approval.component';
import { CashierDeliveryComponent } from './cashier-delivery/cashier-delivery.component';
import { CashierDraftComponent } from './cashier-draft/cashier-draft.component';
import { FinancialDraftComponent } from './financial-draft/financial-draft.component';
import { FinancialDeliveryComponent } from './financial-delivery/financial-delivery.component';
import { ViewServiceDetailComponent } from './view-service-detail/view-service-detail.component';
import { VoucherComponent } from './voucher/voucher.component';
import { VoucherDetailsComponent } from './voucher-details/voucher-details.component';
import { GeneralVoucherComponent } from './general-voucher/general-voucher.component';
import { MatMenuModule } from '@angular/material/menu';
import { DetailModelComponent } from './detail-model/detail-model.component';
import { NewMemberRegisterationComponent } from './dynamic-service/new-member-registeration/new-member-registeration.component';
import { ReRegisterFormerMemberComponent } from './dynamic-service/re-register-former-member/re-register-former-member.component';
import { ContractExpirationComponent } from './dynamic-service/contract-expiration/contract-expiration.component';
import { CancellationFreezeComponent } from './dynamic-service/cancellation-freeze/cancellation-freeze.component';
import { DeathHealthDisabilityComponent } from './dynamic-service/death-health-disability/death-health-disability.component';
import { MembershipWithdrawalComponent } from './dynamic-service/membership-withdrawal/membership-withdrawal.component';
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
import { CommunicationsEntertainmentOfferComponent } from './dynamic-service/communications-entertainment-offer/communications-entertainment-offer.component';
import { SpringCampOfferComponent } from './dynamic-service/spring-camp-offer/spring-camp-offer.component';
import { WifiInternetOfferComponent } from './dynamic-service/wifi-internet-offer/wifi-internet-offer.component';
import { EntertainmentTvChannelOfferComponent } from './dynamic-service/entertainment-tv-channel-offer/entertainment-tv-channel-offer.component';
import { EntertainmentTicketsOfferComponent } from './dynamic-service/entertainment-tickets-offer/entertainment-tickets-offer.component';
import { HealthyFoodProgramsOfferComponent } from './dynamic-service/healthy-food-programs-offer/healthy-food-programs-offer.component';
import { HealthClubsOfferComponent } from './dynamic-service/health-clubs-offer/health-clubs-offer.component';
import { OtherLoanOfferComponent } from './dynamic-service/other-loan-offer/other-loan-offer.component';
import { CommonServiceGridComponent } from './dynamic-service/common-service-grid/common-service-grid.component';

@NgModule({
  declarations: [
    ServiceSetupDetailsComponent,
    AddServiceSetupComponent,
    AddServiceComponent,
    ServiceDetailsComponent,
    AddDocumentsComponent,
    ApprovalManagementComponent,
    ImportEmployeeMonthlyPaymentComponent,
    EmployeeMovementDetailsComponent,
    AddEmployeeMovementComponent,
    CashierApprovalComponent,
    FinancialApprovalComponent,
    CashierDeliveryComponent,
    CashierDraftComponent,
    FinancialDraftComponent,
    FinancialDeliveryComponent,
    ViewServiceDetailComponent,
    VoucherComponent,
    VoucherDetailsComponent,
    GeneralVoucherComponent,
    DetailModelComponent,
    NewMemberRegisterationComponent,
    ReRegisterFormerMemberComponent,
    ContractExpirationComponent,
    CancellationFreezeComponent,
    DeathHealthDisabilityComponent,
    MembershipWithdrawalComponent,
    AddAllTheServicesComponent,
    ModifyServicesComponent,
    ReturnAReservedAmountComponent,
    ReDeductedComponent,
    FinancialAidComponent,
    SocialLoanComponent,
    HajjLoanComponent,
    MedicalLoanComponent,
    ChaletServiceComponent,
    OmrahLoanComponent,
    CommunicationsEntertainmentComponent,
    TouristLeisureTripComponent,
    OtherLoanComponent,
    OmraLoanOfferComponent,
    ChaletServiceOfferComponent,
    CommunicationsEntertainmentOfferComponent,
    SpringCampOfferComponent,
    WifiInternetOfferComponent,
    EntertainmentTvChannelOfferComponent,
    EntertainmentTicketsOfferComponent,
    HealthyFoodProgramsOfferComponent,
    HealthClubsOfferComponent,
    OtherLoanOfferComponent,
    CommonServiceGridComponent,
  ],
  imports: [
    CommonModule,
    ServiceSetupRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    SearchTabModule,
    SharedModule,
    NgxTranslateModule,
    MaterialModule,
    NgSelectModule,
    NgbModule,
    MatMenuModule,
    // MatButtonModule

  ],
  exports: [
    NgSelectModule,

  ]
})
export class ServiceSetupModule { }
