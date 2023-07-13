import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';

@Injectable({
  providedIn: 'root',
})
export class UserInteractionsService {
  data: any[] = [];
  loading = true;
  error: any;

  constructor(private apollo: Apollo) {}

  getUserData() {
    console.log('called');

    this.apollo
      .watchQuery({
        query: gql`
          {
            hello
            favoriteMovies {
              id
              title
              overview
              originalLanguage
              imdbId
              posterPath
              releaseDate
              status
              revenue
              budget
            }
            watchedMovies {
              id
              title
              overview
              originalLanguage
              posterPath
              releaseDate
              status
              revenue
              budget
            }
            watchLaterMovies {
              id
              title
              overview
              originalLanguage
              posterPath
              releaseDate
              status
              revenue
              budget
            }
            ratedMovies {
              rating
              movie {
                id
                title
                overview
                originalLanguage
                posterPath
                releaseDate
                status
                revenue
                budget
              }
            }
            favoriteTvShows {
              id
              name
              originalName
              posterPath
              voteAverage
              popularity
              firstAirDate
              lastAirDate
              inProduction
              numberOfEpisodes
              numberOfSeasons
              originalName
              originalLanguage
              overview
            }
            watchedTvShows {
              id
              name
              originalName
              posterPath
              voteAverage
              popularity
              firstAirDate
              lastAirDate
              inProduction
              numberOfEpisodes
              numberOfSeasons
              originalName
              originalLanguage
              overview
            }
            watchLaterTvShows {
              id
              name
              originalName
              posterPath
              voteAverage
              popularity
              firstAirDate
              lastAirDate
              inProduction
              numberOfEpisodes
              numberOfSeasons
              originalName
              originalLanguage
              overview
            }
            ratedTvShows {
              id
              name
              originalName
              posterPath
              voteAverage
              popularity
              firstAirDate
              lastAirDate
              inProduction
              numberOfEpisodes
              numberOfSeasons
              originalName
              originalLanguage
              overview
              userRating
            }
          }
        `,
      })
      .valueChanges.subscribe((result: any) => {
        this.data = result.data.hello;
        this.loading = result.loading;
        this.error = result.error;
        console.log(result.data);
      });

    console.log('data: ');
    console.log(this.data);
    console.log(this.loading);
    console.log(this.error);
  }
}
