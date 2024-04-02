import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FunctionMst } from '../models/FunctionMst';
import { UserParams } from '../models/UserParams';

@Injectable({
  providedIn: 'root'
})
export class FunctionMstService {
  // Getting base URL of Api from enviroment.
  baseUrl = environment.KUPFApiUrl;
  //
  functionMst: FunctionMst[] = [];
  userParams: UserParams;
  constructor(private httpClient: HttpClient) {
    this.userParams = new UserParams();
  }

  getUserParams() {
    return this.userParams;
  }
  setUserParams(params: UserParams) {
    this.userParams = params;
  }
  AddFunctionMst(response: FunctionMst) {
    return this.httpClient.post(this.baseUrl + `FunctionMst/AddFunctionMst`, response);
  }
  DeleteFunctionMst(functionId: number) {
    return this.httpClient.delete(`${this.baseUrl}FunctionMst/DeleteFunctionMst?id=${functionId}`);
  }
  GetFunctionMstById(id: any) {
    return this.httpClient.get<FunctionMst[]>(this.baseUrl + `FunctionMst/GetFunctionMstByIdAsync/${id}`).pipe(
      map(functionMst => {
        this.functionMst = functionMst;
        return functionMst;
      })
    )
  }
  getAllFunctionMst(userParams: UserParams, query: string) {
    //if (this.functionMst.length > 0) return of(this.functionMst);
    // return this.httpClient.get<FunctionMst[]>(this.baseUrl +`FunctionMst/GetFunctionMst`).pipe(
    //   map(functionMst => {
    //     this.functionMst = functionMst;
    //     return functionMst;
    //   })
    // )
    return this.httpClient.get<FunctionMst[]>(this.baseUrl + `FunctionMst/GetFunctionMst?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&Query=${query}`, { observe: 'response' });
  }
  UpdateFunctionMst(response:FunctionMst){
    return this.httpClient.put(this.baseUrl + `FunctionMst/UpdateFunctionMst`, response);
  }

}

