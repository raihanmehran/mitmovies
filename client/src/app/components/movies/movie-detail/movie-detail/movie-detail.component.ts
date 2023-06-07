import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { MoviesService } from 'src/app/_services/movies.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css'],
})
export class MovieDetailComponent implements OnInit {
  movie: any;
  imageUrl = environment.imageUrl;
  videoUrl = environment.videoUrl;
  movieId: string = '';

  constructor(
    private moviesService: MoviesService,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {}
  
  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.movieId = params['movieid'];
      this.getMovie();
    });
  }

  getMovie() {
    // const movieId = this.route.snapshot.paramMap.get('movieid');

    if (!this.movieId) return;
    this.moviesService
      .getMovie(this.movieId)
      .pipe(take(1))
      .subscribe({
        next: (movie) => {
          console.log(movie);

          if (movie) {
            this.movie = movie;
          } else {
            this.toastr.error(
              'Movie with id ' + this.movieId + ' not found',
              'NOT FOUND'
            );
          }
        },
      });
  }

  convertMinutesToTime(minutes: number) {
    const hours = Math.floor(minutes / 60);
    const mins = minutes % 60;

    // const formattedHours = hours < 10 ? `0${hours}` : `${hours}`;
    // const formattedMins = mins < 10 ? `0${mins}` : `${mins}`;

    return `${hours}h ${mins}m`;
  }

  getReviewDate(url: string) {
    const urlRegex = /https:\/\/\S+\/(\d{4}\/\d{2}\/\d{2})/;
    const matches = url.match(urlRegex);
    if (matches && matches.length > 0) return matches[1];
    return '';
  }

  getReviewerAvatarUrl(url: string) {
    if (url !== '')
      url.startsWith('/https:')
        ? (url = url.substring(1))
        : (url = this.imageUrl + url);

    return url;
  }
}
