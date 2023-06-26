import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { WatchLater } from '../_models/watchLater';

@Injectable({
  providedIn: 'root',
})
export class WatchLaterTvService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addWatchLaterTvShow(watchLaterTvShow: WatchLater) {
    return this.http.post(
      `${this.baseUrl}watchlatertvshows/add`,
      watchLaterTvShow
    );
  }

  removeWatchLaterTvShow(tvShowId: number) {
    return this.http.delete(
      `${this.baseUrl}watchlatertvshows/remove/${tvShowId}`
    );
  }
}
