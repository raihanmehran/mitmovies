import { Component, Input } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-tv-card-long',
  templateUrl: './tv-card-long.component.html',
  styleUrls: ['./tv-card-long.component.css'],
})
export class TvCardLongComponent {
  @Input() tvShow: any;
  imageUrl = environment.imageUrl;
}
