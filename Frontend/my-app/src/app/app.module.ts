import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CategoriasComponent } from './categorias/categorias.component';
import { DetalheCategoriaComponent } from './categorias/detalhe-categoria/detalhe-categoria.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MessagesComponent } from './messages/messages.component';
import { DashboardCategoriaComponent } from './categorias/dashboard-categoria/dashboard-categoria.component';
@NgModule({
  declarations: [
    AppComponent,
    CategoriasComponent,
    DetalheCategoriaComponent,
    MessagesComponent,
    DashboardCategoriaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
