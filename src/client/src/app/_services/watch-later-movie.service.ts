import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { WatchLater } from '../_models/watchLater';

@Injectable({
  providedIn: 'root',
})
export class WatchLaterMovieService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addWatchLaterMovie(watchLaterMovie: WatchLater) {
    return this.http.post(
      this.baseUrl + 'watchlatermovies/add',
      watchLaterMovie
    );
  }

  removeWatchLaterMovie(movieId: number) {
    return this.http.delete(
      this.baseUrl + 'watchlatermovies/remove/' + movieId
    );
  }
}
