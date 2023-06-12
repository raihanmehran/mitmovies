import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Member } from '../_models/member';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, take } from 'rxjs';
import { FavouriteMovie } from '../_models/favouriteMovie';

@Injectable({
  providedIn: 'root',
})
export class MemberService {
  baseUrl = environment.apiUrl;

  private memberSource = new BehaviorSubject<Member | null>(null);
  member$ = this.memberSource.asObservable();

  constructor(private http: HttpClient) {}

  getMember() {
    return this.http
      .get<Member>(this.baseUrl + 'users/member-self')
      .pipe(take(1))
      .subscribe({
        next: (member) => {
          this.memberSource.next(member);
          console.log(member);
        },
      });
  }

  addFavoriteMovie(movie: FavouriteMovie) {
    this.member$.subscribe({
      next: (member) => {
        if (member) {
          member.favouriteMovies.push(movie);
        }
      },
      error: (error) => console.log(error),
    });
  }
}
