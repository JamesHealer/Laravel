import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCarousalComponent } from './add-carousal/add-carousal.component';
import { CarousalDetailsComponent } from './carousal-details/carousal-details.component';
import { OfferReceivedMaintenaceComponent } from './offer-received-maintenace/offer-received-maintenace.component';
import { SpecialOfferMaintenaceComponent } from './special-offer-maintenace/special-offer-maintenace.component';

const routes: Routes = [
  { path: 'special-offer-maintenance', component: SpecialOfferMaintenaceComponent },
  { path: 'offer-received-maintenance', component: OfferReceivedMaintenaceComponent },
  { path: 'add-carousal', component: AddCarousalComponent },
  { path: 'carousal-details', component: CarousalDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WebsiteRoutingModule { }
