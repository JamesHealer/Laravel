import { Component, Input, OnInit } from '@angular/core';
import { CommonService } from 'src/app/modules/_services/common.service';

type Tabs =
  | 'kt_table_widget_5_tab_1'
  | 'kt_table_widget_5_tab_2'
  | 'kt_table_widget_5_tab_3';

@Component({
  selector: 'app-tables-widget5',
  templateUrl: './tables-widget5.component.html',
})
export class TablesWidget5Component implements OnInit {
  lang:string='';
  @Input() newMembersData:any;
  constructor(private common: CommonService) {}

  activeTab: Tabs = 'kt_table_widget_5_tab_1';

  setTab(tab: Tabs) {
    this.activeTab = tab;
  }

  activeClass(tab: Tabs) {
    return tab === this.activeTab ? 'show active' : '';
  }

  ngOnInit(): void {
    this.common.getLang().subscribe((lang: string) => {
      this.lang = lang
    })
    console.log(this.newMembersData);
  }
}
