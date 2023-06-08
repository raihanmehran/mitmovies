import { Component, OnInit } from '@angular/core';
import { trigger, transition, style, animate } from '@angular/animations';
import { TvService } from 'src/app/_services/tv.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { take } from 'rxjs';

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
}
