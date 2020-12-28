import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ServicesService } from 'src/app/pages/services.service';
import { Projeto } from '../../interfaces/models';

@Component({
  selector: 'app-editar-proj',
  templateUrl: './editar-proj.component.html',
  styleUrls: ['./editar-proj.component.css']
})
export class EditarProjComponent implements OnInit {

  constructor(
    private svs: ServicesService,
    private route: ActivatedRoute,
    private router: Router
  ) {

    this.route.queryParams.subscribe(params => {

      this.form = new FormGroup({
        id: new FormControl(params["id"], [Validators.required]),
        projeto: new FormControl(params["projeto"], [Validators.required]),
        descricao: new FormControl(params["descricao"], [Validators.required]),
      });
    });
  }
  form: FormGroup;

  ngOnInit(): void {

  }

  update() {
    let data: Projeto = {
      Id: parseInt(this.form.controls["id"].value),
      projeto: this.form.controls["projeto"].value,
      descricao: this.form.controls["descricao"].value,
    };

    let res = this.svs.PutProj(data);
    res.subscribe(() =>
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate(["/listarProjetos"]))
  );
  }
}
