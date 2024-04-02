import {HttpClient, HttpHeaders, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import {map, Observable} from 'rxjs';
import { environment } from 'src/environments/environment';
import { IncommingCommunicationDto } from '../models/CommunicationDto';
import { LettersHdDto } from '../models/LettersHdDto';
import { UserParams } from '../models/UserParams';

@Injectable({
  providedIn: 'root'
})
export class CommunicationService {

  // Getting base URL of Api from enviroment.
  baseUrl = environment.KUPFApiUrl;
  //
  incommingCommunicationDto: IncommingCommunicationDto[] = []
  lettersHdDto: LettersHdDto[]=[];

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

  // Add Incomming Letter
  AddIncomingLetter(response: FormData) {
    console.log(response);
    return this.httpClient.post(this.baseUrl + `Communication/AddIncomingLetter`, response);
  }

  UpdateIncomingLetter(response: FormData) {
    return this.httpClient.put(this.baseUrl +`Communication/UpdateIncomingLetter`,response);
  }

  // delete service setup
  DeleteIncomingLetter(transId: number) {
    return this.httpClient.delete(`${this.baseUrl}Communication/DeleteIncomingLetter/${transId}`);
  }

  // Get all service setup
  GetIncomingLetters(pageNumber: number, pageSize: number, query: string) {
    // return this.httpClient.get<IncommingCommunicationDto[]>(this.baseUrl + `Communication/GetIncomingLetters`).pipe(
    //   map(incommingCommunicationDto => {
    //     this.incommingCommunicationDto = incommingCommunicationDto;
    //     return incommingCommunicationDto;
    //   })
    // )
    return this.httpClient.get<IncommingCommunicationDto[]>(this.baseUrl + `Communication/GetIncomingLetters?PageNumber=${pageNumber}&PageSize=${pageSize}&Query=${query}`, {observe: 'response'});
  }

  GetIncomingLetter(transId: number) {
    return this.httpClient.get<LettersHdDto[]>(`${this.baseUrl}Communication/GetIncomingLetter/${transId}`).pipe(
      map(lettersHdDto => {
        this.lettersHdDto = lettersHdDto;
        return lettersHdDto;
      })
    )
  }
//==========out going letters
  // Get all service setup
  GetOutgoingLetters(pageNumber: number, pageSize: number, query: string) {
    // return this.httpClient.get<IncommingCommunicationDto[]>(this.baseUrl + `Communication/GetIncomingLetters`).pipe(
    //   map(incommingCommunicationDto => {
    //     this.incommingCommunicationDto = incommingCommunicationDto;
    //     return incommingCommunicationDto;
    //   })
    // )
    return this.httpClient.get<IncommingCommunicationDto[]>(this.baseUrl + `Communication/GetOutgoingLetters?PageNumber=${pageNumber}&PageSize=${pageSize}&Query=${query}`, {observe: 'response'});
  }

  GetEmployeeHistoryDetails(
    userParams: UserParams,
    tenentId: number,
    university: number,
    contractType: number,
    departmentFrom: number,
    departmentTo: number,
    position: number,
    serviceType: number,
    periodFrom: number,
    periodTo: number
    ) {
    return this.httpClient.get(this.baseUrl + `RefTable/GetEmployeeHistoryByFilter?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&tenentId=${tenentId}&university=${university}&contractType=${contractType}&departmentFrom=${departmentFrom}&departmentTo=${departmentTo}&position=${position}&serviceType=${serviceType}&periodFrom=${periodFrom}&periodTo=${periodTo}`, {observe: 'response'});
  }
  generateLoansDeducationReport(
    userParams: UserParams,
    tenentId: number,
    university: number,
    contractType: number,
    departmentFrom: number,
    departmentTo: number,
    position: number,
    serviceType: number,
    periodFrom: number,
    periodTo: number
  ): Observable<HttpResponse<Blob>> {
    return this.httpClient.get(this.baseUrl + `Reports/GenerateLoansDeducationReport?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&tenentId=${tenentId}&university=${university}&contractType=${contractType}&departmentFrom=${departmentFrom}&departmentTo=${departmentTo}&position=${position}&serviceType=${serviceType}&periodFrom=${periodFrom}&periodTo=${periodTo}`, {observe: 'response', responseType: 'blob' });
  }
  generateSubscribersLisReport(
    userParams: UserParams,
    tenentId: number,
    university: number,
    contractType: number,
    departmentFrom: number,
    departmentTo: number,
    position: number,
    serviceType: number,
    periodFrom: number,
    periodTo: number
  ): Observable<HttpResponse<Blob>> {
    return this.httpClient.get(this.baseUrl + `Reports/GenerateSubscribersMembersReport?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&tenentId=${tenentId}&university=${university}&contractType=${contractType}&departmentFrom=${departmentFrom}&departmentTo=${departmentTo}&position=${position}&serviceType=${serviceType}&periodFrom=${periodFrom}&periodTo=${periodTo}`, {observe: 'response', responseType: 'blob' });
  }
  generateSubscribersDeducationReport(
    userParams: UserParams,
    tenentId: number,
    university: number,
    contractType: number,
    departmentFrom: number,
    departmentTo: number,
    position: number,
    serviceType: number,
    periodFrom: number,
    periodTo: number
  ): Observable<HttpResponse<Blob>> {
    return this.httpClient.get(this.baseUrl + `Reports/GenerateSubscribeDeducationReport?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&tenentId=${tenentId}&university=${university}&contractType=${contractType}&departmentFrom=${departmentFrom}&departmentTo=${departmentTo}&position=${position}&serviceType=${serviceType}&periodFrom=${periodFrom}&periodTo=${periodTo}`, {observe: 'response', responseType: 'blob' });
  }
  generateEmployeeCertificate(
    userParams: UserParams,
    tenentId: number,
    university: number,
    contractType: number,
    departmentFrom: number,
    departmentTo: number,
    position: number,
    serviceType: number,
    periodFrom: number,
    periodTo: number
  ): Observable<HttpResponse<Blob>> {
    return this.httpClient.get(this.baseUrl + `Reports/GenerateCertificatesReport?PageNumber=${1}&PageSize=${10}&tenentId=${tenentId}&university=${university}&contractType=${contractType}&departmentFrom=${departmentFrom}&departmentTo=${departmentTo}&position=${position}&serviceType=${serviceType}&periodFrom=${periodFrom}&periodTo=${periodTo}`, {observe: 'response', responseType: 'blob' });
  }

  generateEmployeeLoansStatementsReport(
    userParams: UserParams,
    tenentId: number,
    university: number,
    contractType: number,
    departmentFrom: number,
    departmentTo: number,
    position: number,
    serviceType: number,
    periodFrom: number,
    periodTo: number
  ): Observable<HttpResponse<Blob>> {
    return this.httpClient.get(this.baseUrl + `Reports/GenerateEmployeeLoansStatementsReport?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&tenentId=${tenentId}&university=${university}&contractType=${contractType}&departmentFrom=${departmentFrom}&departmentTo=${departmentTo}&position=${position}&serviceType=${serviceType}&periodFrom=${periodFrom}&periodTo=${periodTo}`, {observe: 'response', responseType: 'blob' });
  }


  generateAssemblyReport(
    userParams: UserParams,
    tenentId: number,
    university: number,
    contractType: number,
    departmentFrom: number,
    departmentTo: number,
    position: number,
    serviceType: number,
    periodFrom: number,
    periodTo: number
  ): Observable<HttpResponse<Blob>> {
    return this.httpClient.get(this.baseUrl + `Reports/GenerateAssemblyReport?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&tenentId=${tenentId}&university=${university}&contractType=${contractType}&departmentFrom=${departmentFrom}&departmentTo=${departmentTo}&position=${position}&serviceType=${serviceType}&periodFrom=${periodFrom}&periodTo=${periodTo}`, {observe: 'response', responseType: 'blob' });
  }
}
