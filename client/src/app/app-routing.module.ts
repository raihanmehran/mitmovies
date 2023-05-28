import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './components/user/auth/auth.component';
import { HomeComponent } from './components/home/home/home.component';
import { ProfileUserComponent } from './components/user/profile-user/profile-user.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'account/auth', component: AuthComponent },
  {
    path: '',
    children: [
      {
        path: 'user/profile',
        component: ProfileUserComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
