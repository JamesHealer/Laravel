import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, forkJoin, map, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ApproveRejectServiceDto } from '../models/ApproveRejectServiceDto';
import { DetailedEmployee } from '../models/DetailedEmployee';
import { CashierApprovalDto } from '../models/FinancialService/CashierApprovalDto';
import { EmployeeActivityLogDto } from '../models/FinancialService/EmployeeActivityLogDto';
import { ReturnApprovalsByEmployeeId } from '../models/FinancialService/ReturnApprovalsByEmployeeId';
import { ReturnTransactionHdDto } from '../models/FinancialService/ReturnTransactionHdDto';
import { TransactionHdDto } from '../models/FinancialService/TransactionHdDto';
import { RefTableDto } from '../models/ReferenceDetails/RefTableDto';
import { ReturnApprovalDetailsDto } from '../models/ReturnApprovalDetailsDto';
import { ReturnSearchResultDto } from '../models/ReturnSearchResultDto';
import { ReturnServiceApprovalDetails } from '../models/ReturnServiceApprovalDetails';
import { ReturnServiceApprovals } from '../models/ReturnServiceApprovals';
import { SearchEmployeeDto } from '../models/SearchEmployeeDto';
import { SelectServiceTypeDto } from '../models/ServiceSetup/SelectServiceTypeDto';
import { ServiceSetupDto } from '../models/ServiceSetup/ServiceSetupDto';
import { voucherDto } from '../models/VoucherDto';
import { voucherDetailsDto } from '../models/voucherDetailsDto';
import { UserParams } from '../models/UserParams';
import { TransactionHDDMSDto } from '../models/FinancialService/TransactionHDDMSDto';

@Injectable({
  providedIn: 'root'
})
export class FinancialService {

 // Getting base URL of Api from enviroment.
 baseUrl = environment.KUPFApiUrl;

 //
 serviceSetupDto: ServiceSetupDto[]=[];
 returnTransactionHdDto :ReturnTransactionHdDto[]=[];
   //
   transactionHdDto: TransactionHdDto[]=[]
   //
   transactionHddmsDto : TransactionHDDMSDto[]=[]
   //
   returnServiceApprovals : ReturnServiceApprovals[]=[];
   //
   returnApprovalsByEmployeeId:ReturnApprovalsByEmployeeId[]=[];
   returnManagerApprovals:CashierApprovalDto[]=[];
   //
   returnServiceApprovalDetails: ReturnServiceApprovalDetails[]=[];

   returnRefTableDto : RefTableDto[]=[];
  //
  employeeDetails: DetailedEmployee[]=[]

  userParams: UserParams;
  subScriptionId:number;

  // 
  returnEmployeeActivityLog:EmployeeActivityLogDto[]=[];
  constructor(private httpClient: HttpClient) { 
    this.userParams = new UserParams();
  }

  getUserParams() {
    return this.userParams;
  }

  setUserParams(params: UserParams) {
    this.userParams = params;
  }

  AddFinacialService(response: FormData) {
    return this.httpClient.post(this.baseUrl +`FinancialService/AddFinancialService`,response);
  }

