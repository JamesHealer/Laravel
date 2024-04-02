import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-death-health-disability',
  templateUrl: './death-health-disability.component.html',
  styleUrls: ['./death-health-disability.component.scss']
})
export class DeathHealthDisabilityComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblDeathHealthRegistration', menuId: val}
    this.headingNameValue = lableValue;
  }


}
