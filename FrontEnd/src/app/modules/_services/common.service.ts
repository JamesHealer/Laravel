import { Injectable } from '@angular/core';
import { Subject, BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  //
  employeeId: any;
  formTitle: string;
  ifEmployeeExists: Boolean;
  // We will check if Employee already subscribed OR not...
  PFId:any;
  subscribedDate:Date;
  terminationDate:Date;
  //
  attachment1: File;
  attachment2: File;

  ecform1:any;
  ecform2:any;
  // If ServiceSetup is ViewOnly...
  isViewOnly = false;
  public menuSessionUdpated = new Subject<any>();
  public empSearchClickEvent = new Subject<any>();
  private langSubject = new BehaviorSubject<string>('');
  constructor() {
  }
  sendFormTitle(title :string){
  this.formTitle = title
  }
  getFormTitle(){
    return this.formTitle;
  }
  setLang(lang: string) {
    this.langSubject.next(lang);
  }
  getLang(): Observable<string> {
    return this.langSubject.asObservable();
  }
}
