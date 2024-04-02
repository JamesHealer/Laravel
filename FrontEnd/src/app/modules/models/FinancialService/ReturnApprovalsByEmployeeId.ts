export interface ReturnApprovalsByEmployeeId {
    tenentId: number;
    locationId: number;
    serviceType: string;
    serviceSubType: string;
    transId: number;
    status: string;
    approvalRemarks: string;
    active: boolean;
}