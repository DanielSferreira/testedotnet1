import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/pages/services.service';
import { Dev } from '../../interfaces/models';

@Component({
  selector: 'app-novo-dev',
  templateUrl: './novo-dev.component.html',
  styleUrls: ['./novo-dev.component.css']
})
export class NovoDevComponent implements OnInit {


  constructor(
    private svs: ServicesService,
    private router: Router
  ) { }
  
  form: FormGroup = new FormGroup({
    Nome: new FormControl("", [Validators.required]),
    Cargo: new FormControl("", [Validators.required]),
    ValorH: new FormControl("", [Validators.required]),
  });

  ngOnInit(): void {
  }

  save() {
    let data: Dev = {
      Nome: this.form.controls["Nome"].value,
      Cargo: this.form.controls["Cargo"].value,
      ValorH: this.form.controls["ValorH"].value,
    }
    
    let res = this.svs.SetDev(data).subscribe(() =>
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate(["/listarDevs"]))
  );
    
  }
}
