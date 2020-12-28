import { Component, OnInit } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ServicesService } from 'src/app/pages/services.service';
import { DevInProjeto, Projeto } from '../../interfaces/models';

@Component({
  selector: 'app-listar-projetos',
  templateUrl: './listar-projetos.component.html',
  styleUrls: ['./listar-projetos.component.css']
})
export class ListarProjetosComponent implements OnInit {

  constructor(private svs: ServicesService,private router:Router) { }
  
  projetos$: Observable<Projeto[]>;

  ngOnInit(): void {
    this.projetos$ = this.svs.GetProj();
  }
  redirect(obj: Projeto) {
    let navigationExtras: NavigationExtras = { queryParams: obj };
    this.router.navigate(["editProj"], navigationExtras);
  }
  delete(id: number) {
    this.svs.DelProj(id).subscribe(() =>
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate(["/listarProjetos"]))
  );
  }
}
