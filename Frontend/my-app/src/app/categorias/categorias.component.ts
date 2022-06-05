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

  onSelect(categoria: Categoria): void {
    this.selectedCategoria = categoria;
    this.messageService.add(`CategoriaComponent: categoria selecionada=${categoria.id}`);
  }
  getCategorias(): void {
    this.categoriaService.getCategorias()
      .subscribe(categorias => this.categorias = categorias);
  }
}
