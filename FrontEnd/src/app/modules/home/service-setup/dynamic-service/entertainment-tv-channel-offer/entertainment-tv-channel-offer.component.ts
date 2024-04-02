import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-entertainment-tv-channel-offer',
  templateUrl: './entertainment-tv-channel-offer.component.html',
  styleUrls: ['./entertainment-tv-channel-offer.component.scss']
})
export class EntertainmentTvChannelOfferComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblEntertainmenttvChannelOffer', menuId: val}
    this.headingNameValue = lableValue;
  }


}
