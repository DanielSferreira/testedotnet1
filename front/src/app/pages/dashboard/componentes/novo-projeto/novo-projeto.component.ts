import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router/';
import { ServicesService } from 'src/app/pages/services.service';
import { Projeto } from '../../interfaces/models';

@Component({
  selector: 'app-novo-projeto',
  templateUrl: './novo-projeto.component.html',
  styleUrls: ['./novo-projeto.component.css']
})
export class NovoProjetoComponent implements OnInit {

  constructor(
    private svs: ServicesService,
    private router: Router
  ) { }
  
  form: FormGroup = new FormGroup({
    projeto: new FormControl("", [Validators.required]),
    descricao: new FormControl("", [Validators.required])
  });

  ngOnInit(): void {
  }
  save() {
    let data: Projeto = {
      projeto: this.form.controls["projeto"].value,
      descricao: this.form.controls["descricao"].value
    }
    let res = this.svs.SetProj(data);
    res.subscribe(() =>
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate(["/listarProjetos"]))
  );
    
  }
}
