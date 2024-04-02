import { FormTitleHd } from "./formTitleHd";

export interface FormTitleDt {
   
    id:number;   
    tenentId: number;
    formTitleHDLanguageId:string;
    formID:string;
    language: number;
    labelId: string;
    title: string;
    arabicTitle: string;
    rl: string;
    attiribute: string;
    remarks: string;
    status: string;
    orderBy:number;
    // For Inline Edit
    isBodyEdit:boolean;
}