import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class WatchedMoviesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addToWatchedMovies(id: number) {
    return this.http.post(this.baseUrl + 'watchedmovies/add/' + id, id);
  }

  removeFromWatchedMovies(id: number) {
    return this.http.post(this.baseUrl + 'watchedmovies/remove/' + id, id);
  }

  getWatchedMovies() {
    return this.http
      .get<any[]>(this.baseUrl + 'watchedmovies')
      .pipe()
      .subscribe({
        next: (movies) => {
          return movies;
        },
        error: (error) => console.log(error.error),
      });
  }
}
