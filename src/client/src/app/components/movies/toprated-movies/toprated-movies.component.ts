import { Component, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/_models/movie';
import { ResponsePagination } from 'src/app/_models/responsePagination';
import { TopratedMoviesService } from 'src/app/_services/toprated-movies.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-toprated-movies',
  templateUrl: './toprated-movies.component.html',
  styleUrls: ['./toprated-movies.component.css'],
})
export class TopratedMoviesComponent implements OnInit {
  movies: any[] = [];
  response: ResponsePagination | undefined;
  imageUrl = environment.imageUrl;
  currentPage = 1;

  constructor(
    private topratedMoviesService: TopratedMoviesService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getTopRatedMovies(1);
  }

  getTopRatedMovies(page: number) {
    this.topratedMoviesService.getTopRatedMovies(page).subscribe({
      next: (response: any) => {
        if (response) this.setRepsonse(response);
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }
  private setRepsonse(response: any) {
    this.movies = response.results as Movie[];
    this.response = {
      dates: response.dates,
      page: response.page,
      totalPages: response.totalPages,
      totalResults: response.totalResults,
    };
  }

  pageChanged(event: PageChangedEvent) {
    this.getTopRatedMovies(event.page);
    this.scrollToTop();
  }
  scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
