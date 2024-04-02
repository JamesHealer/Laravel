import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-communications-entertainment-offer',
  templateUrl: './communications-entertainment-offer.component.html',
  styleUrls: ['./communications-entertainment-offer.component.scss']
})
export class CommunicationsEntertainmentOfferComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblCommunicationEntertainmentOffer', menuId: val}
    this.headingNameValue = lableValue;
  }


}
