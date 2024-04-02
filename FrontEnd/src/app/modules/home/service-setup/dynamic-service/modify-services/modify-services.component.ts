import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-modify-services',
  templateUrl: './modify-services.component.html',
  styleUrls: ['./modify-services.component.scss']
})
export class ModifyServicesComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblModifyServicesRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
