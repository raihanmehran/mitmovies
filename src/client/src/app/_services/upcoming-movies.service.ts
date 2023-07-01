import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Movie } from '../_models/movie';

@Injectable({
  providedIn: 'root',
})
export class UpcomingMoviesService {
  private baseUrl = environment.apiUrl;

  private upcomingMoviesSource = new BehaviorSubject<Movie[] | null>(null);
  upcomingMovies$ = this.upcomingMoviesSource.asObservable();

  constructor(private http: HttpClient) {}

  getUpcomingMovies() {
    return this.http.get<any[]>(this.baseUrl + 'movies/upcoming').subscribe({
      next: (response: any) =>
        this.upcomingMoviesSource.next(response.results as Movie[]),
      error: (error) => console.log(error.error),
    });
  }
}
