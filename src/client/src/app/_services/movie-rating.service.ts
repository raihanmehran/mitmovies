import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { RatedMovie } from '../_models/ratedMovie';

@Injectable({
  providedIn: 'root',
})
export class MovieRatingService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  addRatedMovie(ratedMovie: RatedMovie) {
    return this.http.post(this.baseUrl + 'ratedmovies/add', ratedMovie);
  }

  removeRatedMovie(movieId: number) {
    return this.http.delete(this.baseUrl + 'ratedmovies/remove/' + movieId);
  }
}
