import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-healthy-food-programs-offer',
  templateUrl: './healthy-food-programs-offer.component.html',
  styleUrls: ['./healthy-food-programs-offer.component.scss']
})
export class HealthyFoodProgramsOfferComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblHealthyFoodProgramsOffer', menuId: val}
    this.headingNameValue = lableValue;
  }


}
