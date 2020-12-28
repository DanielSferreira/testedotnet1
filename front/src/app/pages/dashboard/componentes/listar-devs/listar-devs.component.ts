import { Component, OnInit } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ServicesService } from 'src/app/pages/services.service';
import { Dev } from '../../interfaces/models';

@Component({
  selector: 'app-listar-devs',
  templateUrl: './listar-devs.component.html',
  styleUrls: ['./listar-devs.component.css']
})
export class ListarDevsComponent implements OnInit {

  constructor(
    private svs: ServicesService,
    private router: Router
  ) { }
  desenvolvedores$: Observable<Dev[]>;

  ngOnInit(): void {
    this.desenvolvedores$ = this.svs.GetDevs();
  }
  save(obj: Dev) {
    let navigationExtras: NavigationExtras = { queryParams: obj };
    this.router.navigate(["editDev"], navigationExtras);
  }
  delete(id: number) {
    let res = this.svs.DelDev(id).subscribe(() =>
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
        this.router.navigate(["/listarDevs"]))
    );
  }
}
