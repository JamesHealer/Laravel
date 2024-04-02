import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-membership-withdrawal',
  templateUrl: './membership-withdrawal.component.html',
  styleUrls: ['./membership-withdrawal.component.scss']
})
export class MembershipWithdrawalComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblMembershipWithdrawal', menuId: val}
    this.headingNameValue = lableValue;
  }


}
