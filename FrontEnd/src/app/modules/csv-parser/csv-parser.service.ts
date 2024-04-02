import { Injectable } from '@angular/core';
import * as Papa from 'papaparse';
import { HttpClient } from '@angular/common/http';
import { resolve } from 'dns';
import { reject } from 'lodash';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CsvParserService {
  baseUrl = environment.KUPFApiUrl;
  constructor(private httpClient: HttpClient) {}
  parseCsv(csvData: string): Promise<Papa.ParseResult<string[]>> {
    return new Promise((resolve, reject) => {
      Papa.parse(csvData, {
        header: true, // Set to true if CSV has headers
        complete: (result: any) => {
          resolve(result);
        },
        error: (error: any) => {
          reject(error);
        },
      });
    });
  }
  postEmployee(endPoint: string, employee: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this.httpClient.post(this.baseUrl + endPoint, employee).subscribe({
        next(res) {
          console.log('==>', res);
        },
        error(msg) {
          console.log('==>', msg);
        }
      })
    })
  }
  async postCsvData(endPoint: string, csvData: Array<Object>) {
    /** api/Employee/AddEmployee */
    for(var employee of csvData)
      await this.postEmployee(endPoint, employee);
  }
}
