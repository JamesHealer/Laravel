import { Injectable } from '@angular/core';
import * as XLSX from 'xlsx';
import * as FileSaver from 'file-saver';

@Injectable({
  providedIn: 'root',
})
export class ExcelParserService {
  parseExcelSheet(file: File,sheetName: string) : Promise<{rows: any[]}> {
    return new Promise((resolve, reject) => {
      const reader: FileReader = new FileReader();

      reader.onload = (e: any) => {
        const bstr: string = e.target.result;
        const wb: XLSX.WorkBook = XLSX.read(bstr, { type: 'binary' });
        let sheet:XLSX.WorkSheet = wb.Sheets[sheetName];
        
        // To check whether or not sheetname exists.
        if(!sheet) {
          reject({
            message: `Not found sheet: ${sheetName}`
          });
          return;
        }

        let rows: any[] = XLSX.utils.sheet_to_json(sheet);
        resolve({ rows });
      };

      reader.onerror = (error) => {
        reject(error);
      };

      reader.readAsBinaryString(file);
    });
  }

  exportToExcel(data: any[], filename: string) {
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(data);
    const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
    const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
    this.saveAsExcelFile(excelBuffer, filename);
  }

  saveAsExcelFile(buffer: any, filename: string) {
    const data: Blob = new Blob([buffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
    FileSaver.saveAs(data, filename + '_export_' + new Date().getTime() + '.xlsx');
  }
}
