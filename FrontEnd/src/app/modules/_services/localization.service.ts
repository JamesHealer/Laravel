import { HttpClient, HttpHeaders, HttpParams, HttpParamsOptions } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FormTitleDt } from '../models/formTitleDt';
import { FormTitleHd } from '../models/formTitleHd';
import { GetDistinctHDFormName } from '../models/GetDistinctHDFormName';
import { GetFormLabels } from '../models/GetFormLables';
import { UserParams } from '../models/UserParams';

@Injectable({
  providedIn: 'root'
})
export class LocalizationService {

  // Getting base URL of Api from enviroment.
  baseUrl = environment.KUPFApiUrl;

  //
  formTitleHd: FormTitleHd[] = [];
  //
  formTitleDt: FormTitleDt[] = [];
  //
  getDistinctHDFormName: GetDistinctHDFormName[] = [];

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

  getFormHeaderLabels(formId: string, languageId: string) {
    if (this.formTitleHd.length > 0) return of(this.formTitleHd);
    return this.httpClient.get<FormTitleHd[]>(this.baseUrl + `FormLabels/GetFormHeaderLabels/` + formId + "/" + languageId).pipe(
      map(formTitleHd => {
        this.formTitleHd = formTitleHd;

        return formTitleHd;
      })
    )
  }
  getFormBodyLabels(formId: string, languageId: string) {
    if (this.formTitleDt.length > 0) return of(this.formTitleDt);
    return this.httpClient.get<FormTitleDt[]>(this.baseUrl + `FormLabels/GetFormBodyLabels/` + formId + "/" + languageId).pipe(
      map(formTitleDt => {
        this.formTitleDt = formTitleDt;
        return formTitleDt;
      })
    )
  }

  getAppLabels() {
    console.log('Get GetAllAppLabels called')
    if (this.formTitleHd.length > 0) return of(this.formTitleHd); // https://kupfapi.erp53.com/api/FormLabels/GetAllAppLabels/
    return this.httpClient.get<FormTitleHd[]>(this.baseUrl + `FormLabels/GetAllAppLabels/`).pipe(
      map(formTitleHd => {
        this.formTitleHd = formTitleHd;
        return formTitleHd;
      })
    )
  }
  // Get all form header labels.
  getAllFormHeaderLabels(userParams: any, query: string) {
    //https://kupfapi.erp53.com/api/FormLabels/GetAllFormHeaderLabels
    let list = new HttpParams();
    list = list.append('PageNumber', (userParams.pageNumber));
    list = list.append('PageSize', userParams.pageSize);
    list = list.append('Query', query);
    return this.httpClient.get<FormTitleHd[]>(this.baseUrl + `FormLabels/GetAllFormHeaderLabels`, {params:list});
  }

  // / Get all form header labels by form Id.
  GetFormHeaderLabelsByFormId(formId: string) {     //https://kupfapi.erp53.com/api/FormLabels/GetFormHeaderLabelsByFormId?formId=
    //if (this.formTitleHd.length > 0) return of(this.formTitleHd);
    return this.httpClient.get<FormTitleHd[]>(this.baseUrl + `FormLabels/GetFormHeaderLabelsByFormId?formId=`+ formId).pipe(
      map(formTitleHd => {
        this.formTitleHd = formTitleHd;
        return formTitleHd;
      })
    )
  }

  // Get all form body labels by form Id.
  GetFormBodyLabelsByFormId(formId: string, ev:any, query:any) { //    https://kupfapi.erp53.com/api/FormLabels/GetFormBodyLabelsByFormId?formId=
    return this.httpClient.get<FormTitleDt[]>(this.baseUrl + `FormLabels/GetFormBodyLabelsByFormId?PageNumber=${ev.pageNumber}&PageSize=${ev.pageSize}&Query=${query}&formId=${formId}`).pipe(
      map(formTitleDt => {
        this.formTitleDt = formTitleDt;
        return formTitleDt;
      })
    )
  }
  /**
  updateMember(members: Member) {
    return this.http.put(this.baseUrl + 'users/', members).pipe(
      map(()=>{
        const index = this.members.indexOf(members);
        this.members[index] = members;
      })
    )
  }
   */
  // To update form header labels by Id

  UpdateFormHeaderLabelsId(response: FormTitleHd) {
    return this.httpClient.put(this.baseUrl + `FormLabels/EditFormHeaderLabels`,response);
  }

  UpdateFormBodyLabelsId(response: FormTitleDt) {
    return this.httpClient.put(this.baseUrl + `FormLabels/EditFormBodyLabels`,response);
  }

}
