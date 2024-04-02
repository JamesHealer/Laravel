import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, Observable, BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Login } from '../models/login';
import { MenuHeading } from '../models/MenuHeading';
import { SelectOccupationsDto } from '../models/SelectOccupationsDto';
import { UserFunctionDto } from '../models/UserFunctions/UserFunctionDto';
import { DbCommonService } from './db-common.service';
import {MenuItems} from "../models/MenuItems";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

/*  const newItem: MenuItems = {
    menuItemNameEnglish: 'New Menu Item',
    menuItemNameArabic: 'قائمة جديدة',
    // Add other properties as needed
    menuItemURLOption: '/communication/subscribers-deduction',
    menuItems: [] // If the new item has sub-items, provide them here
  };*/
// Getting base URL of Api from enviroment.
  baseUrl = environment.KUPFApiUrl;
  private isLoadingSubject = new BehaviorSubject<boolean>(false);
  //
  loginDto: Login[];
  //
  menuHeading: MenuHeading[]=[];

  occupationsDto$: Observable<SelectOccupationsDto[]>;
  occupationsDto: SelectOccupationsDto[]=[];

  constructor(private httpClient: HttpClient,
    private router: Router,
    private toastr: ToastrService
    ) {

    }
  // Get user funtions by user Id... this.baseUrl +`FinancialService/GetFinancialServiceById?transId=`
  GetUserFunctionsByUserId(id:number) {
    return this.httpClient.get<any[]>(this.baseUrl + `Login/GetUserFunctionsByUserId?id=${id}`,).pipe(
        map((menuHeading: any[]) => {
          menuHeading[6].menuItems[1].menuItems[3].menuItemURLOption = '/communication/subscribers-deduction';
          menuHeading[6].menuItems[1].menuItems[6].menuItemURLOption = '/communication/general-assembly-report';
          this.menuHeading = menuHeading;
          return menuHeading;
        }))

  }

  // https://kupfapi.erp53.com/api/Common/RefreshUpdatedData?tenentid=21
  RefreshUpdatedData(tId:number){
    return this.httpClient.get<any>(this.baseUrl + `Common/RefreshUpdatedData?id=${tId}`);
  }

  set isLoading(isLoading: boolean) {
    this.isLoadingSubject.next(isLoading);
  }
  get isLoading$(): Observable<boolean> {
    return this.isLoadingSubject.asObservable();
  }

  // Login
  Login(model : Array<string>) {
    console.log(this.baseUrl);
    //return this.httpClient.get<Login[]>('/app/_fake/fake_users.json');
    //return this.httpClient.get<Login[]>('/assets/fake_users.json');
    this.isLoading = true;
    return this.httpClient.post<Login[]>(this.baseUrl + `Login/EmployeeLogin`, {
      tenentId:model[0],
      username:model[1],
      password:model[2]
    }).pipe(
        map((loginDto: Login[]) => {
          this.loginDto = loginDto;
          return loginDto;
        }))
  }

  logout(){
    this.router.navigateByUrl('/login')
    localStorage.removeItem('user');
  }
}