  UpdateFinancialService(response: FormData) {    
    return this.httpClient.put(this.baseUrl +`FinancialService/UpdateFinancialService`,response);
  }
  AddDocumentAttachmentService(response: FormData) {
    return this.httpClient.post(this.baseUrl +`FinancialService/AddDocumentAttachmentService`,response);
  }
  UpdateDocumentAttachmentService(response: FormData) {
    return this.httpClient.put(this.baseUrl +`FinancialService/UpdateDocumentAttachmentService`,response);

  }
  GetDocumentAttachmentById(id:any) {    
    return this.httpClient.get<TransactionHDDMSDto[]>(this.baseUrl +`FinancialService/GetDocumentAttachmentById?transId=`+id).pipe(
      map(transactionHddmsDto => {
        this.transactionHddmsDto = transactionHddmsDto;
        return transactionHddmsDto;
      })
    )
  }
  saveCOA(reqData: any, userInfo: any) {
    let data = {
        "accountID": 0,
        "accountName": "string",
        "arabicAccountName": "string",
        "accountTypeID": 1,
        "userID": 1,
        "activityDateTime": "2022-11-29T15:23:32.336Z",
        "tenantID": 21,
        "locationID": 1,
        "InsertedID": 0
      }
    let postData: any = [];
    postData.push(data);
    return forkJoin(      
      reqData.map((d: any) => {        
        
        if (d.hasOwnProperty('loanAct')) {
          postData[0].accountID = d.loanAct;
          postData[0].accountName = d.lblloanActNameInEnglish;
          postData[0].arabicAccountName = d.lblloanActNameInArabic;
        } 
        // else if (d.hasOwnProperty('hajjAct')) {
        //   postData[0].accountID = d.hajjAct;
        //   postData[0].accountName = d.lblHajjActNameInEnglish;
        //   postData[0].arabicAccountName = d.lblHajjActNameInArabic;
        // } else if (d.hasOwnProperty('persLoanAct')) {
        //   postData[0].accountID = d.persLoanAct;
        //   postData[0].accountName = d.lblPersLoanActNameInEnglish;
        //   postData[0].arabicAccountName = d.lblPersLoanNameInArabic;
        // } else if (d.hasOwnProperty('consumerLoanAct')) {
        //   postData[0].accountID = d.consumerLoanAct;
        //   postData[0].accountName = d.lblConsumerLoanActNameInEnglish;
        //   postData[0].arabicAccountName = d.lblConsumerLoanNameInArabic;
        // } else if (d.hasOwnProperty('otherAct1')) {
        //   postData[0].accountID = d.otherAct1;
        //   postData[0].accountName = d.lblOtherAct1NameInEnglish;
        //   postData[0].arabicAccountName = d.lblOtherAct1NameInArabic;
        // } else if (d.hasOwnProperty('otherAct2')) {
        //   postData[0].accountID = d.otherAct2;
        //   postData[0].accountName = d.lblOtherAct2NameInEnglish;
        //   postData[0].arabicAccountName = d.lblOtherAct2NameInArabic;
        // } else if (d.hasOwnProperty('otherAct3')) {
        //   postData[0].accountID = d.otherAct3;
        //   postData[0].accountName = d.lblOtherAct3NameInEnglish;
        //   postData[0].arabicAccountName = d.lblOtherAct3NameInArabic;
        // } else if (d.hasOwnProperty('otherAct4')) {
        //   postData[0].accountID = d.otherAct4;
        //   postData[0].accountName = d.lblOtherAct4NameInEnglish;
        //   postData[0].arabicAccountName = d.lblOtherAct4NameInArabic;
        // } else if (d.hasOwnProperty('otherAct5')) {
        //   postData[0].accountID = d.otherAct5;
        //   postData[0].accountName = d.lblOtherAct5NameInEnglish;
        //   postData[0].arabicAccountName = d.lblOtherAct5NameInArabic;
        // }
         
        return this.httpClient.post(this.baseUrl +`FinancialService/SaveCOA`, postData);
        // .pipe(
        //   map((resp) => {
        //     return resp;
        //   })
        // )
      })
    )
  }
  GetFinancialServiceById(id:any) {    
    return this.httpClient.get<TransactionHdDto[]>(this.baseUrl +`FinancialService/GetFinancialServiceById?transId=`+id).pipe(
      map(transactionHdDto => {
        this.transactionHdDto = transactionHdDto;
        return transactionHdDto;
      })
    )
  }
  DeleteFinancialService(mytransid: number) { 
    return this.httpClient.delete(`${this.baseUrl}FinancialService/DeleteFinancialService?transId=${mytransid}`);    
  }
  /*
  GetFinancialServices() {      
    return this.httpClient.get<ReturnTransactionHdDto[]>(this.baseUrl + `FinancialService/GetFinancialServices`).pipe(
      map(returnTransactionHdDto => {
        this.returnTransactionHdDto = returnTransactionHdDto;
        return returnTransactionHdDto;
      })
    )
  }
  */

  GetFinancialServices(userParams: UserParams, query:string, filterVal:number, ServiceStatusFilterVal:number, DraftStatusFilterVal:number) {    
    return this.httpClient.get(this.baseUrl + `FinancialService/GetFinancialServices?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&Query=${query}&filterVal=${filterVal}&ServiceStatusFilterVal=${ServiceStatusFilterVal}&DraftStatusFilterVal=${DraftStatusFilterVal}`, {observe: 'response'});    
  }
  GetFinancialServicesByServiceTypeAndServiceSubType(userParams: UserParams, query:string, filterVal:number, ServiceStatusFilterVal:number, DraftStatusFilterVal:number, ServiceTypeId:number, ServiceSubTypeId:number) {    
    return this.httpClient.get(this.baseUrl + `FinancialService/GetFinancialServicesByServiceTypeAndServiceSubType?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&Query=${query}&filterVal=${filterVal}&ServiceStatusFilterVal=${ServiceStatusFilterVal}&DraftStatusFilterVal=${DraftStatusFilterVal}&ServiceTypeId=${ServiceTypeId}&ServiceSubTypeId=${ServiceSubTypeId}`, {observe: 'response'});    
  }
  GetFinancialServicesToExportExcel(filterVal:number, ServiceStatusFilterVal:number, DraftStatusFilterVal:number){
    return this.httpClient.get(this.baseUrl + `FinancialService/GetFinancialServicesToExportExcel?filterVal=${filterVal}&ServiceStatusFilterVal=${ServiceStatusFilterVal}&DraftStatusFilterVal=${DraftStatusFilterVal}`);    
  }

