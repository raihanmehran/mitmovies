import { Component, Input } from '@angular/core';
import { Movie } from 'src/app/_models/movie';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-movie-card-short',
  templateUrl: './movie-card-short.component.html',
  styleUrls: ['./movie-card-short.component.css'],
})
export class MovieCardShortComponent {
  @Input() movie: Movie | undefined;
  imageUrl = environment.imageUrl;

  getPopularity(avgVote: number) {
    if (avgVote) return Math.floor((avgVote / 10) * 100);
    return 0;
  }
}
