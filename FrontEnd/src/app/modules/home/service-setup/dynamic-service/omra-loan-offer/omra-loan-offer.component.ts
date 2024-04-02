import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-omra-loan-offer',
  templateUrl: './omra-loan-offer.component.html',
  styleUrls: ['./omra-loan-offer.component.scss']
})
export class OmraLoanOfferComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblOmraLoanRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
