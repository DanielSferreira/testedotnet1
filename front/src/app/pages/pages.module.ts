import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from "@angular/forms"

import { PagesRoutingModule } from './pages-routing.module';

import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from "@angular/material/icon";
import { MatToolbarModule } from "@angular/material/toolbar";
import { RouterModule } from "@angular/router";


import { DashboardComponent } from './dashboard/dashboard.component';
import { MenuComponent } from './dashboard/componentes/menu/menu.component';
import { HorasComponent } from './dashboard/componentes/horas/horas.component';
import { ListarDevsComponent } from './dashboard/componentes/listar-devs/listar-devs.component';
import { NovoDevComponent } from './dashboard/componentes/novo-dev/novo-dev.component';
import { NovoProjetoComponent } from './dashboard/componentes/novo-projeto/novo-projeto.component';
import { ListarProjetosComponent } from './dashboard/componentes/listar-projetos/listar-projetos.component';
import { AddDevProjetoComponent } from './dashboard/componentes/add-dev-projeto/add-dev-projeto.component';


@NgModule({
  declarations: [
    DashboardComponent,
    MenuComponent,
    NovoDevComponent,
    ListarDevsComponent,
    HorasComponent,
    NovoProjetoComponent,
    ListarProjetosComponent,
    AddDevProjetoComponent
  ],
  imports: [
    CommonModule, 
    MatCardModule,
    MatListModule,
    RouterModule,
    MatButtonModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatIconModule,
    PagesRoutingModule
  ]
})
export class PagesModule { }
