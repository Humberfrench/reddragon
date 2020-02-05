import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Pessoa } from "../util/pessoa.interface";
//Name, Coordinates, Timezone, Location, Dob, Registered, Picture,

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html'
})

@Injectable()
export class PessoaComponent
{
  public pessoas: Pessoa[];
  //httpDados: HttpClient;
  urlApi = "https://storage.googleapis.com/juntossomosmais-code-challenge/input-frontend-apps.json";

  constructor(http: HttpClient)
  {

    const httpOptions = {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin': '*',
      })
    };
    http.get<Pessoa[]>(this.urlApi, httpOptions,).subscribe(result =>
    {
      this.pessoas = result;
    }, error => console.error(error));
    //this.httpDados = http;
  }

}
