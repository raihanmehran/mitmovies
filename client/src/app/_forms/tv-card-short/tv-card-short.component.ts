import { Component, Input } from '@angular/core';
import { TvShow } from 'src/app/_models/tvshow';
import { AccountService } from 'src/app/_services/account.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-tv-card-short',
  templateUrl: './tv-card-short.component.html',
  styleUrls: ['./tv-card-short.component.css'],
})
export class TvCardShortComponent {
  @Input() tvShow: TvShow | undefined;
  imageUrl = environment.imageUrl;

  constructor(public accountService: AccountService) {}

  getPopularity(avgVote: number) {
    if (avgVote) return Math.floor((avgVote / 10) * 100);
    return 0;
  }
}
