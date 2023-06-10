import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/movie';

@Injectable({
  providedIn: 'root',
})
export class PopularMoviesService {
  baseUrl = environment.apiUrl;

  private popularMoviesSource = new BehaviorSubject<Movie[] | null>(null);
  popularMovies$ = this.popularMoviesSource.asObservable();

  constructor(private http: HttpClient) {}

  getPopularMovies() {
    this.http.get<any[]>(this.baseUrl + 'movies/popular').subscribe({
      next: (movies: any) => {
        this.popularMoviesSource.next(movies.results as Movie[]);
      },
      error: (error) => console.log(error.error),
    });
  }
}
