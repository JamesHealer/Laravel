import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CoaDto } from '../models/CoaDto';
import { SelectConsumerLoanAcDto } from '../models/SelectConsumerLoanActDto';
import { SelectDepartmentsDto } from '../models/SelectDepartmentsDto';
import { SelectHajjAcDto } from '../models/SelectHajjAcDto';
import { SelectLoanAcDto } from '../models/SelectLoanAcDto';
import { SelectMasterIdDto } from '../models/SelectMasterIdDto';
import { SelectOccupationsDto } from '../models/SelectOccupationsDto';
import { SelectOtherAct1Dto } from '../models/SelectOtherAct1Dto';
import { SelectOtherAct2Dto } from '../models/SelectOtherAct2Dto';
import { SelectOtherAct3Dto } from '../models/SelectOtherAct3Dto';
import { SelectOtherAct4Dto } from '../models/SelectOtherAct4Dto';
import { SelectPerLoanActDto } from '../models/SelectPerLoanActDto';
import { SelectRefSubTypeDto } from '../models/SelectRefSubTypeDto';
import { SelectRefTypeDto } from '../models/ReferenceDetails/SelectRefTypeDto';
import { SelectTerminationsDto } from '../models/SelectTerminationsDto';
import { SelectUsersDto } from '../models/SelectUsersDto';
import { SelectServiceTypeDto } from '../models/ServiceSetup/SelectServiceTypeDto';
import { SelectMaxInstallmentDto } from '../models/ServiceSetup/SelectMaxInstallmentDto';
import { SelectMinInstallmentDto } from '../models/ServiceSetup/SelectMinInstallmentDto';
import { SelectMinMonthOfServicesDto } from '../models/ServiceSetup/SelectMinMonthOfServicesDto';
import { SelectApprovalRoleDto } from '../models/ServiceSetup/SelectApprovalRoleDto';
import { DetailedEmployee } from '../models/DetailedEmployee';
import { SearchEmployeeDto } from '../models/SearchEmployeeDto';
import { SelectServiceSubTypeDto } from '../models/ServiceSetup/SelectServiceSubTypeDto';
import { SelectMasterServiceTypeDto } from '../models/ServiceSetup/SelectMasterServiceTypeDto';
import { SelectedServiceTypeDto } from '../models/ServiceSetup/SelectedServiceTypeDto';
import { SelectedServiceSubTypeDto } from '../models/ServiceSetup/SelectedServiceSubTypeDto';
import { FinanaceCalculationDto } from '../models/FinancialService/FinanaceCalculationDto';
import { CashierInformationDto } from '../models/FinancialService/CashierInformationDto';
import { SelectBankAccount } from '../models/SelectBankAccount';
import { CashierApprovalDto } from '../models/FinancialService/CashierApprovalDto';
import { UniversityDto } from '../models/UniversityDto';

import { CountriesDto } from '../models/CountriesDto';
import { dashboardResponseDto, loanPercentageDto, SelectLetterTypeDTo, SelectPartyTypeDTo } from '../models/CommunicationDto';
import { SelectServiceTabDto } from '../models/SelectServiceTabDto';

@Injectable({
  providedIn: 'root'
})
export class DbCommonService {

  // Getting base URL of Api from enviroment.
  baseUrl = environment.KUPFApiUrl;
  //
  occupationsDto: SelectOccupationsDto[] = [];
  //
  contractTypeDto: SelectOccupationsDto[] = [];
  //
  departmentsDto: SelectDepartmentsDto[] = [];
  //
  terminationDto: SelectTerminationsDto[] = [];
  //
  hajjAcDto: SelectHajjAcDto[] = [];
  //
  loanAcDto: SelectLoanAcDto[] = [];
  //
  perLoanAcDto: SelectPerLoanActDto[] = [];
  //
  consumerLoanAcDto: SelectConsumerLoanAcDto[] = [];
  //
  otherAct1: SelectOtherAct1Dto[] = [];
  //
  otherAct2: SelectOtherAct2Dto[] = [];
  //
  otherAct3: SelectOtherAct3Dto[] = [];
  //
  otherAct4: SelectOtherAct4Dto[] = [];
  //
  coaDto: CoaDto[] = [];
  //
  users: SelectUsersDto[] = [];
  //
  masterIds: SelectMasterIdDto[] = [];
  //
  refSubType: SelectRefSubTypeDto[] = [];
  //
  refType: SelectRefTypeDto[] = [];
  //
  serviceType: SelectServiceTypeDto[] = [];
  //
  serviceSubType: SelectServiceSubTypeDto[] = [];
  //
  selectedServiceType: SelectedServiceTypeDto[] = [];
  //
  selectedServiceSubType: SelectedServiceSubTypeDto[] = [];
  //
  masterServiceType: SelectMasterServiceTypeDto[] = [];
  //
  minMonthOfServices: SelectMinMonthOfServicesDto[] = [];
  //
  minInstallment: SelectMinInstallmentDto[] = [];
  //
  maxInstallment: SelectMaxInstallmentDto[] = [];
  //
  approvalRoles: SelectApprovalRoleDto[] = [];

