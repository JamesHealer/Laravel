export interface ReturnTransactionHdDto {
    mytransid: number;
    employeeId: number;
    pfId: string;
    cid: string;
    englishName: string;
    arabicName: string;
    serviceType: number;
    installment: number;
    amount: number;
    paid?: any;
    payDate: string;
    discounted?: any;
}