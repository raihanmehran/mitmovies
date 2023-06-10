import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css'],
})
export class AuthComponent implements OnInit {
  model: any = {};

  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  login() {
    this.accountService.login(this.model).subscribe({
      next: (user) => {
        if (user) {
          this.accountService.currentUser$.subscribe({
            next: (user) => {
              if (user) {
                if (
                  user.roles.includes(
                    'Admin' || user.roles.includes('Moderator')
                  )
                ) {
                  this.router.navigateByUrl('/admin');
                } else if (user.roles.includes('Member')) {
                  this.router.navigateByUrl('/user/profile');
                }
                this.toastr.success('You are logged in', 'LOGIN SUCCEED');
                this.model = {};
              }
            },
          });
        }
      },
      error: (error) => this.toastr.error(error.error, 'LOGIN NOT SUCCEED'),
    });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/home');
  }
}
