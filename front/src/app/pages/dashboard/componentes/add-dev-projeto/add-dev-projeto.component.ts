import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ServicesService } from 'src/app/pages/services.service';
import { Dev, DevInProjeto, Projeto } from '../../interfaces/models';

@Component({
  selector: 'app-add-dev-projeto',
  templateUrl: './add-dev-projeto.component.html',
  styleUrls: ['./add-dev-projeto.component.css']
})
export class AddDevProjetoComponent implements OnInit {

  constructor(
    private svs: ServicesService,
    private router: Router
    ) { }

  form: FormGroup = new FormGroup({
    desenvolvedor: new FormControl("", [Validators.required]),
    projeto: new FormControl("", [Validators.required]),
  });

  desenvolvedores$: Observable<Dev[]>;
  projetos$: Observable<Projeto[]>;

  devProj: DevInProjeto[];
  proj: Projeto[];

  ngOnInit(): void {
    this.desenvolvedores$ = this.svs.GetDevs();
    this.projetos$ = this.svs.GetProj();
    this.svs.GetDevsProj().subscribe(x => this.devProj = x);
  }

  Adicionar(dev: string, proj: number) {
    this.devProj.push({
      desenvolvedor: dev,
      projetoTableId: Number(proj)
    });
  }
  Remover(id: number) {
    this.devProj = this.devProj.filter(x => Number(x.projetoTableId) !== Number(id));
  }
  Update() {
    this.svs.PutDevsProj(this.devProj).subscribe(() =>
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate(["/addDevProjeto"]))
  );
  }

}
