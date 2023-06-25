import { Component, OnInit } from '@angular/core';
import { trigger, transition, style, animate } from '@angular/animations';
import { TvService } from 'src/app/_services/tv.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { take } from 'rxjs';
import { User } from 'src/app/_models/user';
import { Member } from 'src/app/_models/member';

@Component({
  selector: 'app-tv-detail',
  templateUrl: './tv-detail.component.html',
  styleUrls: ['./tv-detail.component.css'],
  animations: [
    trigger('fadeInOut', [
      transition(':enter', [
        style({ opacity: 0 }),
        animate('300ms', style({ opacity: 1 })),
      ]),
      transition(':leave', [animate('300ms', style({ opacity: 0 }))]),
    ]),
    trigger('slideFromRight', [
      transition(':enter', [
        style({ transform: 'translateX(100%)', opacity: 0 }),
        animate('300ms', style({ transform: 'translateX(20px)', opacity: 1 })),
      ]),
    ]),
    trigger('slideFromLeft', [
      transition(':enter', [
        style({ transform: 'translateX(-100%)', opacity: 0 }),
        animate('300ms', style({ transform: 'translateX(20px)', opacity: 1 })),
      ]),
    ]),
    trigger('slideFromBottom', [
      transition(':enter', [
        style({ transform: 'translateY(40%)', opacity: 0 }),
        animate('400ms', style({ transform: 'translateY(40px)', opacity: 1 })),
      ]),
    ]),
  ],
})
export class TvDetailComponent implements OnInit {
  tvShow: any;
  tvShowId: string = '';
  imageUrl = environment.imageUrl;
  facebookUrl = environment.facebookUrl;
  instagramUrl = environment.instagramUrl;
  imdbUrl = environment.imdbUrl;
  twitterUrl = environment.twitterUrl;
  member: Member | undefined;
  isFavorite: boolean = false;
  isWatched: boolean = false;
  isWatchLater: boolean = false;
  isRated: boolean = false;
  userRating: number = 0;

  constructor(
    private tvService: TvService,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.tvShowId = params['tvshowid'];
      this.getTvShow();
    });
  }

  getTvShow() {
    if (!this.tvShowId) return;
    this.tvService
      .getTvShow(this.tvShowId)
      .pipe(take(1))
      .subscribe({
        next: (tvShow) => {
          console.log(tvShow);
          if (tvShow) {
            this.tvShow = tvShow;
            this.scrollToTop();
            this.checkTvShow();
          } else {
            this.toastr.error(
              'Tv Show with id ' + this.tvShowId + ' not found',
              'TV SHOW NOT FOUND'
            );
            this.tvShow = null;
          }
        },
      });
  }

  scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }

  getTvShowType(typeId: number) {
    if (typeId === 2) return 'Drama';
    if (typeId === 3) return 'Documentary';
    return 'TV Series';
  }

  getLanguageName(lgCode: string) {
    return lgCode === 'en' ? 'English' : lgCode;
  }

  getPopularity(avgVote: number) {
    if (avgVote) return Math.floor((avgVote / 10) * 100);
    return 0;
  }

  checkTvShow() {
    if (this.member) {
      if (this.tvShow) {
        this.checkIsFavorite();
        this.checkIsWatched();
        this.checkIsRated();
        this.checkIsWatchLater();
      }
    }
  }
  private checkIsFavorite() {
    if (this.member?.favouriteTvShows) {
      this.member.favouriteTvShows.forEach((tvShow) => {
        if (tvShow.tvShowId === this.tvShow.id) this.isFavorite = true;
      });
    }
  }
  private checkIsWatched() {
    if (this.member?.watchedTvShows) {
      this.member.watchedTvShows.forEach((tvShow) => {
        if (tvShow.tvShowId === this.tvShow.id) this.isWatched = true;
      });
    }
  }
  private checkIsRated() {
    if (this.member?.rateTvShows) {
      this.member.rateTvShows.forEach((tvShow) => {
        if (tvShow.tvShowId === this.tvShow.id) {
          this.isRated = true;
          this.userRating = tvShow.rating;
        }
      });
    }
  }
  private checkIsWatchLater() {
    if (this.member?.watchLaters) {
      this.member.watchLaters.forEach((tvShow) => {
        if (tvShow.tvShowId === this.tvShow.id) this.isWatchLater = true;
      });
    }
  }
}
