import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TvShow } from '../_models/tvshow';

@Injectable({
  providedIn: 'root',
})
export class TrendingTvShowsService {
  baseUrl = environment.apiUrl;

  private todayTrendingTvShowsSource = new BehaviorSubject<TvShow[] | null>(
    null
  );
  todayTrendingTvShows$ = this.todayTrendingTvShowsSource.asObservable();

  private thisWeekTrendingTvShowsSource = new BehaviorSubject<TvShow[] | null>(
    null
  );
  thisWeekTrendingTvShows$ = this.thisWeekTrendingTvShowsSource.asObservable();

  constructor(private http: HttpClient) {}

  getTodayTrendingTvShows() {
    this.getTrendingTvShows('today');
  }
  getThisWeekTrendingTvShows() {
    this.getTrendingTvShows('week');
  }

  getTrendingTvShows(predicate: string) {
    this.http
      .get<any[]>(this.baseUrl + 'tvshows/trending/' + predicate)
      .subscribe({
        next: (tvShows: any) => {
          if (tvShows) {
            if (predicate === 'today') {
              this.todayTrendingTvShowsSource.next(tvShows as TvShow[]);
            } else {
              this.thisWeekTrendingTvShowsSource.next(tvShows as TvShow[]);
            }
          }
        },
        error: (error) => console.log(error.error),
      });
  }
}