  //
  detailedEmployee: DetailedEmployee[] = [];
  //
  selectBankAccount: SelectBankAccount[] = [];
  //selectedMasterIds: any[] = [];

  //loanAct: number;
  letterTypeDTo: SelectLetterTypeDTo[] = [];

  partyType: SelectPartyTypeDTo[] = [];
  //
  countriesList: CountriesDto[] = [];

  universityList: UniversityDto[] = [];
  //
  ServiceTabDto: SelectServiceTabDto[] = [];
  constructor(private httpClient: HttpClient, private toastr: ToastrService) { }


  GetCountryList() {
    return this.httpClient.get<CountriesDto[]>(this.baseUrl + `Common/GetCountryList`).pipe(
      map(countriesList => {
        this.countriesList = countriesList;
        return countriesList;
      })
    )
  }

  GetUniversities() {
    return this.httpClient.get<UniversityDto[]>(this.baseUrl + `Common/GetUniversityList`).pipe(
      map(universityList => {
        this.universityList = universityList;
        return universityList;
      })
    )
  }

  // Search employee...
  SearchEmployee(searchEmployeeDto: SearchEmployeeDto) {
    return this.httpClient.post<DetailedEmployee[]>(this.baseUrl + `Common/SearchEmployee`, searchEmployeeDto);
  }
  GetBankAccounts(tenentId: number, locationId: number) {
    return this.httpClient.get<SelectBankAccount[]>(this.baseUrl + `Common/GetBankAccounts?tenentId=${tenentId}&locationId=${locationId}`).pipe(
      map(selectBankAccount => {
        this.selectBankAccount = selectBankAccount;
        return selectBankAccount;
      })
    )
  }
  GetDraftInformationByEmployeeId(employeeId:number, tenentId:number, locationId:number, transactionId:number) { 
    return this.httpClient.get<CashierApprovalDto[]>(this.baseUrl + `Common/GetDraftInformationByEmployeeId?employeeId=${employeeId}&tenentId=${tenentId}&locationId=${locationId}&transactionId=${transactionId}`);    
  }
  

  //#region Add Service
  GetSelectedServiceType(tenentId: number) {
    return this.httpClient.get<SelectedServiceTypeDto[]>(this.baseUrl + `Common/GetSelectedServiceType?tenentId=${tenentId}`).pipe(
      map(selectedServiceType => {
        this.selectedServiceType = selectedServiceType;
        return selectedServiceType;
      })
    )
  }
  GetSelectedServiceSubType(tenentId: number) {
    return this.httpClient.get<SelectedServiceSubTypeDto[]>(this.baseUrl + `Common/GetSelectedServiceSubType?tenentId=${tenentId}`).pipe(
      map(selectedServiceSubType => {
        this.selectedServiceSubType = selectedServiceSubType;
        return selectedServiceSubType;
      })
    )
  }
  GetServiceType(tenentId: number) {
    return this.httpClient.get<SelectServiceTypeDto[]>(this.baseUrl + `Common/GetServiceType?tenentId=${tenentId}`);
  }
  GetSubServiceTypeByServiceType(tenentId: number, refId: number) {
    return this.httpClient.get<SelectServiceTypeDto[]>(this.baseUrl + `FinancialService/GetSubServiceTypeByServiceType?tenentId=${tenentId}&refId=${refId}`);
  }

