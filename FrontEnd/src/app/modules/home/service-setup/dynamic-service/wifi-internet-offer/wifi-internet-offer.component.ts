import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-wifi-internet-offer',
  templateUrl: './wifi-internet-offer.component.html',
  styleUrls: ['./wifi-internet-offer.component.scss']
})
export class WifiInternetOfferComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblWiFiInternetOffer', menuId: val}
    this.headingNameValue = lableValue;
  }


}
