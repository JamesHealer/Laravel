import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RefTableDto } from '../models/ReferenceDetails/RefTableDto';

@Injectable({
  providedIn: 'root'
})
export class ReferenceDetailsService {

  // Getting base URL of Api from enviroment.
  baseUrl = environment.KUPFApiUrl;
  //
  refTableDto: RefTableDto[] = []
  constructor(private httpClient: HttpClient) { 
  }

  // add user mst
  AddRefTable(response: RefTableDto) {
    return this.httpClient.post(this.baseUrl + `RefTable/AddRefTable`, response);
  }
  //
  DeleteRefTable(id: number) {
    return this.httpClient.delete(`${this.baseUrl}RefTable/DeleteRefTable?refId=${id}`);
  }
  //Get existing record to update...
  GetRefTableRecordsByIdRefTypeAndSubType(refid: number, refType: string, refSubType: string) {
    return this.httpClient.get<RefTableDto[]>(this.baseUrl + `RefTable/GetRefTableByIdRefTypeAndSubType/${refid}/${refType}/${refSubType}`).pipe(
      map(refTableDto => {
        this.refTableDto = refTableDto;
        return refTableDto;
      })
    )
  }

  
  //Get existing record to update 
  UpdateRefTable(response: RefTableDto) {
    return this.httpClient.put(this.baseUrl + `RefTable/UpdateRefTable`, response);
  }
  //
  /*

  GetAllRefTableRecordsByRefTypeAndSubType(refType: string, refSubType: string) {
    return this.httpClient.get<RefTableDto[]>(this.baseUrl + `RefTable/GetRefTableByRefTypeAndSubType/${refType}/${refSubType}`).pipe(
      map(refTableDto => {
        this.refTableDto = refTableDto;
        return refTableDto;
      })
    )
  }
  */

  GetAllRefTableRecordsByRefTypeAndSubType(pageNumber: number, pageSize: number, refType: string, refSubType: string, query:string) {
    return this.httpClient.get<RefTableDto[]>(this.baseUrl + `RefTable/GetRefTableByRefTypeAndSubType/${refType}/${refSubType}?PageNumber=${pageNumber}&PageSize=${pageSize}&Query=${query}`, {observe: 'response'});    
  }
  //
  GetAllRefTableRecords() {
    return this.httpClient.get<RefTableDto[]>(this.baseUrl + `RefTable/GetRefTableData`).pipe(
      map(refTableDto => {
        this.refTableDto = refTableDto;
        return refTableDto;
      })
    )
  }
}
