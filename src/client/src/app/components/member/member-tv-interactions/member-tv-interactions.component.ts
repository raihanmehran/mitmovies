import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-member-tv-interactions',
  templateUrl: './member-tv-interactions.component.html',
  styleUrls: ['./member-tv-interactions.component.css'],
})
export class MemberTvInteractionsComponent {
  @Input() tvShows: any[] = [];
  @Input() title: string = '';
}
