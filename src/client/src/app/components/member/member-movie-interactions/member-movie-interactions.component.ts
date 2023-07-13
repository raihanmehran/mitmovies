import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-member-movie-interactions',
  templateUrl: './member-movie-interactions.component.html',
  styleUrls: ['./member-movie-interactions.component.css'],
})
export class MemberMovieInteractionsComponent {
  @Input() movies: any[] = [];
  @Input() title: string = '';
}
