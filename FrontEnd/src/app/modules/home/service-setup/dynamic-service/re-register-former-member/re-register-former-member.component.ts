import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-re-register-former-members',
  templateUrl: './re-register-former-member.component.html',
  styleUrls: ['./re-register-former-member.component.scss']
})
export class ReRegisterFormerMemberComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'LblReRegisterFormerMember', menuId: val}
    this.headingNameValue = lableValue;
  }


}
