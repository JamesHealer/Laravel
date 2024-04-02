import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-medical-loan',
  templateUrl: './medical-loan.component.html',
  styleUrls: ['./medical-loan.component.scss']
})
export class MedicalLoanComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblMedicalLoanRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
