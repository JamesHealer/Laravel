import {ChangeDetectionStrategy, Component, OnInit} from '@angular/core';
// language list
import { TranslateService } from '@ngx-translate/core';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'body[root]',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  
  
  constructor(private translateService: TranslateService) {
   
  }

  ngOnInit() {
  } 
}
