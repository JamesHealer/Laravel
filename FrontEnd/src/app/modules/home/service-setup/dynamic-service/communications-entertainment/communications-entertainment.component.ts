import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-communications-entertainment',
  templateUrl: './communications-entertainment.component.html',
  styleUrls: ['./communications-entertainment.component.scss']
})
export class CommunicationsEntertainmentComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblCommunications&Registration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
