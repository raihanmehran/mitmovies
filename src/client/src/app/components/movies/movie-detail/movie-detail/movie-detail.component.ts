import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { MoviesService } from 'src/app/_services/movies.service';
import { environment } from 'src/environments/environment';
import { trigger, transition, style, animate } from '@angular/animations';
import { FavoriteMoviesService } from 'src/app/_services/favorite-movies.service';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { Member } from 'src/app/_models/member';
import { MemberService } from 'src/app/_services/member.service';
import { FavouriteMovie } from 'src/app/_models/favouriteMovie';
import { WatchedMoviesService } from 'src/app/_services/watched-movies.service';
import { WatchedMovie } from 'src/app/_models/watchedMovie';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css'],
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
export class MovieDetailComponent implements OnInit {
  movie: any;
  imageUrl = environment.imageUrl;
  videoUrl = environment.videoUrl;
  movieId: string = '';
  facebookUrl = environment.facebookUrl;
  instagramUrl = environment.instagramUrl;
  imdbUrl = environment.imdbUrl;
  twitterUrl = environment.twitterUrl;
  user: User | undefined;
  member: Member | undefined;
  isFavorite: boolean = false;
  isWatched: boolean = false;
  isWatchLater: boolean = false;
  isRated: boolean = false;

  constructor(
    private moviesService: MoviesService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private favoriteMoviesService: FavoriteMoviesService,
    private memberService: MemberService,
    private watchedMoviesService: WatchedMoviesService
  ) {}

  ngOnInit(): void {
    this.getMember();
    this.route.params.subscribe((params) => {
      this.movieId = params['movieid'];
      this.getMovie();
    });
  }

  getMovie() {
    // const movieId = this.route.snapshot.paramMap.get('movieid');

    if (!this.movieId) return;
    this.moviesService
      .getMovie(this.movieId)
      .pipe(take(1))
      .subscribe({
        next: (movie) => {
          console.log(movie);
          if (movie) {
            this.movie = movie;
            this.scrollToTop();
            this.checkMovie();
          } else {
            this.toastr.error(
              'Movie with id ' + this.movieId + ' not found',
              'NOT FOUND'
            );
            this.movie = null;
          }
        },
      });
  }

  convertMinutesToTime(minutes: number) {
    const hours = Math.floor(minutes / 60);
    const mins = minutes % 60;

    // const formattedHours = hours < 10 ? `0${hours}` : `${hours}`;
    // const formattedMins = mins < 10 ? `0${mins}` : `${mins}`;

    return `${hours}h ${mins}m`;
  }

  scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }

  getLanguageName(lgCode: string) {
    return lgCode === 'en' ? 'English' : lgCode;
  }

  getMember() {
    this.memberService.member$.pipe().subscribe({
      next: (member) => {
        if (member) this.member = member;
      },
    });
  }

  handleFavorite(id: number) {
    if (this.member) {
      if (id) {
        if (!this.isFavorite) {
          this.addToFavoriteMovies(id);
        } else {
          this.removeFromFavoriteMovies(id);
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

  addToFavoriteMovies(id: number) {
    this.favoriteMoviesService.addToFavoriteMovies(id).subscribe({
      next: (movie) => {
        const favoriteMovie = {
          movieId: id,
        };
        this.memberService.addFavoriteMovie(favoriteMovie as FavouriteMovie);
        this.isFavorite = true;
        this.toastr.success('Movied Added To Favorites');
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  removeFromFavoriteMovies(id: number) {
    this.favoriteMoviesService.removeFromFavoriteMovies(id).subscribe({
      next: (movie) => {
        this.memberService.removeFavoriteMovie(id);
        this.isFavorite = false;
        this.toastr.success('Movie Removed From Favorites', 'REMOVED');
      },
    });
  }

  handleWatched(id: number) {
    if (this.member) {
      if (id) {
        if (!this.isWatched) {
          this.addToWatchedMovies(id);
        } else if (this.isWatched) {
          this.removeFromWatchedMovies(id);
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

  addToWatchedMovies(id: number) {
    this.watchedMoviesService.addToWatchedMovies(id).subscribe({
      next: (movie) => {
        const watchedMovie = {
          movieId: id,
        };
        this.memberService.addWatchedMovie(watchedMovie as WatchedMovie);
        this.isWatched = true;
        this.toastr.success('Movied Added To Watched', 'ADDED');
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  removeFromWatchedMovies(id: number) {
    this.watchedMoviesService.removeFromWatchedMovies(id).subscribe({
      next: (movie) => {
        this.memberService.removeWatchedMovie(id);
        this.isWatched = false;
        this.toastr.success('Movie Removed From Watched', 'REMOVED');
      },
    });
  }

  checkMovie() {
    if (this.member) {
      if (this.movie) {
        this.checkIsFavorite();
        this.checkIsWatched();
      }
    }
  }

  private checkIsFavorite() {
    if (this.member?.favouriteMovies) {
      this.member.favouriteMovies.forEach((movie) => {
        if (movie.movieId === this.movie.id) this.isFavorite = true;
      });
    }
  }
  private checkIsWatched() {
    if (this.member?.watchedMovies) {
      this.member.watchedMovies.forEach((movie) => {
        if (movie.movieId === this.movie.id) this.isWatched = true;
      });
    }
  }
}
