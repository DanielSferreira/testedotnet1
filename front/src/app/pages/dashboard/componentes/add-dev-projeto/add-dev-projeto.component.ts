import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-dev-projeto',
  templateUrl: './add-dev-projeto.component.html',
  styleUrls: ['./add-dev-projeto.component.css']
})
export class AddDevProjetoComponent implements OnInit {

  constructor() { }

  form: FormGroup = new FormGroup({
    Nome: new FormControl("", [Validators.required]),
    Cargo: new FormControl("", [Validators.required]),
    ValorH: new FormControl("", [Validators.required]),
  });
  ngOnInit(): void {
  }

}
