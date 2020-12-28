import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddDevProjetoComponent } from './dashboard/componentes/add-dev-projeto/add-dev-projeto.component';
import { EditarDevComponent } from './dashboard/componentes/editar-dev/editar-dev.component';
import { EditarProjComponent } from './dashboard/componentes/editar-proj/editar-proj.component';
import { HorasComponent } from './dashboard/componentes/horas/horas.component';
import { ListarDevsComponent } from './dashboard/componentes/listar-devs/listar-devs.component';
import { ListarProjetosComponent } from './dashboard/componentes/listar-projetos/listar-projetos.component';
import { MenuComponent } from './dashboard/componentes/menu/menu.component';
import { NovoDevComponent } from './dashboard/componentes/novo-dev/novo-dev.component';
import { NovoProjetoComponent } from './dashboard/componentes/novo-projeto/novo-projeto.component';
import { TopFiveComponent } from './dashboard/componentes/top-five/top-five.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  {
    path: '', component: DashboardComponent,
    children: [
      { path: '', component: MenuComponent },
      { path: 'novoDev', component: NovoDevComponent },
      { path: 'listarDevs', component: ListarDevsComponent },
      { path: 'editDev', component: EditarDevComponent },
      { path: 'lancamento', component: HorasComponent },
      { path: 'novoProjeto', component: NovoProjetoComponent },
      { path: 'addDevProjeto', component: AddDevProjetoComponent },
      { path: 'editProj', component: EditarProjComponent },
      { path: 'listarProjetos', component: ListarProjetosComponent },
      { path: 'horas', component: HorasComponent },
      { path: 'topFive', component: TopFiveComponent },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
