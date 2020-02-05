import { Injectable, Component, Inject } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Aviao } from "../util/aviao.interfaces";
import { DatePipe } from "@angular/common";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-aviao-busca',
  templateUrl: './aviao-busca.component.html',
  providers: [DatePipe]
})

@Injectable()
export class AviaoBuscaComponent
{
  aviao: Aviao;
  editForm: FormGroup;
  datePipeValue: DatePipe;
  hoje = Date();
  public aviaos: Aviao[];
  httpDados: HttpClient;
  baseUrlApi: string;

  constructor(private formBuilder: FormBuilder, http: HttpClient,
    @Inject('BASE_URL') baseUrl: string, private datePipe: DatePipe)
  {
    this.hoje = Date();
    this.datePipeValue = datePipe;
    this.hoje = this.datePipeValue.transform(this.hoje, "yyyy-MM-dd"); // Format: dd/MM/yyyy OR dd-MM-yyyy OR yyyy-MM-dd

    http.get<Aviao[]>(baseUrl + 'aviao/ObterTodos').subscribe(result =>
    {
      this.aviaos = result;
    }, error => console.error(error));
    this.httpDados = http;
    this.baseUrlApi = baseUrl;

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
  }

  onChange($event)
  {
    var id = $event.currentTarget.value;

    this.httpDados.get<Aviao>(`${this.baseUrlApi}aviao/Obter/${id}`).subscribe(result =>
      {
        if (result !== null)
        {
          this.aviao = result;
          this.editForm.setValue(this.aviao);
        }
      }, error => console.error(error));

  }
}
