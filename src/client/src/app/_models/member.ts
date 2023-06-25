import { FavouriteMovie } from './favouriteMovie';
import { FavouritePerson } from './favouritePerson';
import { FavouriteTvShow } from './favouriteTvShow';
import { Photo } from './photo';
import { RatedMovie } from './ratedMovie';
import { RatedTvShow } from './ratedTvShow';
import { WatchLater } from './watchLater';
import { WatchedMovie } from './watchedMovie';

export interface Member {
  id: number;
  userName: string;
  firstName: string;
  lastName: string;
  email: string;
  country: string;
  created: string;
  lastActive: string;
  photos: Photo[];
  favouriteMovies: FavouriteMovie[];
  favouritePeople: FavouritePerson[];
  favouriteTvShows: FavouriteTvShow[];
  watchedMovies: WatchedMovie[];
  watchedTvShows: any[];
  userGenres: any[];
  ratedMovies: RatedMovie[];
  rateTvShows: RatedTvShow[];
  watchLaters: WatchLater[];
}
