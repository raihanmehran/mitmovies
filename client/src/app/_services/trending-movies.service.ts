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
  public todayTrendingMovies$ = this.todayTrendingMoviesSource.asObservable();

  constructor(private http: HttpClient) {}

  getTodayTrendingMovies() {
    return this.http
      .get<any[]>(this.baseUrl + 'trendingmovies/today')
      .subscribe({
        next: (movies: any) => {
          console.log(movies.results);
          if (movies)
            this.todayTrendingMoviesSource.next(movies.results as Movie[]);
          return movies;
        },
        error: (error) => console.log(error.error),
      });
  }
}
