import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { Test1Component } from './test1/test1.component';

const routes: Routes = [
  { path: 'test1', component: Test1Component },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class TestRoutingModule {
    constructor(){
      console.log("Test routing component")
    }
   }
  