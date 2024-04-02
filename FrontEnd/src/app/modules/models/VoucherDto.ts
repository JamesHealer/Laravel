export interface voucherDto{
    voucherId:   number;
    voucherDate: Date;
    voucherCode: string;
    narrations:  string;
    isPosted:    boolean;
    totalAmount: number;
}