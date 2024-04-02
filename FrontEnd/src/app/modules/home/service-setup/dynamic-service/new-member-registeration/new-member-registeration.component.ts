import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-new-members-registeration',
  templateUrl: './new-member-registeration.component.html',
  styleUrls: ['./new-member-registeration.component.scss']
})
export class NewMemberRegisterationComponent implements OnInit {

  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }

  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblNewMemberRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }

}
