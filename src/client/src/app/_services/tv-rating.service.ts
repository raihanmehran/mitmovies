import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { RatedTvShow } from '../_models/ratedTvShow';

@Injectable({
  providedIn: 'root',
})
export class TvRatingService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addRatedTvShow(rateTvShow: RatedTvShow) {
    return this.http.post(this.baseUrl + 'ratedtvshows/add', rateTvShow);
  }

  removeRatedTvShow(tvShowId: number) {
    return this.http.delete(this.baseUrl + 'ratedtvshows/remove/' + tvShowId);
  }
}
