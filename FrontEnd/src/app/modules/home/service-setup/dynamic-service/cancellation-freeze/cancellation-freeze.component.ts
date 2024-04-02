import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cancellation-freeze',
  templateUrl: './cancellation-freeze.component.html',
  styleUrls: ['./cancellation-freeze.component.scss']
})
export class CancellationFreezeComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblCancellationFreezeRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }

}
