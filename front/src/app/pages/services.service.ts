import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { Dev, Projeto } from './dashboard/interfaces/models';



@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      "Access-Control-Allow-Origin":"https://localhost:5001/",
      "Access-Control-Allow-Headers":"Origin, X-Request-Width, Content-Type, Accept"
      
    })
  };
  constructor(private http: HttpClient) { }
  private configUrl = "https://localhost:5001/";
  GetDevs() {
    return this.http.get<Dev[]>(this.configUrl+"Desenvolvedor/",this.httpOptions).pipe(map(a => a ), catchError(this.handleError));    
  }
  
  SetDev(dev: Dev):any {    
    return this.http.post<any>(this.configUrl+"Desenvolvedor/",{
      Nome: dev.Nome,
      Cargo: dev.Cargo,
      ValorH: dev.ValorH
    },this.httpOptions).pipe(map(a => a ), catchError(this.handleError));    
  }

  GetProj() {
    return this.http.get<Projeto[]>(this.configUrl+"Projetos/",this.httpOptions).pipe(map(a => a ), catchError(this.handleError));    
  }

  SetProj(Projeto: Projeto):any {    
    return this.http.post<any>(this.configUrl+"Projetos/",{
      projeto: Projeto.projeto,
      descricao: Projeto.descricao
    },this.httpOptions).pipe(map(a => a ), catchError(this.handleError));    
  }

  PutProj(Projeto: Projeto) {
    return this.http.put<any>(this.configUrl+"Projetos/",{
      projeto: Projeto.projeto,
      descricao: Projeto.descricao
    },this.httpOptions).pipe(map(a => a ), catchError(this.handleError));
  }

  PutDevsProj(Projeto: Projeto):any {    
    return this.http.put<any>(this.configUrl+"Projetos/PutDevs",{
      projeto: Projeto.projeto,
      descricao: Projeto.descricao,
      devsEmProjetosTable: Projeto.devsEmProjetosTable
    },this.httpOptions).pipe(map(a => a ), catchError(this.handleError));    
  }


  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error("Ocorreu um erro");
      console.error(error.status);
      console.error(error.error);
    }
    return throwError('Something bad happened; please try again later.');
  }
}
