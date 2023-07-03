import { Component, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/_models/movie';
import { ResponsePagination } from 'src/app/_models/responsePagination';
import { UpcomingMoviesService } from 'src/app/_services/upcoming-movies.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-upcoming-movies',
  templateUrl: './upcoming-movies.component.html',
  styleUrls: ['./upcoming-movies.component.css'],
})
export class UpcomingMoviesComponent implements OnInit {
  movies: any[] = [];
  response: ResponsePagination | undefined;
  imageUrl = environment.imageUrl;
  currentPage = 1;

  constructor(
    private upcomingMoviesService: UpcomingMoviesService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getUpcomingMovies(1);
  }

  getUpcomingMovies(page: number) {
    this.upcomingMoviesService.getUpcomingMovies(page).subscribe({
      next: (response: any) => {
        if (response) {
          this.movies = response.results as Movie[];
          this.response = {
            dates: response.dates,
            page: response.page,
            totalPages: response.totalPages,
            totalResults: response.totalResults,
          };
        }
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  pageChanged(event: PageChangedEvent) {
    this.getUpcomingMovies(event.page);
    this.scrollToTop();
  }
  scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
