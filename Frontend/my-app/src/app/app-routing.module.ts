import { CategoriasComponent } from './categorias/categorias.component';
import { DashboardCategoriaComponent } from './categorias/dashboard-categoria/dashboard-categoria.component';
import { DetalheCategoriaComponent } from './categorias/detalhe-categoria/detalhe-categoria.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'categorias/dashboard', pathMatch: 'full' },//Rota padrão
  { path: 'categorias', component: CategoriasComponent },
  { path: 'categorias/dashboard', component: DashboardCategoriaComponent },
  { path: 'categorias/:id', component: DetalheCategoriaComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
