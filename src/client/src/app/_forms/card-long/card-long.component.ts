import { Component, Input } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-card-long',
  templateUrl: './card-long.component.html',
  styleUrls: ['./card-long.component.css'],
})
export class CardLongComponent {
  @Input() movie: any;
  imageUrl = environment.imageUrl;
}
