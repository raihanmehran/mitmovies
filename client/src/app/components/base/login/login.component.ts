import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(public accountService: AccountService, private router: Router) {}

  ngOnInit(): void {}

  login() {
    this.accountService.login(this.model).subscribe({
      next: (user) => {
        this.accountService.currentUser$.subscribe({
          next: (user) => {
            if (user) {
              if (
                user.roles.includes('Admin' || user.roles.includes('Moderator'))
              ) {
                this.router.navigateByUrl('/admin');
              } else if (user.roles.includes('Member')) {
                this.router.navigateByUrl('/profile');
              }
              this.model = {};
            }
          },
        });
      },
      error: (error) => console.log(error.error),
    });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/home');
  }
}
