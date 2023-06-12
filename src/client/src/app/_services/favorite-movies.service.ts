import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FavoriteMoviesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addToFavoriteMovies(id: number) {
    return this.http.post(this.baseUrl + 'favouritemovies/add/' + id, id);
  }

  removeFromFavoriteMovies(id: number) {
    return this.http.post(this.baseUrl + 'favouritemovies/remove/' + id, id);
  }

  getFavoriteMovies() {
    return this.http
      .get<any[]>(this.baseUrl + 'favouritemovies')
      .pipe()
      .subscribe({
        next: (movies) => {
          return movies;
        },
        error: (error) => console.log(error.error),
      });
  }
}
