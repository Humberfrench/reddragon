import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
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

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, id: number)
  {
    http.get<Aviao>(baseUrl + 'aviao/' + '1').subscribe(result =>
    {
      this.aviao = result;
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
