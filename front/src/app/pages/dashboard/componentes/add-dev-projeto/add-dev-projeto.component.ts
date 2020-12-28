import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ServicesService } from 'src/app/pages/services.service';
import { Dev, Projeto } from '../../interfaces/models';

@Component({
  selector: 'app-add-dev-projeto',
  templateUrl: './add-dev-projeto.component.html',
  styleUrls: ['./add-dev-projeto.component.css']
})
export class AddDevProjetoComponent implements OnInit {

  constructor(private svs: ServicesService) { }

  form: FormGroup = new FormGroup({
    desenvolvedor: new FormControl("", [Validators.required]),
    projeto: new FormControl("", [Validators.required]),
  });

  desenvolvedores$: Observable<Dev[]>;
  projetos$: Observable<Projeto[]>;
  DevProj$: Observable<Projeto[]>;

  ngOnInit(): void {
    this.desenvolvedores$ = this.svs.GetDevs();
    this.projetos$ = this.svs.GetProj();
    this.DevProj$ = this.svs.GetDevsProj();
  }

}
