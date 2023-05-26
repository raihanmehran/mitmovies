import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/base/login/login.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  // { path: '', children: [{}] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
