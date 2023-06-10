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
    this.http
      .post(this.baseUrl + 'favouritemovies/add/' + id, id)
      .pipe(map((response) => response));
  }
}
