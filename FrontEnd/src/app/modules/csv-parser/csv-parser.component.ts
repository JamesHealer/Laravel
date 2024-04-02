import { Component, OnInit } from '@angular/core';
import { CsvParserService } from './csv-parser.service';
@Component({
  selector: 'app-csv-parser',
  templateUrl: './csv-parser.component.html',
  styleUrls: ['./csv-parser.component.scss'],
})
export class CsvParserComponent implements OnInit {
  constructor(private csvParserService: CsvParserService) {}

  ngOnInit(): void {}

  onFileSelected(event: any) {
    const selectedFile: File = event.target.files[0];

    if (selectedFile) {
      const fileReader: FileReader = new FileReader();

      fileReader.onload = (e: any) => {
        const csvString: string | ArrayBuffer | null = e.target.result;
        if (csvString) {
          // Handle the CSV string here
          this.csvParserService
            .parseCsv(csvString as string)
            .then((result) => {
              this.csvParserService.postCsvData(
                'Employee/AddEmployee',
                result.data
              );
            })
            .catch((error) => {
              console.error('CSV parsing error:', error);
            });
        }
      };

      fileReader.readAsText(selectedFile);
    }
  }
}
