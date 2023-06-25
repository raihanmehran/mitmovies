import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Member } from '../_models/member';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, take } from 'rxjs';
import { FavouriteMovie } from '../_models/favouriteMovie';
import { FavouriteTvShow } from '../_models/favouriteTvShow';
import { WatchedMovie } from '../_models/watchedMovie';
import { WatchLater } from '../_models/watchLater';

@Injectable({
  providedIn: 'root',
})
export class MemberService {
  baseUrl = environment.apiUrl;

  private memberSource = new BehaviorSubject<Member | null>(null);
  member$ = this.memberSource.asObservable();

  constructor(private http: HttpClient) {}

  getMember() {
    return this.http
      .get<Member>(this.baseUrl + 'users/member-self')
      .pipe(take(1))
      .subscribe({
        next: (member) => {
          this.memberSource.next(member);
          console.log(member);
        },
      });
  }

  //// MOVIES:

  // FAVORITE MOVIES:
  addFavoriteMovie(movie: FavouriteMovie) {
    this.member$.subscribe({
      next: (member) => {
        if (member) {
          member.favouriteMovies.push(movie);
        }
      },
      error: (error) => console.log(error),
    });
  }

  removeFavoriteMovie(id: number) {
    this.member$.subscribe({
      next: (member) => {
        if (member) {
          if (member.favouriteMovies) {
            member.favouriteMovies = member.favouriteMovies.filter(
              (movie) => movie.movieId !== id
            );
          }
        }
      },
    });
  }

  // WATCHED MOVIES:
  addWatchedMovie(movie: WatchedMovie) {
    this.member$.subscribe({
      next: (member) => {
        if (member) {
          member.watchedMovies.push(movie);
          console.log(member.watchedMovies);
        }
      },
      error: (error) => console.log(error.error),
    });
  }

  removeWatchedMovie(id: number) {
    this.member$.subscribe({
      next: (member) => {
        if (member) {
          if (member.watchedMovies) {
            member.watchedMovies = member.watchedMovies.filter(
              (movie) => movie.movieId !== id
            );
            console.log(member.watchedMovies);
          }
        }
      },
    });
  }

  // Watch Later Movies:
  addWatchLaterMovie(movie: WatchLater) {
    this.member$.subscribe({
      next: (member) => {
        if (member) {
          member.watchLaters.push(movie);
        }
      },
    });
  }

  removeWatchLater(id: number) {
    this.member$.subscribe({
      next: (member) => {
        if (member) {
          if (member.watchLaters) {
            member.watchLaters = member.watchLaters.filter((movie) => {
              return movie.id !== id;
            });
          }
        }
      },
    });
  }

  //// TV SHOWS

  // FAVORITE TV SHOWS

  addFavoriteTvShow(tvShow: FavouriteTvShow) {
    this.member$.subscribe({
      next: (member) => {
        if (member) {
          member.favouriteTvShows.push(tvShow);
        }
      },
      error: (error) => console.log(error),
    });
  }
  removeFavoriteTvShow(id: number) {
    this.member$.subscribe({
      next: (member) => {
        if (member) {
          if (member.favouriteTvShows) {
            member.favouriteTvShows = member.favouriteTvShows.filter(
              (tvShow) => tvShow.tvShowId !== id
            );
          }
        }
      },
    });
  }
}
