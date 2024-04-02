import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hajj-loan',
  templateUrl: './hajj-loan.component.html',
  styleUrls: ['./hajj-loan.component.scss']
})
export class HajjLoanComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblHajjLoanRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
