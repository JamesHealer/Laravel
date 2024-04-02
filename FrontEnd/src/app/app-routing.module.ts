import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './modules/home/auth/login/login.component';
import { AuthGuard } from './modules/auth/services/auth.guard';
import { LoginAuthGuard } from './modules/auth/services/login.auth.guard';

export const routes: Routes = [
  // {
  //   path: 'auth',
  //   loadChildren: () =>
  //     import('./modules/auth/auth.module').then((m) => m.AuthModule),
  // },
  // {
  //   path: 'error',
  //   loadChildren: () =>
  //     import('./modules/errors/errors.module').then((m) => m.ErrorsModule),
  // },
  // {path:'',redirectTo:'dashboard', pathMatch:'full'},
  // {path:'login',component:LoginComponent},

  { path: 'login', component: LoginComponent, canActivate: [LoginAuthGuard] },


  {
    path: '',
    canActivate: [AuthGuard],
    loadChildren: () =>
      import('./_metronic/layout/layout.module').then((m) => m.LayoutModule),
  },
  { path: '**', redirectTo: 'error/404' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{ useHash: true })],
  providers: [AuthGuard],
  exports: [RouterModule],
})
export class AppRoutingModule {}
