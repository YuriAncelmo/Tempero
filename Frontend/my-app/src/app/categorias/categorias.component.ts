import { Component, OnInit } from '@angular/core';
import { Categoria } from './categoria';
import { CategoriasService } from './categorias.service';
import { MessagesService } from '../messages/messages.service';
@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {
  selectedCategoria?: Categoria;
  categorias: Categoria[] = [];

  constructor(private categoriaService: CategoriasService
    , private messageService: MessagesService) { }

  ngOnInit(): void {
    this.getCategorias();
  }


  getCategorias(): void {
    this.categoriaService.getCategorias()
      .subscribe(categorias => {
        this.messageService.add("Objeto" + categorias);
        this.categorias = categorias;
      });
  }
  add(nome: string): void {
    nome = nome.trim();
    if (!nome) { return; }
    this.categoriaService.addCategoria({ nome } as Categoria)
      .subscribe(categoria => {
        this.categorias.push(categoria);
      });
  }
  delete(categoria: Categoria): void {
    this.categorias = this.categorias.filter(h => h !== categoria);
    this.categoriaService.deleteCategoria(categoria.id).subscribe();
  }
}
