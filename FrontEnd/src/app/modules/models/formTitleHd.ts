import { FormTitleDt } from "./formTitleDt";

export interface FormTitleHd {
    
    id:string;
    tenentId: number;
    language: number;
    formID: string;
    formName: string;
    headerName: string;
    subHeaderName: string;
    navigation: string;
    remarks: string;
    status: string;
    orderBy:number;
    formTitleDTLanguage: FormTitleDt[];
    // For Inline Edit
    isHeaderEdit:boolean;
}