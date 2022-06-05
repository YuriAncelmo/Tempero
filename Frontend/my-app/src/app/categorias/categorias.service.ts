import { CATEGORIAS } from './mock-categoria';
import { Injectable } from '@angular/core';
import { Categoria } from './categoria';
// import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class CategoriasService {
  private categoriasUrl = 'categorias';
  // constructor(private http:HttpClient) { }
  constructor() { }
  getCategorias(): Categoria[] {
    return CATEGORIAS;
  }
}
