import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './components/user/auth/auth.component';
import { HomeComponent } from './components/home/home/home.component';
import { ProfileUserComponent } from './components/member/profile-user/profile-user.component';
import { MovieDetailComponent } from './components/movies/movie-detail/movie-detail/movie-detail.component';
import { TvDetailComponent } from './components/tv/tv-detail/tv-detail/tv-detail.component';
import { SearchResultComponent } from './components/search/search-result/search-result.component';
import { AuthGuard } from './_guards/auth.guard';
import { UpcomingMoviesComponent } from './components/movies/upcoming-movies/upcoming-movies.component';
import { PopularMoviesComponent } from './components/movies/popular-movies/popular-movies.component';
import { TopratedMoviesComponent } from './components/movies/toprated-movies/toprated-movies.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'account/auth', component: AuthComponent },
  {
    path: 'movies/upcoming',
    component: UpcomingMoviesComponent,
  },
  {
    path: 'movies/popular',
    component: PopularMoviesComponent,
  },
  {
    path: 'movies/toprated',
    component: TopratedMoviesComponent,
  },
  {
    path: 'movies/:movieid',
    component: MovieDetailComponent,
  },
  {
    path: 'tv/:tvshowid',
    component: TvDetailComponent,
  },
  {
    path: 'search/:query',
    component: SearchResultComponent,
  },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [{ path: 'user/profile', component: ProfileUserComponent }],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
