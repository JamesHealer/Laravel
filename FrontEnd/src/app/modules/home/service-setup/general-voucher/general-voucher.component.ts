import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { voucherDetailsDto } from 'src/app/modules/models/voucherDetailsDto';

@Component({
  selector: 'app-general-voucher',
  templateUrl: './general-voucher.component.html',
  styleUrls: ['./general-voucher.component.scss']
})
export class GeneralVoucherComponent implements OnInit {

  //#region
  // To display table column headers
  columnsToDisplay: string[] = [ 'sin', 'accountNumber', 'accountDescription', 'dr','cr'];

  // Getting data as abservable.
  voucherDetailsDto$: Observable<voucherDetailsDto[]>;

  // We need a normal array of data so we will subscribe to the observable and will get data
  voucherDetailsDto: MatTableDataSource<voucherDetailsDto> = new MatTableDataSource<any>([]);

  // Paginator
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  // Sorting
  @ViewChild(MatSort) sort!: MatSort;

  // Hide footer while loading.
  isLoadingCompleted: boolean = false;

  // Incase of any error will display error message.
  dataLoadingStatus: string = '';

  // True of any error
  isError: boolean = false;

  // formGroup
  formGroup: FormGroup;

  // Search Term
  searchTerm: string = '';
  //#endregion

  
  constructor() {
    this.formGroup = new FormGroup({
      searchTerm: new FormControl(null)
    })
   }

  ngOnInit(): void {
  }
//#region Material Search and Clear Filter 
filterRecords() {
  if (this.formGroup.value.searchTerm != null && this.voucherDetailsDto) {
    this.voucherDetailsDto.filter = this.formGroup.value.searchTerm.trim();
  }
}
clearFilter() {
  this.formGroup?.patchValue({ searchTerm: "" });
  this.filterRecords();
}
//#endregion
}
