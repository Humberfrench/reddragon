import { Component } from "@angular/core";

@Component({
  selector: 'app-contador-component',
  templateUrl: './contador.component.html'
})


export class ContadorComponent
{
  public contagem: number = 0;
  constructor()
  {

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

}