  GetDocTypes(tenentId: number) {
    return this.httpClient.get<SelectServiceTypeDto[]>(this.baseUrl + `Common/GetDocTypes?tenentId=${tenentId}`);
  }

  GetOffers() {
    return this.httpClient.get<SelectServiceTypeDto[]>(this.baseUrl + `Common/GetOffers`);
  }
  //#endregion
  GetFinancialCalculationByEmployeeId(employeeId: number, tenentId: number, locationId: number, transactionDate: any) {
    return this.httpClient.get<FinanaceCalculationDto>(this.baseUrl + `Common/GetFinancialCalculationByEmployeeId?employeeId=${employeeId}&tenentId=${tenentId}&locationId=${locationId}&transactionDate=${transactionDate}`);
  }
  GetCashierInformationByEmployeeId(employeeId: number, tenentId: number, locationId: number, transactionId: number) {
    return this.httpClient.get<CashierInformationDto>(this.baseUrl + `Common/GetCashierInformationByEmployeeId?employeeId=${employeeId}&tenentId=${tenentId}&locationId=${locationId}&transactionId=${transactionId}`);
  }
  //#region Service Setup 
  // Get GetServiceTypes...
  GetServiceTypeByMasterIds(selectedMasterIds: any[]) {
    return this.httpClient.post<SelectServiceTypeDto[]>(this.baseUrl + `Common/GetServiceTypeByMasterIds`, selectedMasterIds);
  }
  // Get GetServiceTypes...
  GetServiceSubTypes(switchNo: any) {
    return this.httpClient.get<SelectServiceSubTypeDto[]>(this.baseUrl + `Common/GetServiceSubType/` + switchNo);
  }
  // Get GetMasterServiceTypes...
  GetMaterServiceTypes() {
    return this.httpClient.get<any[]>(this.baseUrl + `Common/GetMasterServiceType`);
  }
  // Get MonthOfServices...
  GetMinMonthOfServices() {
    return this.httpClient.get<SelectMinMonthOfServicesDto[]>(this.baseUrl + `Common/GetMinMonthOfServices`).pipe(
      map(minMonthOfServices => {
        this.minMonthOfServices = minMonthOfServices;
        return minMonthOfServices;
      })
    )
  }
  // Get MinInstallment...
  GetMinInstallment() {
    return this.httpClient.get<SelectMinInstallmentDto[]>(this.baseUrl + `Common/GetMinInstallments`).pipe(
      map(minInstallment => {
        this.minInstallment = minInstallment;
        return minInstallment;
      })
    )
  }
  // Get MaxInstallment...
  GetMaxInstallment() {
    return this.httpClient.get<SelectMaxInstallmentDto[]>(this.baseUrl + `Common/GetMaxInstallments`).pipe(
      map(maxInstallment => {
        this.maxInstallment = maxInstallment;
        return maxInstallment;
      })
    )
  }
  // Get MaxInstallment...
  GetApprovalRoles() {
    return this.httpClient.get<SelectApprovalRoleDto[]>(this.baseUrl + `Common/GetApprovalRoles`).pipe(
      map(approvalRoles => {
        this.approvalRoles = approvalRoles;
        return approvalRoles;
      })
    )
  }
  //#endregion

  // Get all Occupations.
  GetOccupations() {
    return this.httpClient.get<SelectOccupationsDto[]>(this.baseUrl + `Common/GetOccupations`).pipe(
      map(occupationsDto => {
        this.occupationsDto = occupationsDto;
        return occupationsDto;
      })
    )
  }
  // Get all Occupations.
  GetContractType() {
    return this.httpClient.get<SelectOccupationsDto[]>(this.baseUrl + `Common/GetContractType`).pipe(
      map(contractTypeDto => {
        this.contractTypeDto = contractTypeDto;
        return contractTypeDto;
      })
    )
  }
  // Get all Departments.
  GetDepartments() {
    return this.httpClient.get<SelectDepartmentsDto[]>(this.baseUrl + `Common/GetDepartments`).pipe(
      map(departmentsDto => {
        this.departmentsDto = departmentsDto;
        return departmentsDto;
      })
    )
  }

  GetPeriods() {
    return this.httpClient.get<number[]>(this.baseUrl + `Common/GetPeriods`);
  }

  getLocations() {
    return this.httpClient.get(this.baseUrl + `Common/GetLocations`);
  }

