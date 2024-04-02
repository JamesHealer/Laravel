import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tourist-leisure-trip',
  templateUrl: './tourist-leisure-trip.component.html',
  styleUrls: ['./tourist-leisure-trip.component.scss']
})
export class TouristLeisureTripComponent implements OnInit {
  headingNameValue:any;

  constructor(private route:ActivatedRoute) { }
  ngOnInit(): void {
    var val = this.route.snapshot.paramMap.get('id');
    var lableValue = {labelData: 'lblTouristTrip', menuId: val}
    this.headingNameValue = lableValue;
  }


}
