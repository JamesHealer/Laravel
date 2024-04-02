import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DeleteDataDto } from '../models/DeleteDataDto';
import { DetailedEmployee } from '../models/DetailedEmployee';
import { UserParams } from '../models/UserParams';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {


  // Getting base URL of Api from enviroment.
  baseUrl = environment.KUPFApiUrl;
  //
  employeeDetails: DetailedEmployee[] = [];
  userParams: UserParams;
  //
  // totalRows = 0;
  // pageSize = 10;
  // pageNumber = 0;
  // pageSizeOptions: number[] = [5, 10, 25, 100];

  constructor(private httpClient: HttpClient) {
    this.userParams = new UserParams();
  }
  getUserParams() {
    return this.userParams;
  }
  setUserParams(params: UserParams) {
    this.userParams = params;
  }

  AddEmployee(response: DetailedEmployee) {
    return this.httpClient.post(this.baseUrl + `Employee/AddEmployee`, response);
  }

  validateEmployeeId(tenantId:any, locationId:any, employeeId: any) {
    return this.httpClient.get(this.baseUrl + `Employee/ValidateEmployeeId?tenantId=${tenantId}&locationId=${locationId}&employeeId=${employeeId}`);
  }
  ValidateEmployeeData(response: DetailedEmployee) {
    return this.httpClient.post(this.baseUrl + `Employee/ValidateEmployeeData`, response);
  }
  UpdateEmployee(response: DetailedEmployee) {
    return this.httpClient.put(this.baseUrl + `Employee/UpdateEmployee`, response);
  }
  GetEmployeeById(id: any) {
    return this.httpClient.get<DetailedEmployee[]>(this.baseUrl + `Employee/GetEmployeeById?employeeId=` + id).pipe(
      map(employeeDetails => {
        this.employeeDetails = employeeDetails;
        return employeeDetails;
      })
    )
  }
  DeleteEmployee(dtailedEmployee: DetailedEmployee) {
    return this.httpClient.post(`${this.baseUrl}Employee/DeleteEmployee`, dtailedEmployee);
  }
  GetEmployees(userParams: UserParams, query: string) {
    return this.httpClient.get(this.baseUrl + `Employee/GetEmployees?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&Query=${query}`, { observe: 'response' });
  }

  FilterEmployee(userParams: UserParams, query: string, filterVal: any) {
    return this.httpClient.get(this.baseUrl + `Employee/FilterEmployee?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&Query=${query}&filterVal=${filterVal}`, { observe: 'response' });
  }
  PrintLabel(userParams: UserParams, query: string, filterVal: any) {
    return this.httpClient.get(this.baseUrl + `Employee/PrintLabel?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&Query=${query}&filterVal=${filterVal}`, { observe: 'response' });
  }
  GetImportDataUploader(tenantId:number){
    return this.httpClient.get(this.baseUrl + `Common/GetImportDataUploader?tenentid=${tenantId}`);
  }
  AddEmployeeServiceData(gridValue:any){
    return this.httpClient.post(this.baseUrl + `Employee/AddEmployeeServiceData`, gridValue);
  }
  // https://kupfapi.erp53.com/api/Employee/EmployeeServiceDataDraftSubmit
  EmployeeServiceDataDraftSubmit(gridValue:any){
    return this.httpClient.post(this.baseUrl + `Employee/EmployeeServiceDataDraftSubmit`, gridValue);
  }
  DeletEmployeeImportServiceData(gridValue:any){
    return this.httpClient.post(this.baseUrl + `Employee/DeletEmployeeImportServiceData`, gridValue);
  }
  getEmployeeImportServiceData(tenantId:number, pCode:any, val:number, sampleFile:string){
    return this.httpClient.get(this.baseUrl + `Employee/GetEmployeeImportServiceData?tenantId=${tenantId}&periodCode=${pCode}&DataImportFilterValue=${val}&UploaderType=${sampleFile}`);
  }
  DownloadSampleFile(sampleFileName: string) {
    return this.httpClient.get(this.baseUrl + `Employee/DownloadSampleFile?fileName=${sampleFileName}`, { responseType: 'blob' });
  }
  UploadEmployeeExcelFile(formData: FormData) {
    // const headers = new HttpHeaders({
    //   'Content-Type': 'multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW',
    // });
    return this.httpClient.post(this.baseUrl + `Employee/UploadEmployeeExcelFile`,formData);
  }
  ImportEmployeeData(employeeData: any) {
    return this.httpClient.post(this.baseUrl + `Employee/ImportEmployeeData`, employeeData);
  }
  CheckMonthlyData(monthlyData: any) {
    return this.httpClient.post(this.baseUrl + `Employee/CheckMonthlyData`, monthlyData);
  }
  ImportMonthlyData(monthlyData: any) {
    return this.httpClient.post(this.baseUrl + `Employee/ImportMonthlyData`, monthlyData);
  }

  ResetEmployeePassword(formData:any){
    return this.httpClient.get(this.baseUrl + `Login/ResetEmployeePassword?employeeId=${formData.employeeId}&Password=${formData.Password}&MobileNo=${formData.MobileNo}&Emailid=${formData.Emailid}&EmployeeLoginId=${formData.EmployeeLoginId}`);
  }

}
