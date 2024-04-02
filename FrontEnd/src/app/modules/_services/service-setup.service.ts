import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ServiceSetupDto } from '../models/ServiceSetup/ServiceSetupDto';
import { UserParams } from '../models/UserParams';

@Injectable({
  providedIn: 'root'
})
export class ServiceSetupService {

  // Getting base URL of Api from enviroment.
  baseUrl = environment.KUPFApiUrl;
  //
  serviceSetupDto: ServiceSetupDto[] = []
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

  // add service setup
  AddServiceSetup(data:any) {
    return this.httpClient.post(this.baseUrl + `ServiceSetup/AddServiceSetup`, data);
  }

  //update service setup
  UpdateServiceSetup(response: any) {
    return this.httpClient.put(this.baseUrl + `ServiceSetup/EditServiceSetup`, response);
  }

  // delete service setup
  DeleteServiceSetup(id: number) {
    return this.httpClient.delete(`${this.baseUrl}ServiceSetup/DeleteServiceSetup?id=${id}`);
  }

  //Get existing record to update...
  GetServiceSetupById(id: number) {
    return this.httpClient.get<ServiceSetupDto[]>(this.baseUrl + `ServiceSetup/GetServiceSetupById/${id}`).pipe(
      map(serviceSetupDto => {
        this.serviceSetupDto = serviceSetupDto;
        return serviceSetupDto;
      })
    )
  }

  // Get all service setup
  GetAllServiceSetupRecords(userParams: UserParams, query:string) {    
    return this.httpClient.get(this.baseUrl + `ServiceSetup/GetServiceSetup?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&Query=${query}`, {observe: 'response'});    
  }
}
