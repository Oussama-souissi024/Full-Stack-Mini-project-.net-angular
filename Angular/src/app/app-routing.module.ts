import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCardComponent } from './add-card/add-card.component';
import { ListCardsComponent } from './list-cards/list-cards.component';
import { NotFoundError } from 'rxjs';
import { UpdateComponent } from './update/update.component';

const routes: Routes = [
  // { path: '', redirectTo: '/Add', pathMatch: 'full' },
  { path: 'Add', component: AddCardComponent },
  { path: 'List', component: ListCardsComponent },
  { path: 'Update/:id', component: UpdateComponent},
  { path: '', redirectTo: '/List', pathMatch: 'full' }, // Default route
  // Wildcard route for a 404 page
  { path: '**', component: NotFoundError }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
