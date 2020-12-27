import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ServicesService } from 'src/app/pages/services.service';
import { Projeto } from '../../interfaces/models';

@Component({
  selector: 'app-novo-projeto',
  templateUrl: './novo-projeto.component.html',
  styleUrls: ['./novo-projeto.component.css']
})
export class NovoProjetoComponent implements OnInit {

  constructor(private svs: ServicesService) { }
  
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
    res.subscribe(e=>console.log(e));
    
  }
}
