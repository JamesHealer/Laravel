import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-omrah-loan',
  templateUrl: './omrah-loan.component.html',
  styleUrls: ['./omrah-loan.component.scss']
})
export class OmrahLoanComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblOmrahLoanRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
