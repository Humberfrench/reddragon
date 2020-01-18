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
    http.get<Aviao[]>(baseUrl + 'aviao').subscribe(result =>
    {
      this.aviaos = result;
    }, error => console.error(error));
  }

}

interface Aviao
{
  aviaoId: number;
  modelo: string;
  quantidadeDePassageiros: number;
  dateTime: string;
}
