import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-entertainment-tickets-offer',
  templateUrl: './entertainment-tickets-offer.component.html',
  styleUrls: ['./entertainment-tickets-offer.component.scss']
})
export class EntertainmentTicketsOfferComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblEntertainmentticketsRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
