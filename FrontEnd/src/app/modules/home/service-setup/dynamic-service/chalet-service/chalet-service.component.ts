import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-chalet-service',
  templateUrl: './chalet-service.component.html',
  styleUrls: ['./chalet-service.component.scss']
})
export class ChaletServiceComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblChaletServiceRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }

}
