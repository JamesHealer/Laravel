export interface EmployeeActivityLogDto {
    fieldName: string;
    oldValue: string;
    newValue: string;
    severity: string;
    crudType: string;
    createdDate: Date;
}