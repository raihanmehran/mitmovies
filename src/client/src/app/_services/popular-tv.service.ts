import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, tap } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PopularTvService {
  baseUrl = environment.apiUrl;
  private cache: { [key: string]: any } = {};

  constructor(private http: HttpClient) {}

  getPopularTvShows(page: number): Observable<any> {
    const cacheKey = `popular${page}`;

    if (this.cache[cacheKey]) return of(this.cache[cacheKey]);

    return this.http
      .get<any[]>(this.baseUrl + 'tvshows/popular?page=' + page)
      .pipe(tap((response) => (this.cache[cacheKey] = response)));
  }
}
