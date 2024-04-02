import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { ClipboardModule } from 'ngx-clipboard';
import { TranslateModule } from '@ngx-translate/core';
import { InlineSVGModule } from 'ng-inline-svg-2';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { environment } from 'src/environments/environment';
// #fake-start#
import { FakeAPIService } from './_fake/fake-api.service';
import { ViewContactComponent } from './modules/home/employeeinformation/view-contact/view-contact.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddReferenceComponent } from './modules/home/setup/add-reference/add-reference.component';
import { LoginComponent } from './modules/home/auth/login/login.component';
import { NgxTranslateModule } from './modules/i18n';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './modules/_interceptors/loading.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { NgSelectModule } from '@ng-select/ng-select';
import { DatePipe } from '@angular/common';
import { AngularEditorModule } from '@kolkov/angular-editor';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { QRCodeModule } from 'angularx-qrcode';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import {AuthService} from "./modules/auth";
// #fake-end#

function appInitializer(authService: AuthService) {
  return () => {
    return new Promise((resolve) => {
      //@ts-ignore
      authService.getUserByToken().subscribe().add(resolve);
    });
  };
}

@NgModule({
  declarations: [
    AppComponent,
    ViewContactComponent,
    AddReferenceComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    MatIconModule,
    MatButtonModule,
    BrowserAnimationsModule,
    TranslateModule.forRoot(),
    HttpClientModule,
    ClipboardModule,
    QRCodeModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatPaginatorModule,
    ToastrModule.forRoot({
      "positionClass" : "toast-top-left",
          "closeButton" : true,
          "newestOnTop" : false,
          "progressBar" : true,
          "preventDuplicates" : false,
    }),
    // #fake-start#
    environment.isMockEnabled
      ? HttpClientInMemoryWebApiModule.forRoot(FakeAPIService, {
          passThruUnknownUrl: true,
          dataEncapsulation: false,
        })
      : [],
    // #fake-end#
    AppRoutingModule,
    InlineSVGModule.forRoot(),
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    NgxTranslateModule,
    // TranslateModule.forRoot({
    //   defaultLanguage: 'en',
    //   loader: {
    //      provide: TranslateLoader,
    //      useFactory: httpTranslateLoader,
    //      deps: [HttpClient]
    //      }
    //   }),
      NgxSpinnerModule,
      NgSelectModule,
      AngularEditorModule,
  ],

  exports:[

  NgxTranslateModule,
  NgxSpinnerModule,
  NgSelectModule,
  ], // providers: [{provide: LocationStrategy, useClass: HashLocationStrategy}],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializer,
      multi: true,
      deps: [AuthService]
    },
    {
      provide: MatDialogRef,
      useValue: {}
    },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    DatePipe
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
// AOT compilation support
