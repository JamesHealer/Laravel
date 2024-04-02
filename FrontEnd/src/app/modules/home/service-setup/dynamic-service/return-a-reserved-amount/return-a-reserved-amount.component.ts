import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-return-a-reserved-amount',
  templateUrl: './return-a-reserved-amount.component.html',
  styleUrls: ['./return-a-reserved-amount.component.scss']
})
export class ReturnAReservedAmountComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblReturnReservedAmount', menuId: val}
    this.headingNameValue = lableValue;
  }


}
