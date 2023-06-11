import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FavoriteMoviesService {
  baseUrl = environment.apiUrl;
  favoriteMovies: any[] = [];

  constructor(private http: HttpClient) {}

  addToFavoriteMovies(id: number) {
    this.http
      .post(this.baseUrl + 'favouritemovies/add/' + id, id)
      .pipe(map((response) => response));
  }

  removeFromFavoriteMovies(id: number) {
    this.http
      .post(this.baseUrl + 'favouritemovies/remove/' + id, id)
      .pipe(map((response) => response));
  }

  getFavoriteMovies() {
    this.http
      .get<any[]>(this.baseUrl + 'favouritemovies')
      .pipe()
      .subscribe({
        next: (movies) => {
          console.log(movies);

          this.favoriteMovies = movies;
        },
        error: (error) => console.log(error.error),
      });
  }
}
