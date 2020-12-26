import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-novo-projeto',
  templateUrl: './novo-projeto.component.html',
  styleUrls: ['./novo-projeto.component.css']
})
export class NovoProjetoComponent implements OnInit {

  constructor() { }
  form: FormGroup = new FormGroup({
    Nome: new FormControl("", [Validators.required]),
    Cargo: new FormControl("", [Validators.required]),
    ValorH: new FormControl("", [Validators.required]),
  });

  ngOnInit(): void {
  }

}
