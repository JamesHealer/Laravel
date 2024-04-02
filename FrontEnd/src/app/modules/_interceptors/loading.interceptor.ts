import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusyService } from '../_services/busy.service';
import { delay, finalize } from 'rxjs';
import { AuthService } from '../auth';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private busyService: BusyService, private authService: AuthService, private modalService:NgbModal) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler,): Observable<HttpEvent<unknown>> {
    this.busyService.busy();
    if (request.url.includes('/Login/EmployeeLogin')) {
      this.modalService.dismissAll();
      return next.handle(request).pipe(
        delay(1000),
        finalize(()=>{
          this.busyService.idle();
        })
      );;
    }
    const token = this.authService.getToken(); // Get the token from your authentication service
    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }
    return next.handle(request).pipe(
      delay(1000),
      finalize(()=>{
        this.busyService.idle();
      })
    );
  }
}
