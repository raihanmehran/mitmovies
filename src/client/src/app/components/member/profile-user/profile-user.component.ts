import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { UserInteractions } from 'src/app/_models/userInteractions';
import { AccountService } from 'src/app/_services/account.service';
import { FavoriteMoviesService } from 'src/app/_services/favorite-movies.service';
import { MemberService } from 'src/app/_services/member.service';
import { UserInteractionsService } from 'src/app/_services/user-interactions.service';

@Component({
  selector: 'app-profile-user',
  templateUrl: './profile-user.component.html',
  styleUrls: ['./profile-user.component.css'],
})
export class ProfileUserComponent implements OnInit {
  @ViewChild('memberTabs', { static: true }) memberTabs?: TabsetComponent;
  member: Member = {} as Member;
  activeTab?: TabDirective;
  // userInteractionsData: any[] = [];

  userInteractions: UserInteractions = {
    favoriteMovies: [],
    watchLaterMovies: [],
    watchedMovies: [],
    ratedMovies: [],
    favoriteTvShows: [],
    watchLaterTvShows: [],
    watchedTvShows: [],
    ratedTvShows: [],
  };
  loading = true;
  error: any;

  constructor(
    private route: ActivatedRoute,
    private memberService: MemberService,
    private accountService: AccountService,
    private toastr: ToastrService,
    private userInteractionsService: UserInteractionsService
  ) {}

  ngOnInit(): void {
    this.getMember();
    this.getUserInteractionsData();
  }

  onTabActivated(data: TabDirective) {
    this.activeTab = data;
    if (this.activeTab.heading == 'Posts') {
      // do something
      // propbably SignalR Connection to get data in real-time
    }
  }

  fetchMember() {
    this.memberService.getMember();
  }

  getUserInteractionsData() {
    this.userInteractionsService
      .getUserData()
      .valueChanges.subscribe((result: any) => {
        this.userInteractions = result.data;
        this.loading = result.loading;
        this.error = result.error;
      });
  }

  getMember() {
    this.memberService.member$.pipe().subscribe({
      next: (member) => {
        if (member) this.member = member;
        else this.fetchMember();
      },
      error: (error) => this.toastr.error(error.error),
    });
  }
}