  getContracts() {
    return this.httpClient.get(this.baseUrl + `Common/GetContracts`);
  }

  // Get all Terminations.
  GetTerminations() {
    return this.httpClient.get<SelectTerminationsDto[]>(this.baseUrl + `Common/GetTerminations`).pipe(
      map(terminationDto => {
        this.terminationDto = terminationDto;
        return terminationDto;
      })
    )
  }
  // Get all HajjAccounts.
  GetHajjAccounts() {
    return this.httpClient.get<SelectHajjAcDto[]>(this.baseUrl + `Common/GetHajjLoans`).pipe(
      map(hajjAcDto => {
        this.hajjAcDto = hajjAcDto;
        return hajjAcDto;
      })
    )
  }
  // Get all LoanAccounts.
  GetLoanAccounts() {
    return this.httpClient.get<SelectLoanAcDto[]>(this.baseUrl + `Common/GetLoanAct`).pipe(
      map(loanAcDto => {
        this.loanAcDto = loanAcDto;
        return loanAcDto;
      })
    )
  }
  // Get all PerLoanAccounts.
  GetPerLoanAccounts() {
    return this.httpClient.get<SelectPerLoanActDto[]>(this.baseUrl + `Common/GetPerLoanAct`).pipe(
      map(perLoanAcDto => {
        this.perLoanAcDto = perLoanAcDto;
        return perLoanAcDto;
      })
    )
  }

  // Get all ConsumerLoanAccounts.
  GetConsumerLoanAccounts() {
    return this.httpClient.get<SelectConsumerLoanAcDto[]>(this.baseUrl + `Common/GetConsumerLoanAct`).pipe(
      map(consumerLoanAcDto => {
        this.consumerLoanAcDto = consumerLoanAcDto;
        return consumerLoanAcDto;
      })
    )
  }
  // Get all OtherAcc1.
  GetOtherAcc1() {
    return this.httpClient.get<SelectOtherAct1Dto[]>(this.baseUrl + `Common/GetOtherAcc1`).pipe(
      map(otherAct1 => {
        this.otherAct1 = otherAct1;
        return otherAct1;
      })
    )
  }
  // Get all OtherAcc2.
  GetOtherAcc2() {
    return this.httpClient.get<SelectOtherAct2Dto[]>(this.baseUrl + `Common/GetOtherAcc2`).pipe(
      map(otherAct2 => {
        this.otherAct2 = otherAct2;
        return otherAct2;
      })
    )
  }
  // Get all OtherAcc3.
  GetOtherAcc3() {
    return this.httpClient.get<SelectOtherAct3Dto[]>(this.baseUrl + `Common/GetOtherAcc3`).pipe(
      map(otherAct3 => {
        this.otherAct3 = otherAct3;
        return otherAct3;
      })
    )
  }
  // Get all OtherAcc4.
  GetOtherAcc4() {
    return this.httpClient.get<SelectOtherAct4Dto[]>(this.baseUrl + `Common/GetOtherAcc4`).pipe(
      map(otherAct4 => {
        this.otherAct4 = otherAct4;
        return otherAct4;
      })
    )
  }

  //#region
  // To verify the Loan account number.
  VerifyLoanAct(accountNo: string | number) {
    return this.httpClient.get<CoaDto[]>(this.baseUrl + `Common/VerifyAccount/` + accountNo);
  }
  // To verify the Hajj account number.
  VerifyHajjAct(accountNo: string | number) {
    return this.httpClient.get<CoaDto[]>(this.baseUrl + `Common/VerifyAccount/` + accountNo);
  }
  // To verify the Per lOan account number.
  VerifyPerLoanAct(accountNo: string | number) {
    return this.httpClient.get<CoaDto[]>(this.baseUrl + `Common/VerifyAccount/` + accountNo);
  }
  // To verify Consumer account number.
  VerifyConsumerLoanAct(accountNo: string | number) {
    return this.httpClient.get<CoaDto[]>(this.baseUrl + `Common/VerifyAccount/` + accountNo);
  }
  // To verify Other account 1 number.
  VerifyOtherAct1(accountNo: string | number) {
    return this.httpClient.get<CoaDto[]>(this.baseUrl + `Common/VerifyAccount/` + accountNo);
  }
  // To verify Other account 2 number.
  VerifyOtherAct2(accountNo: string | number) {
    return this.httpClient.get<CoaDto[]>(this.baseUrl + `Common/VerifyAccount/` + accountNo);
  }
  // To verify Other account 3 number.
  VerifyOtherAct3(accountNo: string | number) {
    return this.httpClient.get<CoaDto[]>(this.baseUrl + `Common/VerifyAccount/` + accountNo);
  }
  // To verify Other account 4 number.
  VerifyOtherAct4(accountNo: string | number) {
    return this.httpClient.get<CoaDto[]>(this.baseUrl + `Common/VerifyAccount/` + accountNo);
  }
  //#endregion

