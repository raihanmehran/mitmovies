import { FavouriteMovie } from './favouriteMovie';
import { FavouritePerson } from './favouritePerson';
import { FavouriteTvShow } from './favouriteTvShow';
import { Photo } from './photo';
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
}