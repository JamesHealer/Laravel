export interface Employee {
    EmployeeUnivNo: number;
    EnglishNAme: string;
    ArabicNAme: string;
    EmploymentDate: Date;
    JoinedDate: Date;
    PFNo: number;
    SubscribedDate: Date;
    MemStatusCode: number;
    AgreedSubmt: number;
    AmountReceivedTillNow: Date;
    LastSalary: number;
    TerminationDate: Date;
    Mobile: string;
    CivilID: number;
    Birthday: Date;
    Email: string;
    EmpPaciNo: number;
    NextToKin: string;

    Department: number;
    Occupation: number;
    ContractType: number;
    Nationality: number;
    Gender: number;
}
export interface Dept {
    DepartmentNo: number;
    DepartmentEnglish: string;
    DepartmentArabic: string;
}
export interface Job{
    JobNo: number;
    JobEnglish: string;
    JobArabic: string;
}
export interface Contract{
    ContractTypeNo: number;
    ContractTypeEnglish: string;
    ContractTypeArabic: string;
}
export interface SDP{
    SDPNo: number;
    SDPEnglish: string;
    SDPArabic: string;
}
export interface MonthlyData{
    YearMonth: Date;
    UploadType: number;
    EmployeeId: number;
    EmployeeName: string;
    Reference: string;
    Salary: number;
    Amount: number;
}

export enum Document {
    Incoming = 1,
    Outgoing = 2,
    CircularsOrOthers = 3
  }
export interface ComData{
    Date: Date;
    DocumentType: Document;
    From: string;
    To: string;
    Reference: string;
    Remarks: string;
    AuthoritySigned: string;
}
export const GenderArray = [
    { id: 1, name: 'Male' },
    { id: 2, name: 'Female' }
]