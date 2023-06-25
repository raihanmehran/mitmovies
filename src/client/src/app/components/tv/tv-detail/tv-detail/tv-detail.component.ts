import { Component, OnInit, TemplateRef } from '@angular/core';
import { trigger, transition, style, animate } from '@angular/animations';
import { TvService } from 'src/app/_services/tv.service';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { take } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { RatedTvShow } from 'src/app/_models/ratedTvShow';
import { MemberService } from 'src/app/_services/member.service';
import { TvRatingService } from 'src/app/_services/tv-rating.service';
import { FavoriteTvService } from 'src/app/_services/favorite-tv.service';
import { FavouriteTvShow } from 'src/app/_models/favouriteTvShow';

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
  modalRef?: BsModalRef;

  constructor(
    private tvService: TvService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private modalService: BsModalService,
    private memberService: MemberService,
    private tvRatingService: TvRatingService,
    private favoriteTvService: FavoriteTvService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.tvShowId = params['tvshowid'];
      this.getTvShow();
    });
  }

  openRatingModal(template: TemplateRef<any>) {
    if (this.member) {
      this.modalRef = this.modalService.show(template, {
        ariaDescribedby: 'my-modal-description',
        ariaLabelledBy: 'my-modal-title',
      });
    } else {
      this.toastr.warning('Please log in first', 'Not Authenticated!');
    }
  }

  getMember() {
    this.memberService.member$.pipe().subscribe({
      next: (member) => {
        if (member) {
          this.member = member;
          console.log(this.member);

          this.checkTvShow();
        }
      },
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
            this.getMember();
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

  // RATING:
  handleRating(predicate: string, rating?: any) {
    if (this.tvShow) {
      this.toastr.show('Kudos!');

      if (predicate === 'add') this.addRating(rating);
      else if (predicate === 'remove') this.removeRating();
    }
  }
  addRating(rating: any) {
    const ratedTvShow: RatedTvShow = {
      tvShowId: this.tvShow.id,
      rating: parseInt(rating),
    };
    this.tvRatingService.addRatedTvShow(ratedTvShow).subscribe({
      next: (_) => {
        this.isRated = true;
        this.toastr.success(
          'You rate this Tv Show : ' + this.userRating,
          'RATED'
        );
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }
  removeRating() {
    this.tvRatingService.removeRatedTvShow(this.tvShow.id).subscribe({
      next: (_) => {
        this.userRating = 0;
        this.isRated = false;
        this.toastr.warning('Your rating removed', 'RATING REMOVED');
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  // FAVORITE
  handleFavorite(id: number) {
    if (this.member) {
      if (id) {
        if (!this.isFavorite) {
          this.addToFavoriteTvShow(id);
        } else {
          this.removeFromFavoriteTvShow(id);
        }
      } else {
        this.toastr.warning(
          'Please refresh the page to load the movie',
          'NO MOVIE FOUND!'
        );
      }
    } else {
      this.toastr.warning('Please log in first', 'Not Authenticated!');
    }
  }

  addToFavoriteTvShow(id: number) {
    this.favoriteTvService.addToFavoriteTvShows(id).subscribe({
      next: (_) => {
        // this.memberService.addFavoriteMovie(favoriteTvShow as FavouriteTvShow);
        this.isFavorite = true;
        this.toastr.success('Tv Show Added To Favorites');
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  removeFromFavoriteTvShow(id: number) {
    this.favoriteTvService.removeFromFavoriteTvShows(id).subscribe({
      next: (_) => {
        // this.memberService.removeFavoriteMovie(id);
        this.isFavorite = false;
        this.toastr.success('TvShow Removed From Favorites', 'REMOVED');
      },
    });
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
    if (this.member?.ratedTvShows) {
      this.member.ratedTvShows.forEach((tvShow) => {
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
