import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-re-deducted',
  templateUrl: './re-deducted.component.html',
  styleUrls: ['./re-deducted.component.scss']
})
export class ReDeductedComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblRedeductedRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
