import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FunctionForUserDto } from '../models/FunctionForUserDto';
import { UserFunctionDto } from '../models/UserFunctions/UserFunctionDto';

@Injectable({
  providedIn: 'root'
})
export class UserFunctionsService {

// Getting base URL of Api from enviroment.
baseUrl = environment.KUPFApiUrl;
//
userFunctions: UserFunctionDto[]=[];
//
moduleWiseMenuItems: UserFunctionDto[]=[];

  constructor(private httpClient: HttpClient) { }

  // To add functions for user....
  AddFunctionForUser(response: FunctionForUserDto) {    
    return this.httpClient.post(this.baseUrl +`FunctionUser/AddFunctionForUser`,response);
  }
  
  // Get all user functions
  GetFunctionUserByUserIdAsync(id:any) {     
    return this.httpClient.get<UserFunctionDto[]>(this.baseUrl +`FunctionUser/GetFunctionUserByUserIdAsync?id=${id}`).pipe(
      map(userFunctions => {
        this.userFunctions = userFunctions;
        return userFunctions;
      })
    )
  }

  // Get all user functions
  GetAllFunctionUsers() {     
    return this.httpClient.get<UserFunctionDto[]>(this.baseUrl +`FunctionMst/GetFunctionMst`).pipe(
      map(userFunctions => {
        this.userFunctions = userFunctions;
        return userFunctions;
      })
    )
  }

  // To get module wise menu items....
  // To fill dropdown...
  GetModuleWiseMenuItems() {     
    return this.httpClient.get<UserFunctionDto[]>(this.baseUrl +`FunctionUser/GetModuleWiseMenuItems`).pipe(
      map(userFunctions => {
        this.userFunctions = userFunctions;
        return userFunctions;
      })
    )
  }

  calculateYearlyProcessForMembership(pCode:any, loginUserId:any){
    return this.httpClient.get<any>(this.baseUrl +`FunctionUser/CalculateYearlyProcessForMembership?periodCode=${pCode}&loginusername=${loginUserId}`);
  }
 
}
