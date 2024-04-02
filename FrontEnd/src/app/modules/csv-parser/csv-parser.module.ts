import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CsvParserComponent } from './csv-parser.component';
import { CsvParserService } from './csv-parser.service';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [CsvParserComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: CsvParserComponent,
      },
    ]),
  ],
  providers: [CsvParserService],
})
export class CsvParserModule {}
