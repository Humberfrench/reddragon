import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { first } from "rxjs/operators";
//import { User } from "../../model/user.model";

@Component({
  selector: 'app-aviao-edit',
  templateUrl: './aviao-edit.component.html'
})

@Injectable()
export class AviaoEditComponent
{
  public aviao: Aviao;
  editForm: FormGroup;
  httpDados: HttpClient;
  baseUrlApi: string;

  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute,
    http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {

    this.route.paramMap.subscribe(params =>
    {
      http.get<Aviao>(baseUrl + 'aviao/Obter/' + params.get('aviaoId')).subscribe(result =>
      {
        this.aviao = result;
        this.editForm.setValue(this.aviao);
      }, error => console.error(error));
    });

    this.httpDados = http;
    this.baseUrlApi = baseUrl;
  }

  onSubmit()
  {
    if (this.editForm.invalid)
    {
      return;
    }

    const aviaoEdit = {
      aviaoId: this.editForm.controls.id.value,
      modelo: this.editForm.controls.modelo.value,
      quantidadeDePassageiros: this.editForm.controls.quantidadeDePassageiros.value,
      dataCriacao: this.editForm.controls.dataCriacao.value
    } as Aviao;

    this.httpDados.post<Aviao>(this.baseUrlApi + 'aviao/Gravar', aviaoEdit).subscribe(result =>
    {
      this.aviao = result;
    }, error => console.error(error));

  }

  ngOnInit()
  {

    this.editForm = this.formBuilder.group({
      aviaoId: ['',],
      modelo: ['', Validators.compose([Validators.required])],
      quantidadeDePassageiros: ['', Validators.required],
      dataCriacao: ['',]
    });

  }

}

interface Aviao
{
  aviaoId: number;
  modelo: string;
  quantidadeDePassageiros: number;
  dataCriacao: string;
}
