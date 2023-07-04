import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, tap } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TopratedMoviesService {
  baseUrl = environment.apiUrl;
  private cache: { [key: string]: any } = {};

  constructor(private http: HttpClient) {}

  getTopRatedMovies(page: number): Observable<any> {
    const cacheKey = `toprated${page}`;

    if (this.cache[cacheKey]) {
      return of(this.cache[cacheKey]);
    }

    return this.http
      .get<any[]>(this.baseUrl + 'movies/toprated?page=' + page)
      .pipe(tap((response) => (this.cache[cacheKey] = response)));
  }
}
