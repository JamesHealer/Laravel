import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-social-loan',
  templateUrl: './social-loan.component.html',
  styleUrls: ['./social-loan.component.scss']
})
export class SocialLoanComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblSocialLoanRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
