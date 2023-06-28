import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class WatchedTvService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addToWatchedTvShows(id: number) {
    return this.http.post(this.baseUrl + 'watchedtvshows/add/' + id, id);
  }

  removeFromWatchedTvShows(id: number) {
    return this.http.post(this.baseUrl + 'watchedtvshows/remove/' + id, id);
  }

  getWatchedTvShows() {
    return this.http
      .get<any[]>(this.baseUrl + 'watchedtvshows')
      .pipe()
      .subscribe({
        next: (tvShows) => {
          return tvShows;
        },
        error: (error) => console.log(error.error),
      });
  }
}
