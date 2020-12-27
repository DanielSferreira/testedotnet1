import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ServicesService } from 'src/app/pages/services.service';
import { Dev } from '../../interfaces/models';

@Component({
  selector: 'app-listar-devs',
  templateUrl: './listar-devs.component.html',
  styleUrls: ['./listar-devs.component.css']
})
export class ListarDevsComponent implements OnInit {

  constructor(private svs: ServicesService) { }
  desenvolvedores$: Observable<Dev[]>;
  
  ngOnInit(): void {
    this.desenvolvedores$ = this.svs.GetDevs();
  }

}
