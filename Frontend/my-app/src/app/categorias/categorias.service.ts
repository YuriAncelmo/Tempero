import { MessagesService } from './../messages/messages.service';
import { CATEGORIAS } from './mock-categoria';
import { Injectable } from '@angular/core';
import { Categoria } from './categoria';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {
  private categoriasUrl = 'https://localhost:44303/api/categorias';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private messageService: MessagesService, private http: HttpClient) { }

  getCategorias(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.categoriasUrl)
      .pipe(
        tap(_ => this.log('fetched categorias' + _)),
        catchError(this.handleError<Categoria[]>('getCategorias', []))
      );

  }

  getCategoriaById(id: number): Observable<Categoria> {
    const url = `${this.categoriasUrl}/id/${id}`;
    return this.http.get<Categoria>(url)
      .pipe(
        tap(_ => this.log(`fetched categoria id=${id}`)),
        catchError(this.handleError<Categoria>('getCategorias'))
      );
  }
  updateCategoria(categoria: Categoria): Observable<any> {

    return this.http.patch<Categoria>(this.categoriasUrl, categoria, this.httpOptions)
      .pipe(
        tap(_ => this.log(`categoria alterada ${categoria.nome}`)),
        catchError(this.handleError<any>('updateCategoria'))
      );
  }
  /** POST: add a new categoria to the server */
  addCategoria(categoria: Categoria): Observable<Categoria> {
    return this.http.post<Categoria>(this.categoriasUrl, categoria, this.httpOptions).pipe(
      tap((newCategoria: Categoria) => this.log(` categoria adicionada w/ id=${categoria.id}`)),
      catchError(this.handleError<Categoria>('addCategoria'))
    );
  }
  /** DELETE: delete the categoria from the server */
  deleteCategoria(id: number): Observable<Categoria> {
    const url = `${this.categoriasUrl}/${id}`;

    return this.http.delete<Categoria>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted categoria id=${id}`)),
      catchError(this.handleError<Categoria>('deleteCategoria'))
    );
  }
  private log(message: string) {
    this.messageService.add(`CategoriaService: ${message}`);
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 *
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
