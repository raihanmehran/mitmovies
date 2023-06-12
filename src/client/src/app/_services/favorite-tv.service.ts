import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FavoriteTvService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addToFavoriteTvShows(id: number) {
    return this.http.post(this.baseUrl + 'favouritetvshows/add/' + id, id);
  }

  removeFromFavoriteTvShows(id: number) {
    return this.http.post(this.baseUrl + 'favouritetvshows/remove/' + id, id);
  }

  getFavoriteTvShows() {
    return this.http
      .get<any[]>(this.baseUrl + 'favouritetvshows')
      .pipe()
      .subscribe({
        next: (tvShows) => {
          return tvShows;
        },
        error: (error) => console.log(error.error),
      });
  }
}
