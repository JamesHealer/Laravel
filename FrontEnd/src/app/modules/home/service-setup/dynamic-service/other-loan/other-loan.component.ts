import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-other-loan',
  templateUrl: './other-loan.component.html',
  styleUrls: ['./other-loan.component.scss']
})
export class OtherLoanComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblOtherLoanRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
