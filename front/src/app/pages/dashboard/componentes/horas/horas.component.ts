import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ServicesService } from 'src/app/pages/services.service';
import { Dev, Projeto, DevInProjeto, BancoHoras } from '../../interfaces/models';

@Component({
  selector: 'app-horas',
  templateUrl: './horas.component.html',
  styleUrls: ['./horas.component.css']
})
export class HorasComponent implements OnInit {

  constructor(
    private svs: ServicesService,
    private router: Router
    ) { }

  form: FormGroup = new FormGroup({
    dataId: new FormControl("", [Validators.required]),
    dataIni: new FormControl("", [Validators.required]),
    dataFim: new FormControl("", [Validators.required]),
    desenvolvedor: new FormControl("", [Validators.required]),
  });

  desenvolvedores$: Observable<Dev[]>;

  Banco: BancoHoras[];

  ngOnInit(): void {
    this.desenvolvedores$ = this.svs.GetDevs();
    this.svs.GetBancoHoras().subscribe(x => this.Banco = x);
  }

  Adicionar(DataIni, HoraIni, DataFim, HoraFim, Desenvolvedor) {
    let data: BancoHoras = {
      bancoId: 1,
      dataIni: DataIni + "T" + HoraIni+":00.000",
      dataFim: DataFim + "T" + HoraFim+":00.000",
      desenvolvedor: Desenvolvedor
    }
    console.log(data);
    this.svs.SetInBancoHoras(data).subscribe(() =>
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate(["/horas"]))
  );

  }
  Remover(id: number) {
    this.svs.DelBancoHoras(id).subscribe(() =>
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate(["/horas"]))
  );
  }

}
