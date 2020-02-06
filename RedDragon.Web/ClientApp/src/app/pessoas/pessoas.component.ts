import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Pessoa } from "../util/pessoa.interface";
//Name, Coordinates, Timezone, Location, Dob, Registered, Picture,

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html'
})

@Injectable()
export class PessoaComponent
{
  public pessoas: Pessoa[];
  public todasPessoas: Pessoa[];
  httpDados: HttpClient;
  baseUrlApi: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.baseUrlApi = baseUrl;
    this.httpDados = http;

    http.get<Pessoa[]>(`${baseUrl}ExternalData\\ObterPessoas`).subscribe(result =>
    {
      this.pessoas = result;
      this.todasPessoas = result;
    }, error => console.error(error));

  }
  onChange($event)
  {
    let gender: string = $event.currentTarget.value;

    if (gender === 'todos')
    {
      this.pessoas = this.todasPessoas;
      return;
    }

    let filtro = this.todasPessoas.filter(p => p.gender == gender);

    this.pessoas = filtro;
  }

  filtrarPessoa(value)
  {
    if (value === '')
    {
      this.pessoas = this.todasPessoas;
      return;
    }

    let filtro = this.todasPessoas.filter(p => p.name.first.includes(value));

    this.pessoas = filtro;
  }
}
