import { Component, OnInit } from '@angular/core';
import { CookbookService } from '../services/cookbook.service';
import { ToastrService } from 'ngx-toastr';
import { Recipe } from '../models/recipe.model';
import { IRecipe } from '../interfaces/IRecipe';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})

export class RecipeListComponent implements OnInit {

  private static _recipeCollection: IRecipe[]; 
  
  get recipeCollection():IRecipe[] {
    return RecipeListComponent._recipeCollection;
  }

  set recipeCollection(value:IRecipe[]) {
    RecipeListComponent._recipeCollection = value;
  }

  constructor(public service: CookbookService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.getAll().subscribe(
      response => RecipeListComponent._recipeCollection = <IRecipe[]>response.Object,
      error => this.toastr.warning(error, 'Atenção!')
    );   
  }

  /*
  * Evento chamado para popular o form ao clicar em um item da linha do grid
  * @entity: Objeto receita.
  */
  populateForm(entity: Recipe) {
    console.log(entity);
    this.service.formData = Object.assign({}, entity);
  }

  /*
  * Evento chamado ao apagar um registro.
  * @id: Codigo do registro a ser apagar.
  */
  onDelete(id: number) {
    if (confirm('Deseja realmente apagar esta receita?')) {

      this.service.delete(id).subscribe(
        response => RecipeListComponent._recipeCollection = <IRecipe[]>response.Object,
        error => this.toastr.warning(error, 'Atenção!')
      );  

      this.populateForm(new Recipe());
      this.toastr.warning('Receita apagada com sucesso', 'Atenção!');
    }
  }
  

}
