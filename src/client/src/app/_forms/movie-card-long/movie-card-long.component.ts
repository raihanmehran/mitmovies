import { Component, Input } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-movie-card-long',
  templateUrl: './movie-card-long.component.html',
  styleUrls: ['./movie-card-long.component.css'],
})
export class MovieCardLongComponent {
  @Input() movie: any;
  imageUrl = environment.imageUrl;
}
