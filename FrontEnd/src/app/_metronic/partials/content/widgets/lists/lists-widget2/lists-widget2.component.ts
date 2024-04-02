import { Component, Input } from '@angular/core';
import { CommonService } from 'src/app/modules/_services/common.service';

@Component({
  selector: 'app-lists-widget2',
  templateUrl: './lists-widget2.component.html',
})
export class ListsWidget2Component {
  lang:string='';
  @Input() latestSubscriberData:any;
  constructor(private common: CommonService) {}

  ngOnInit(){
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    // console.log(this.latestSubscriberData);
  }
}
