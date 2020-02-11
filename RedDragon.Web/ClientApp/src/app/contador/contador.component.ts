import { Component } from "@angular/core";
import { FormControl } from "@angular/forms";
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

@Component({
  selector: 'app-contador-component',
  templateUrl: './contador.component.html'
})

export class ContadorComponent
{
  contagem: number = 0;
  opcao: string;
  options: string[] = ['One', 'Two', 'Three'];
  filteredOptions: Observable<string[]>;
  myControl = new FormControl();

  constructor()
  {
    this.opcao = "";
  }

  ngOnInit()
  {
    this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
      );
  }

  private _filter(value: string): string[]
  {
    const filterValue = value.toLowerCase();

    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  }

  public soma1()
  {
    if (this.contagem > 1000)
    {
      this.contagem = 1
      return;
    }
    this.contagem++;
    //this.MatSliderId = this.contagem;

  }
  public soma10()
  {
    if (this.contagem > 1000)
    {
      this.contagem = 1
      return;
    }
    this.contagem += 10;
  }
  public somaExterna()
  {
    //contagemExterna += 10;
  }

  public selecionado()
  {
    if (this.opcao == "")
    {
      alert("Sem esolha feita");
      return
    }
    alert(this.opcao);
  }

}
