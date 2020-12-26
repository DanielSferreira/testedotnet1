import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddDevProjetoComponent } from './dashboard/componentes/add-dev-projeto/add-dev-projeto.component';
import { HorasComponent } from './dashboard/componentes/horas/horas.component';
import { ListarDevsComponent } from './dashboard/componentes/listar-devs/listar-devs.component';
import { ListarProjetosComponent } from './dashboard/componentes/listar-projetos/listar-projetos.component';
import { MenuComponent } from './dashboard/componentes/menu/menu.component';
import { NovoDevComponent } from './dashboard/componentes/novo-dev/novo-dev.component';
import { NovoProjetoComponent } from './dashboard/componentes/novo-projeto/novo-projeto.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  {
    path: '', component: DashboardComponent,
    children: [
      { path: '', component: MenuComponent },
      { path: 'novoDev', component: NovoDevComponent },
      { path: 'listarDevs', component: ListarDevsComponent },
      { path: 'lancamento', component: HorasComponent },
      { path: 'novoProjeto', component: NovoProjetoComponent },
      { path: 'addDevProjeto', component: AddDevProjetoComponent },
      { path: 'listarProjetos', component: ListarProjetosComponent }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
