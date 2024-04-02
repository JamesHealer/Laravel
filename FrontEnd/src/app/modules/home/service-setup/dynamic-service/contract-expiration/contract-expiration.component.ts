import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-contract-expiration',
  templateUrl: './contract-expiration.component.html',
  styleUrls: ['./contract-expiration.component.scss']
})

export class ContractExpirationComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblContractexpirationRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }

}
