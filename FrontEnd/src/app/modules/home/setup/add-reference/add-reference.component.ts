import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-add-reference',
  templateUrl: './add-reference.component.html',
  styleUrls: ['./add-reference.component.scss']
})
export class AddReferenceComponent implements OnInit {
  isLoading$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoading: boolean;
  referenceForm : FormGroup;
  constructor(private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {
  }
  initializeForm(){
    this.referenceForm = new FormGroup({
      employeeName: new FormControl('',Validators.required),
      // monthlySalary: new FormControl('',Validators.required),
      // landLine: new FormControl('',Validators.required),
      // email: new FormControl('',Validators.required),
      // kinName: new FormControl('',Validators.required),
      // kinMobile: new FormControl('',Validators.required),
      // membership: new FormControl('',Validators.required),
      // membershipJoiningDate: new FormControl('',Validators.required),
      // termination: new FormControl('',Validators.required),
      // terminationDate: new FormControl('',Validators.required),
      // civilId: new FormControl('',Validators.required),
      // paci: new FormControl('',Validators.required),
      // otherId: new FormControl('',Validators.required),
      // loanAccount: new FormControl('',Validators.required),
      // hajjAccount: new FormControl('',Validators.required),
      // perLoadAct: new FormControl('',Validators.required),
      // consumerLoan: new FormControl('',Validators.required),
      // otherAcc1: new FormControl('',Validators.required),
      // otherAcc2: new FormControl('',Validators.required),
      // otherAcc3: new FormControl('',Validators.required),
      // otherAcc4: new FormControl('',Validators.required),
    })
  }
  addReference()
  {
    console.log(this.referenceForm.valid);
  }
  saveSettings() {
    this.isLoading$.next(true);
    setTimeout(() => {
      this.isLoading$.next(false);
      this.cdr.detectChanges();
    }, 1500);
  }
}
