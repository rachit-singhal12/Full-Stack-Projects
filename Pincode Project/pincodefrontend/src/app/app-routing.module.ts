import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ParentformComponent } from './parentform/parentform.component';
import { FormdataComponent } from './formdata/formdata.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';

const routes: Routes = [
  {
    path: '',
    component: ParentformComponent,
  },
  {
    path: 'formdata',
    component: FormdataComponent,
  },
 {
  path : ':id',
  component : ParentformComponent,
 },
 {
  path:'**',
  component: PagenotfoundComponent,
 }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