  // Get all users form USER_MST table
  GetUsers() {
    return this.httpClient.get<SelectUsersDto[]>(this.baseUrl + `Common/GetUsers`).pipe(
      map(users => {
        this.users = users;
        return users;
      })
    )
  }

  GetUserByTenantIdAndLocationId(tId:number, lId:number){
    return this.httpClient.get<SelectUsersDto[]>(this.baseUrl + `Common/GetUsersBytenentidandlocationid?tenentid=${tId}&locationid=${lId}`).pipe(
      map(users => {
        this.users = users;
        return users;
      })
    )
  }

  // Get Master Id from FUNCTION_USERS TABLE
  GetMasterId() {
    return this.httpClient.get<SelectMasterIdDto[]>(this.baseUrl + `Common/GetMasterId`).pipe(
      map(masterIds => {
        this.masterIds = masterIds;
        return masterIds;
      })
    )
  }

  // Get RefType from RefTable
  GetRefTypes() {
    return this.httpClient.get<SelectRefTypeDto[]>(this.baseUrl + `Common/GetRefType`).pipe(
      map(refType => {
        this.refType = refType;
        return refType;
      })
    )
  }
  // Get SubRefType from RefTable
  GetRefSubTypes() {
    return this.httpClient.get<SelectRefSubTypeDto[]>(this.baseUrl + `Common/GetRefSubType`).pipe(
      map(refSubType => {
        this.refSubType = refSubType;
        return refSubType;
      })
    )
  }

  GetRefSubTypeByRefType(refType: string) {
    return this.httpClient.get<SelectRefSubTypeDto[]>(this.baseUrl + `Common/GetRefSubTypeByRefType/${refType}`).pipe(
      map(refSubType => {
        this.refSubType = refSubType;
        return refSubType;
      })
    )
  }


    // Get all Departments.
    getLetterType() {
      return this.httpClient.get<SelectLetterTypeDTo[]>(this.baseUrl + `Common/getLetterType`).pipe(
        map(letterTypeDTo => {
          
          this.letterTypeDTo = letterTypeDTo;
          return letterTypeDTo;
        })
      )
    }

    getPartyType() {
      return this.httpClient.get<SelectPartyTypeDTo[]>(this.baseUrl + `Common/getPartyType`).pipe(
        map(partyType => {
          
          this.partyType = partyType;
          return partyType;
        })
      )
    }

    getFilledAtAsync() {
      return this.httpClient.get<SelectPartyTypeDTo[]>(this.baseUrl + `Common/GetFilledAt`).pipe(
        map(partyType => {          
          this.partyType = partyType;
          return partyType;
        })
      )
    }

    GetDocApplicantType() {
      return this.httpClient.get<SelectServiceTypeDto[]>(this.baseUrl + `Common/GetDocApplicantType`).pipe(
        map(serviceType => {
          this.serviceType = serviceType;
          return serviceType;
        })
      )
    }
    
    getDashboarLoanDetails() {
      return this.httpClient.get<loanPercentageDto>(this.baseUrl + `Common/getDashboarLoanDetails`);
    }
    getDashboardTotalEmployees() {
      return this.httpClient.get<dashboardResponseDto[]>(this.baseUrl + `Common/getDashboardTotalEmployees`);
    }
    GetServiceTab() {
      return this.httpClient.get<SelectServiceTabDto[]>(this.baseUrl + `Common/GetServiceTab`).pipe(
        map(ServiceTabDto => {
          this.ServiceTabDto = ServiceTabDto;
          return ServiceTabDto;
        })
      )
    }
}
