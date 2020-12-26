import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-novo-dev',
  templateUrl: './novo-dev.component.html',
  styleUrls: ['./novo-dev.component.css']
})
export class NovoDevComponent implements OnInit {

  constructor() { }
  form: FormGroup = new FormGroup({
    Nome: new FormControl("", [Validators.required]),
    Cargo: new FormControl("", [Validators.required]),
    ValorH: new FormControl("", [Validators.required]),
  });
  ngOnInit(): void {
  }

}
