import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  user: User | undefined;
  profileUrl: string = '';
  coverUrl: string = '';

  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    this.accountService.currentUser$.subscribe({
      next: (user) => {
        if (user) {
          this.user = user;
          this.user.photos.forEach((photo) => {
            if (photo.isProfile) this.profileUrl = photo.url;
            if (photo.isCover) this.coverUrl = photo.url;
          });
        }
      },
    });
  }

  navigate(to: string) {
    this.router.navigateByUrl(to);
  }

  logout() {
    this.accountService.logout();
    this.user = undefined;
    this.router.navigateByUrl('/home');
    this.toastr.warning('You are logged out', 'LOGGED OUT');
  }
}
