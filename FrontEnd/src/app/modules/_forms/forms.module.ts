import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DateInputComponent } from './date-input/date-input.component';



@NgModule({
  declarations: [
    DateInputComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  

})
export class FormsModule { 
  
}
