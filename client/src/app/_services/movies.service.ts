import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { take } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MoviesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getMovie(movieId: any) {
    return this.http.get<any>(this.baseUrl + 'movies/details/' + movieId);
  }
}
