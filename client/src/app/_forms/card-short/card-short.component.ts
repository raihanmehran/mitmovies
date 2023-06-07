import { Component, Input } from '@angular/core';
import { Movie } from 'src/app/_models/movie';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-card-short',
  templateUrl: './card-short.component.html',
  styleUrls: ['./card-short.component.css'],
})
export class CardShortComponent {
  @Input() movie: Movie | undefined;
  imageUrl = environment.imageUrl;

  getPopularity(avgVote: number) {
    if (avgVote) return Math.floor((avgVote / 10) * 100);
    return 0;
  }
}
