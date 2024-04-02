import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WebsiteRoutingModule } from './website-routing.module';
import { SpecialOfferMaintenaceComponent } from './special-offer-maintenace/special-offer-maintenace.component';
import { OfferReceivedMaintenaceComponent } from './offer-received-maintenace/offer-received-maintenace.component';
import { AddCarousalComponent } from './add-carousal/add-carousal.component';
import { CarousalDetailsComponent } from './carousal-details/carousal-details.component';
import { SharedModule } from '../../_sharedModule/SharedModule';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../material/material.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { SearchTabModule } from '../_partials/search-tab.module';
import { MatMenuModule } from '@angular/material/menu';

@NgModule({
  declarations: [
    SpecialOfferMaintenaceComponent,
    OfferReceivedMaintenaceComponent,
    AddCarousalComponent,
    CarousalDetailsComponent
  ],
  imports: [
    CommonModule,
    WebsiteRoutingModule,
    SharedModule,
    BsDatepickerModule.forRoot(),
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    NgSelectModule,
    SearchTabModule, 
    MatMenuModule
    
  ],
  exports:[
    BsDatepickerModule,
    NgSelectModule,
  ]
})
export class WebsiteModule { }
