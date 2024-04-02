import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-spring-camp-offer',
  templateUrl: './spring-camp-offer.component.html',
  styleUrls: ['./spring-camp-offer.component.scss']
})
export class SpringCampOfferComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblSpringCampRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
