import { Component, OnInit } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';
import { Observable } from 'rxjs';
import { ServicesService } from 'src/app/pages/services.service';
import { Projeto, TopFive } from '../../interfaces/models';

@Component({
  selector: 'app-top-five',
  templateUrl: './top-five.component.html',
  styleUrls: ['./top-five.component.css']
})
export class TopFiveComponent implements OnInit {
  
  constructor(private svs: ServicesService,private router:Router) { }
  
  top$: Observable<TopFive[]>;

  ngOnInit(): void {
    this.top$ = this.svs.GetRanking(5);
  }
  delete(id: number) {
    this.svs.DelProj(id).subscribe(() =>
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() =>
      this.router.navigate(["/topFive"]))
  );
  }
}
