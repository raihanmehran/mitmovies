import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TvService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getTvShow(id: string) {
    return this.http.get<any>(this.baseUrl + 'tvshows/' + id);
  }

  searchTvShwos(query: string) {
    return this.http.get<any>(this.baseUrl + 'tvShows/search?query=' + query);
  }
}
