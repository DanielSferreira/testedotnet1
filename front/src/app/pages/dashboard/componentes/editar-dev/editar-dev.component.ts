import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ServicesService } from 'src/app/pages/services.service';
import { Dev } from '../../interfaces/models';

@Component({
  selector: 'app-editar-dev',
  templateUrl: './editar-dev.component.html',
  styleUrls: ['./editar-dev.component.css']
})
export class EditarDevComponent implements OnInit {

  constructor(
    private svs: ServicesService,
    private route: ActivatedRoute,
    private router: Router
  ) {

    this.route.queryParams.subscribe(params => {

      this.form = new FormGroup({
        DesenvolvedorTableId: new FormControl(params["desenvolvedorTableId"], [Validators.required]),
        Nome: new FormControl(params["nome"], [Validators.required]),
        Cargo: new FormControl(params["cargo"], [Validators.required]),
        ValorH: new FormControl(params["valorH"], [Validators.required]),
      });
    });
  }
  form: FormGroup;

  ngOnInit(): void {

  }

  update() {
    let data: Dev = {
      desenvolvedorTableId: parseInt(this.form.controls["DesenvolvedorTableId"].value),
      Nome: this.form.controls["Nome"].value,
      Cargo: this.form.controls["Cargo"].value,
      ValorH: parseInt(this.form.controls["ValorH"].value)
    };
    
    let res =this.svs.PutDev(data);
    res.subscribe(() =>
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate(["/listarDevs"]))
  );
  }
}