  GetSelectedServiceSubType(serviceType : number,serviceSubType : number, tenentId:number) {
    return this.httpClient.get<ServiceSetupDto[]>(this.baseUrl + `FinancialService/GetServiceByServiceTypeAndSubType/${serviceType}/${serviceSubType}/${tenentId}`).pipe(
      map(serviceSetupDto => {
        this.serviceSetupDto = serviceSetupDto;
        return serviceSetupDto;
      })
    )
  }
  
  GetServiceApprovals(userParams:UserParams, periodCode:number,tenentId:number,locationId:number,isShowAll:boolean, query:string) {
    return this.httpClient.get<CashierApprovalDto[]>(this.baseUrl + `FinancialService/GetServiceApprovalsAsync?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&Query=${query}&periodCode=${periodCode}&tenentId=${tenentId}&locationId=${locationId}&isShowAll=${isShowAll}`, {observe: 'response'});    
  }
  GetServiceApprovalsByEmployeeIdForManager(employeeId:number,tenentId:number,locationId:number) {      
    return this.httpClient.get<ReturnApprovalsByEmployeeId[]>(this.baseUrl + `FinancialService/GetServiceApprovalsByEmployeeIdForManager?employeeId=${employeeId}&tenentId=${tenentId}&locationId=${locationId}`).pipe(
      map(returnApprovalsByEmployeeId => {
        this.returnApprovalsByEmployeeId = returnApprovalsByEmployeeId;
        return returnApprovalsByEmployeeId;
      })
    )
  }

  GetEmployeeActivityLog(crupId:number,tenentId:number,locationId:number) {      
    return this.httpClient.get<EmployeeActivityLogDto[]>(this.baseUrl + `DisplayCrupAudit/GetEmployeeActivityLog?crupId=${crupId}&tenentId=${tenentId}&locationId=${locationId}`).pipe(
      map(returnEmployeeActivityLog => {
        this.returnEmployeeActivityLog = returnEmployeeActivityLog;
        return returnEmployeeActivityLog;
      })
    )
  }

  GetServiceApprovalsByEmployeeId(employeeId:any) {      
    return this.httpClient.get<ReturnServiceApprovals[]>(this.baseUrl + `FinancialService/GetServiceApprovalsByEmployeeId?employeeId=${employeeId}`).pipe(
      map(returnServiceApprovals => {
        this.returnServiceApprovals = returnServiceApprovals;
        return returnServiceApprovals;
      })
    )
  }
  GetServiceApprovalDetailByTransId(transId:any) {      
    return this.httpClient.get<ReturnServiceApprovalDetails[]>(this.baseUrl + `FinancialService/GetServiceApprovalDetailByTransId?transId=${transId}`).pipe(
      map(returnServiceApprovalDetails => {
        this.returnServiceApprovalDetails = returnServiceApprovalDetails;        
        return returnServiceApprovalDetails;
      })
    )
  }

  ManagerApproveService(response: ApproveRejectServiceDto) {    
    return this.httpClient.put(this.baseUrl +`FinancialService/ManagerApproveServiceAsync`,response);//ManagerApproveServiceAsync
  }
  ManagerRejectServiceAsync(response: ApproveRejectServiceDto) {    
    return this.httpClient.put(this.baseUrl +`FinancialService/ManagerRejectServiceAsync`,response);
  }

  FinanceApproveService(response: ApproveRejectServiceDto) {    
    return this.httpClient.put(this.baseUrl +`FinancialService/FinanceApproveServiceAsync`,response);
  }
  FinanceRejectServiceAsync(response: ApproveRejectServiceDto) {    
    return this.httpClient.put(this.baseUrl +`FinancialService/FinanceRejectServiceAsync`,response);
  }
  GetRejectionType() {      
    return this.httpClient.get<RefTableDto[]>(this.baseUrl + `FinancialService/GetRejectionType`).pipe(
      map(returnRefTableDto => {
        this.returnRefTableDto = returnRefTableDto;
        return returnRefTableDto;
      })
    )
  }
  //
  GetEmployeeById(id:any) {    
    return this.httpClient.get<DetailedEmployee[]>(this.baseUrl +`Employee/GetEmployeeById?employeeId=`+id).pipe(
      map(employeeDetails => {
        this.employeeDetails = employeeDetails;
        return employeeDetails;
      })
    )
  }
  GetServiceType(tenentId:number) { 
    return this.httpClient.get<SelectServiceTypeDto[]>(this.baseUrl + `FinancialService/GetServiceType?tenentId=${tenentId}`);    
  }

