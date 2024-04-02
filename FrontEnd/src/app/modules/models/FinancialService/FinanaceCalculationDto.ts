export interface FinanaceCalculationDto {
        myTransId:any,
        noOfTransactions: number;
        subscriptionPaidAmount: number;
        subscriptionDueAmount: number;
        subscriptionInstalmentAmount: number;
        financialAid: number;
        pfFundRevenue: number;
        adjustmentAmount: number;
        adjustmentAmountRemarks: string;
        pfFundRevenuePercentage: number;
        sponsorLoanPendingAmount: number;
        sponsorDueAmount: number;
        finAidAmountRemarks: string;
        loanPendingAmount: number;
        loanreceivedAmount: number;
        loanInstallmentAmount: number;
        noOfSponsor: number;
        yearOfService: string;
        amountMinus:number;
        amountPlus:number;
        systemRemarks:string;
}