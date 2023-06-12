import { Component } from '@angular/core';
import { AccountService } from './_services/account.service';
import { User } from './_models/user';
import { MemberService } from './_services/member.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'client';
  constructor(
    private accountService: AccountService,
    private memberService: MemberService
  ) {}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user: User = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
    this.fetchMember();
  }

  fetchMember() {
    this.memberService.getMember();
  }
}
