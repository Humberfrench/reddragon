import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Aviao } from "../util/aviao.interfaces";

@Component({
  selector: 'app-aviao',
  templateUrl: './aviao.component.html'
})

@Injectable()
export class AviaoComponent
{
  public aviaos: Aviao[];
  httpDados: HttpClient;
  baseUrlApi: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    http.get<Aviao[]>(baseUrl + 'aviao/ObterTodos').subscribe(result =>
    {
      this.aviaos = result;
    }, error => console.error(error));
    this.httpDados = http;
    this.baseUrlApi = baseUrl;
  }

  onDelete(id)
  {
    //alert(id);
    this.httpDados.post(this.baseUrlApi + 'aviao/excluir' + id, null).subscribe(result =>
    {
    }, error => console.error(error));
  }
}
