import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { FinancialService } from 'src/app/modules/_services/financial.service';
import { voucherDetailsDto } from 'src/app/modules/models/voucherDetailsDto';

@Component({
  selector: 'app-voucher-details',
  templateUrl: './voucher-details.component.html',
  styleUrls: ['./voucher-details.component.scss']
})
export class VoucherDetailsComponent implements OnInit {

  //#region
  // To display table column headers
  columnsToDisplay: string[] = [ 'voucherDetailId', 'accountName', 'accountId', 'amount', 'chequeNo','chequeDate','dr','cr','cName'];

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

  voucherId:any;
  constructor(private financialService:FinancialService,private activatedRoute:ActivatedRoute) { 
    this.formGroup = new FormGroup({
      searchTerm: new FormControl(null)
    })
    //
    this.voucherId = this.activatedRoute.snapshot.paramMap.get('voucherId');
  }

  ngOnInit(): void {
    if(this.voucherId){
      this.financialService.GetVoucherDetails(this.voucherId).subscribe((response: voucherDetailsDto[]) => {
        this.voucherDetailsDto = new MatTableDataSource<voucherDetailsDto>(response);
        this.voucherDetailsDto.paginator = this.paginator;
        this.voucherDetailsDto.sort = this.sort;
        this.isLoadingCompleted = true;
        console.log('OK',response);
      }, error => {
        console.log(error);
        this.dataLoadingStatus = 'Error fetching the data';
        this.isError = true;
      })
    }
  }
  loadData(){
    
  }
}
