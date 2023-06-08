import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './components/user/auth/auth.component';
import { HomeComponent } from './components/home/home/home.component';
import { ProfileUserComponent } from './components/user/profile-user/profile-user.component';
import { MovieDetailComponent } from './components/movies/movie-detail/movie-detail/movie-detail.component';
import { TvDetailComponent } from './components/tv/tv-detail/tv-detail/tv-detail.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'account/auth', component: AuthComponent },
  {
    path: 'movies/:movieid',
    component: MovieDetailComponent,
  },
  {
    path: 'tv/:tvshowid',
    component: TvDetailComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
