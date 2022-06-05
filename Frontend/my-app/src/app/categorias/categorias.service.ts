import { MessagesService } from './../messages/messages.service';
import { CATEGORIAS } from './mock-categoria';
import { Injectable } from '@angular/core';
import { Categoria } from './categoria';
import { Observable, of } from 'rxjs';
// import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class CategoriasService {
  private categoriasUrl = 'categorias';
  // constructor(private http:HttpClient) { }
  constructor(private messageService: MessagesService) { }
  getCategorias(): Observable<Categoria[]> {
    const categorias = of(CATEGORIAS);
    this.messageService.add('CategoriaService: fetched categorias ');
    return categorias;
  }
}
