import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-aviao',
  templateUrl: './aviao.component.html'
})

@Injectable()
 export class AviaoComponent
{
  public aviaos: Aviao[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    http.get<Aviao[]>(baseUrl + 'aviao/ObterTodos').subscribe(result =>
    {
      this.aviaos = result;
    }, error => console.error(error));
  }

  public delete(id)
  {
    alert(id);
  }
}

interface Aviao
{
  aviaoId: number;
  modelo: string;
  quantidadeDePassageiros: number;
  dateTime: string;
}
