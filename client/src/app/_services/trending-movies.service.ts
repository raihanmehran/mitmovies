import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/movie';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TrendingMoviesService {
  baseUrl = environment.apiUrl;

  private todayTrendingMoviesSource = new BehaviorSubject<Movie[] | null>(null);
  todayTrendingMovies$ = this.todayTrendingMoviesSource.asObservable();

  private thisWeekTrendingMoviesSource = new BehaviorSubject<Movie[] | null>(
    null
  );
  thisWeekTrendingMovies$ = this.thisWeekTrendingMoviesSource.asObservable();

  constructor(private http: HttpClient) {}

  getTodayTrendingMovies() {
    this.getTrendingMovies('today');
  }

  getThisWeekTrendingMovies() {
    this.getTrendingMovies('week');
  }

  getTrendingMovies(predicate: string) {
    this.http
      .get<any[]>(this.baseUrl + 'trendingmovies/' + predicate)
      .subscribe({
        next: (movies: any) => {
          console.log(movies.results);
          if (movies) {
            if (predicate === 'today') {
              this.todayTrendingMoviesSource.next(movies.results as Movie[]);
            } else {
              this.thisWeekTrendingMoviesSource.next(movies.results as Movie[]);
            }
          }
        },
        error: (error) => console.log(error.error),
      });
  }
}
