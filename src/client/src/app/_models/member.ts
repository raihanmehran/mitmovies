import { FavouriteMovie } from './favouriteMovie';
import { FavouritePerson } from './favouritePerson';
import { Photo } from './photo';

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
  favouriteTvShows: any[];
  watchedMovies: any[];
  watchedTvShows: any[];
  userGenres: any[];
}
