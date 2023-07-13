import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { UserInteractions } from '../_models/userInteractions';

@Injectable({
  providedIn: 'root',
})
export class UserInteractionsService {
  constructor(private apollo: Apollo) {}

  getUserData() {
    return this.apollo.watchQuery({
      query: gql`
        {
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
    });
  }
}
