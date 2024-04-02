import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-financial-aid',
  templateUrl: './financial-aid.component.html',
  styleUrls: ['./financial-aid.component.scss']
})
export class FinancialAidComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblFinancialaidRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
