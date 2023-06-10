import { Component, OnInit } from '@angular/core';
import { TvShow } from 'src/app/_models/tvshow';
import { TrendingTvShowsService } from 'src/app/_services/trending-tv-shows.service';

@Component({
  selector: 'app-trending-tv-shows',
  templateUrl: './trending-tv-shows.component.html',
  styleUrls: ['./trending-tv-shows.component.css'],
})
export class TrendingTvShowsComponent implements OnInit {
  todayTrendingTvShows: TvShow[] = [];
  thisWeekTrendingTvShows: TvShow[] = [];

  constructor(private trendingTvShowsService: TrendingTvShowsService) {}

  ngOnInit(): void {
    this.getTodayTrendingTvShows();

    this.trendingTvShowsService.todayTrendingTvShows$.subscribe({
      next: (tvShows) => {
        console.log(tvShows);

        if (tvShows) this.todayTrendingTvShows = tvShows;
        else this.todayTrendingTvShows = [];
      },
    });

    this.trendingTvShowsService.thisWeekTrendingTvShows$.subscribe({
      next: (tvShows) => {
        if (tvShows) this.thisWeekTrendingTvShows = tvShows;
        else this.thisWeekTrendingTvShows = [];
      },
    });
  }

  getTodayTrendingTvShows() {
    this.trendingTvShowsService.getTodayTrendingTvShows();
  }

  getThisWeekTrendingTvShows() {
    this.trendingTvShowsService.getThisWeekTrendingTvShows();
  }
}
