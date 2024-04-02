import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-electronic-forms',
  templateUrl: './electronic-forms.component.html',
  styleUrls: ['./electronic-forms.component.scss']
})
export class ElectronicFormsComponent implements OnInit {
  @Input() accordialElectronic: string;

  @Input() parentFormGroup: FormGroup;
  electronicForm: FormGroup | undefined;

  @Output() fileSelect1Event:EventEmitter<any> = new EventEmitter<any>();
  @Output() fileSelect2Event:EventEmitter<any> = new EventEmitter<any>();
  constructor() { }

  ngOnInit(): void {
    this.initializeElectronicForm();
    if (this.parentFormGroup) {
      this.parentFormGroup.setControl('electronicForm', this.electronicForm);
    }
  }
  onFile1Select(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.electronicForm?.get('electronicForm1')?.setValue(file.name); 
      this.fileSelect1Event.emit(file);     
    }
  }
  onFile2Select(event:any){    
    if(event.target.files.length > 0){
      const file = event.target.files[0];
      this.electronicForm?.get('electronicForm2')?.setValue(file.name); 
      this.fileSelect2Event.emit(file);
    }
  }
  initializeElectronicForm() {
    this.electronicForm = new FormGroup({
      electronicForm1: new FormControl('', Validators.required),
      electronicForm1URL: new FormControl('', Validators.required),
      electronicForm2: new FormControl('', Validators.required),
      electronicForm2URL: new FormControl('', Validators.required),
    })
  }
}
