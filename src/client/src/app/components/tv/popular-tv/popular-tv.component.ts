import { Component, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { ToastrService } from 'ngx-toastr';
import { ResponsePagination } from 'src/app/_models/responsePagination';
import { TvShow } from 'src/app/_models/tvshow';
import { PopularTvService } from 'src/app/_services/popular-tv.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-popular-tv',
  templateUrl: './popular-tv.component.html',
  styleUrls: ['./popular-tv.component.css'],
})
export class PopularTvComponent implements OnInit {
  tvShows: any[] = [];
  response: ResponsePagination | undefined;
  imageUrl = environment.imageUrl;
  currentPage = 1;

  constructor(
    private popularTvService: PopularTvService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getPopularTvShows(1);
  }

  getPopularTvShows(page: number) {
    this.popularTvService.getPopularTvShows(page).subscribe({
      next: (response: any) => {
        if (response) this.setRepsonse(response);
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  private setRepsonse(response: any) {
    this.tvShows = response.results as TvShow[];
    this.response = {
      dates: response.dates,
      page: response.page,
      totalPages: response.totalPages,
      totalResults: response.totalResults,
    };
  }

  pageChanged(event: PageChangedEvent) {
    this.getPopularTvShows(event.page);
    this.scrollToTop();
  }
  scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
