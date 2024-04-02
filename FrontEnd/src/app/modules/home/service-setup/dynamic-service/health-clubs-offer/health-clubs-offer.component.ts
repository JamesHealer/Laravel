import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-health-clubs-offer',
  templateUrl: './health-clubs-offer.component.html',
  styleUrls: ['./health-clubs-offer.component.scss']
})
export class HealthClubsOfferComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblHealthclubsRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }

}
