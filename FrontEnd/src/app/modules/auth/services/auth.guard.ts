import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router
} from '@angular/router';
import { AuthService } from './auth.service';
import { LoginService } from '../../_services/login.service';
import { timer, throwError, of } from 'rxjs';
import { switchMap, timeout } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  private readonly timeoutDuration = 60 * 60 * 1000; // 10 minutes in milliseconds
  constructor(private authService: AuthService, private router: Router, private loginService: LoginService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const currentUser = this.authService.currentUserValue;
    if (currentUser) {
      // logged in so return true
      this.startTimeout();
      return of(true);
    }

    // not logged in so redirect to login page with the return url
    // this.authService.logout();
    this.router.navigate(['/login']);
    return of(false);
  }
  private startTimeout() {
    let lastActivity = Number(sessionStorage.getItem('lastActivity'));
    if (!lastActivity) {
      // Set the lastActivity timestamp to the current time if it is not defined
      lastActivity = Date.now();
      sessionStorage.setItem('lastActivity', lastActivity.toString());
    }

    const timeLeft = lastActivity + this.timeoutDuration - Date.now();

    if (timeLeft > 0) {
      // Set up the timeout using the timeout() operator
      const timeoutObservable = timer(timeLeft).pipe(
        switchMap(() => throwError(new Error('timeout'))),
        timeout(this.timeoutDuration)
      );

      // Subscribe to the timeoutObservable to handle the timeout error
      timeoutObservable.subscribe({
        error: () => {
          // Logout and navigate to the login page when the timeout expires
          this.authService.logout();
          this.loginService.isLoading = false;
        }
      });
    } else {
      // Logout and navigate to the login page when the timeout has already expired
      this.authService.logout();
    }

    // Listen for user interaction events and update the timestamp in sessionStorage
    const resetTimeout = () => {
      sessionStorage.setItem('lastActivity', Date.now().toString());
    };
    window.addEventListener('click', resetTimeout);
    window.addEventListener('mousemove', resetTimeout);
    window.addEventListener('keydown', resetTimeout);
  }
}
