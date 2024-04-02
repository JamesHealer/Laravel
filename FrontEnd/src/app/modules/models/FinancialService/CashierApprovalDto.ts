export interface CashierApprovalDto {
    tenentId: number;
    locationId: number;
    pfid: string;
    empCidNum: string;
    employeeId: string;
    arabicName: string;
    englishName: string;
    mobileNumber?: any;
    periodCode: string;
    transId: number;
    serviceName: string;
    draftAmount1?: any;
    draftAmount2?: any;
    draftDate1?: any;
    draftDate2?: any;
    totalAmount: number;
    receivedDate: Date;
    receivedBy: string;
    draftNumber1: string;
    draftNumber2: string;
    totalInstallments:number,
    status:string;
    active:boolean;
    crupId:any;
    isDraftCreated:boolean;
}