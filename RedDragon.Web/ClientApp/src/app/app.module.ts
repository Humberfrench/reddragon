import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DatePipe } from '@angular/common';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AviaoComponent } from './aviao/aviao.component';
import { AviaoEditComponent } from './aviao/aviao-edit.component';
import { AviaoBuscaComponent } from './aviao/aviao-busca.component';
import { PessoaComponent } from './pessoas/pessoas.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AviaoComponent,
    AviaoEditComponent,
    AviaoBuscaComponent,
    PessoaComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'aviao', component: AviaoComponent },
      { path: 'aviao-edit/:aviaoId', component: AviaoEditComponent },
      { path: 'aviao-busca', component: AviaoBuscaComponent },
      { path: 'pessoas', component: PessoaComponent },
    ])
  ],
  exports: [
    DatePipe,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
