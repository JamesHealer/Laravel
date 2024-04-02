import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TestRoutingModule } from './test-routing.module';
import { Test1Component } from './test1/test1.component';

@NgModule({
  declarations: [
    Test1Component
  ],
  imports: [
    CommonModule,
    TestRoutingModule
  ],
  exports:[
  ]
})
export class TestModule {
  constructor(){
    console.log("Test module")
  }
 }