  GetServiceApprovalsByTransIdAsync(tenentId:number,locationId:number,transId:number) { 
    return this.httpClient.get<ReturnApprovalDetailsDto[]>(this.baseUrl + `FinancialService/GetServiceApprovalsByTransIdAsync?tenentId=${tenentId}&locationId=${locationId}&transId=${transId}`);    
  }

  SearchEmployee(searchEmployeeDto: SearchEmployeeDto) {
    return this.httpClient.post<ReturnSearchResultDto[]>(this.baseUrl + `FinancialService/SearchEmployee`,searchEmployeeDto);
  }
  SearchSponsor(searchEmployeeDto: SearchEmployeeDto) {
    return this.httpClient.post<ReturnSearchResultDto[]>(this.baseUrl + `FinancialService/SearchSponsor`,searchEmployeeDto);
  }
  SearchNewSubscriber(searchEmployeeDto: SearchEmployeeDto) {
    return this.httpClient.post<ReturnSearchResultDto[]>(this.baseUrl + `FinancialService/SearchNewSubscriber`,searchEmployeeDto);
  }
  GetCashierApprovals(userParams: UserParams, periodCode:number,tenentId:number,locationId:number,isShowAll:boolean, query:string) {    
    return this.httpClient.get(this.baseUrl + `FinancialService/GetCashierApprovals?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&periodCode=${periodCode}&tenentId=${tenentId}&locationId=${locationId}&isShowAll=${isShowAll}&Query=${query}`, {observe: 'response'});    
  }
  GetVoucherByTransId(id:number){
    return this.httpClient.get<CashierApprovalDto[]>(this.baseUrl + `Account/GetVoucherDetailsByTransId?TransId=${id}`);    
  }
  GetVoucherReport(id:number){
    return this.httpClient.post<any>(this.baseUrl + `Reports/GetVoucherReport`, {transId:id, voucherId:0});    
  }
  GetFinancialApprovals(userParams: UserParams, periodCode:number,tenentId:number,locationId:number,isShowAll:boolean, query:string) {    
    return this.httpClient.get(this.baseUrl + `FinancialService/GetFinacialApprovals?PageNumber=${userParams.pageNumber}&PageSize=${userParams.pageSize}&periodCode=${periodCode}&tenentId=${tenentId}&locationId=${locationId}&isShowAll=${isShowAll}&Query=${query}`, {observe: 'response'});    
  }
  CreateCahierDelivery(response: CashierApprovalDto) {    
    return this.httpClient.post(this.baseUrl +`FinancialService/CreateCahierDelivery`,response);
  }
  CreateCahierDraft(response: CashierApprovalDto) {    
    return this.httpClient.post(this.baseUrl +`FinancialService/CreateCahierDraft`,response);
  }
  GenerateFinancialServiceSerialNo() { 
    return this.httpClient.get<any>(this.baseUrl + `FinancialService/GenerateFinancialServiceSerialNo`);    
  }
  GetVouchers(pageNum:number, pagesize:number, query:string) {
    let list = new HttpParams();
    list = list.append('PageNumber', pageNum);
    list = list.append('PageSize', pagesize);
    list = list.append('Query', query);
    return this.httpClient.get<voucherDto[]>(this.baseUrl + `Account/GetVoucher`, {params:list});    
  }
  GetVoucherDetails(voucherId:number) { 
    return this.httpClient.get<voucherDetailsDto[]>(this.baseUrl + `Account/GetVoucherDetails?voucherId=${voucherId}`);    
  }

  GetServiceTypeSubServiceTypeByTenentId(tId:number){
    return this.httpClient.get(this.baseUrl + `FinancialService/GetServiceTypeSubServiceTypeByTenentId?tenentId=${tId}`);    
  }

  GetNewSubscription(pageNum:number, pagesize:number, query:string, tenentId:number, locationId: number) { 
    let list = new HttpParams();
    list = list.append('PageNumber', pageNum);
    list = list.append('PageSize', pagesize);
    list = list.append('Query', query);
    list = list.append('tenentId', tenentId);
    list = list.append('locationId', locationId);
    return this.httpClient.get(`${this.baseUrl}Website/GetNewSubscription`, {params:list});    
  }
}
