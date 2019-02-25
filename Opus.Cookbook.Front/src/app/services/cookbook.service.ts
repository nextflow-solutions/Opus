import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Recipe } from '../models/recipe.model';
import { Observable } from 'rxjs';
import { IRecipe } from '../interfaces/IRecipe';
import { IJsonResult } from '../interfaces/IJsonResult';

@Injectable({
  providedIn: 'root'
})

export class CookbookService {

  private _headers: HttpHeaders;
  //private readonly _endPointBase: string = 'http://localhost:1963/api/v1';
  private readonly _endPointBase: string = 'http://www.nextflow.com.br/opus/api/v1'; 
  public formData : Recipe;
  public collection: Recipe[] = []; 

  constructor(private http: HttpClient) {
    this.formData = new Recipe();
    this._headers = new HttpHeaders({'Content-Type': 'application/json', 'Accept': 'application/json'});
  }

  /*
  * Metodo que retorna todos as receitas cadastradas.
  */
  public getAll() : Observable<IJsonResult>  {
    var url = this._endPointBase + "/CookBook/GetAll";
    let result = this.http.get<IJsonResult>(url, {headers: this._headers});
    return result;
  }

  /*
  * Metodo que salva uma recita.
  * @entity : Objeto Receita
  */
  public Save(entity: Recipe) : Observable<IJsonResult> {
    let url = this._endPointBase + "/CookBook/Save";
    let result = this.http.post<IJsonResult>(url, this.formData);
    return result;
  }
  
  /*
  * Metodo que apaga uma recita existente.
  * @id : Codigo da Receita existente a ser apagada.
  */
  public delete(id: number) : Observable<IJsonResult>  {
    let url = this._endPointBase + "/CookBook/Delete";
    let result = this.http.delete<IJsonResult>(url + "?id=" + id, {headers: this._headers});
    return result; 
  }

}
