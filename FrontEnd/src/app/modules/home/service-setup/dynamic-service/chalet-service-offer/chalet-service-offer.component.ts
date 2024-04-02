import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-chalet-service-offer',
  templateUrl: './chalet-service-offer.component.html',
  styleUrls: ['./chalet-service-offer.component.scss']
})
export class ChaletServiceOfferComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblChaletServiceRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
