import { Component, Inject, Injectable } from '@angular/core';
import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
//import { filter, first} from 'rxjs/operators';
//import { User } from "../../model/user.model";

@Component({
  selector: 'app-aviao-edit',
  templateUrl: './aviao-edit.component.html',
  providers: [DatePipe]
})

@Injectable()
export class AviaoEditComponent
{
  public aviao: Aviao;
  editForm: FormGroup;
  httpDados: HttpClient;
  baseUrlApi: string;
  datePipeValue: DatePipe;
  hoje = Date();


  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute,
    http: HttpClient, @Inject('BASE_URL') baseUrl: string, private datePipe: DatePipe)
  {
    this.hoje = Date();
    this.datePipeValue = datePipe;

    this.hoje = this.datePipeValue.transform(this.hoje, "yyyy-MM-dd"); // Format: dd/MM/yyyy OR dd-MM-yyyy OR yyyy-MM-dd

    this.editForm = this.formBuilder.group({
      aviaoId: ['',],
      modelo: ['', Validators.compose([Validators.required])],
      quantidadeDePassageiros: ['', Validators.required],
      dataCriacao: ['',]
    });

    this.aviao = {
      aviaoId: 0,
      modelo: '',
      quantidadeDePassageiros: 0,
      dataCriacao: this.datePipeValue.transform(this.hoje, "yyyy-MM-dd")
    } as Aviao;

    this.editForm.setValue(this.aviao);
    
    //var id = this.route.queryParams.filter(params => params.aviaoId);

    this.route.paramMap.subscribe(params =>
    {
      http.get<Aviao>(baseUrl + 'aviao/Obter/' + params.get('aviaoId')).subscribe(result =>
      {
        if (result !== null)
        {
          this.aviao = result;
          this.editForm.setValue(this.aviao);
        }
      }, error => console.error(error));
    });

    this.httpDados = http;
    this.baseUrlApi = baseUrl;
  }

  onSubmit()
  {
    if (this.editForm.invalid)
    {
      alert('Erros!');
      return;
    }

    if (!isNumeric(this.editForm.controls.quantidadeDePassageiros.value))
    {
      alert('Quantidade de passageiros deve ser numérico');
      return;
    }


    var defaultValue = 0;
    var aviaoId: number = this.editForm.controls.aviaoId.value === '' ? 0 : this.editForm.controls.aviaoId.value.toInt32(defaultValue);
    var modelo = this.editForm.controls.modelo.value
    var quantidadeDePassageiros: number = Number(this.editForm.controls.quantidadeDePassageiros.value);
    var dataCriacao = this.editForm.controls.dataCriacao.value === '' ? this.hoje : this.editForm.controls.dataCriacao.value

    const aviaoEdit = {
      aviaoId: aviaoId,
      modelo: modelo,
      quantidadeDePassageiros: quantidadeDePassageiros,
      dataCriacao: dataCriacao
    } as Aviao;

    this.httpDados.post<Aviao>(this.baseUrlApi + 'aviao/Gravar', aviaoEdit).subscribe(result =>
    {
      this.aviao = result;
    }, error =>
    {
      console.error(error);
      //alert(error);
    }
    );

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


function isNumeric(val: any): boolean
{
  return !(val instanceof Array) && (val - parseFloat(val) + 1) >= 0;
}

interface Aviao
{
  aviaoId: number;
  modelo: string;
  quantidadeDePassageiros: number;
  dataCriacao: string;
}
