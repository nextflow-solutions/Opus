import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CookbookService } from '../services/cookbook.service';
import { ToastrService } from 'ngx-toastr';
import { Ingredient } from '../models/Ingredient.model';
import { IRecipe } from '../interfaces/IRecipe';
import { RecipeListComponent } from '../recipe-list/recipe-list.component';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.css']
})
export class RecipeComponent implements OnInit {

  constructor(public service: CookbookService, private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
      this.service.formData =
        {
          Id: 0,
          Title: '',
          Portion: 0,
          Calories: 0,
          PreparationMode: '',
          Ingredients: Array<Ingredient>()
        }
    }
  }

  onSubmit(form: NgForm) {
    if (form.value.EmployeeID == null)
    {
      this.insertRecord(form);
      form.resetForm();
    }
  }

  insertRecord(form: NgForm) {    
    var recipeComponent = new RecipeListComponent(this.service, this.toastr);
    this.service.Save(form.value).subscribe(
      response => recipeComponent.recipeCollection = <IRecipe[]>response.Object,
      error => this.toastr.warning(error, 'Atenção!')
    ); 
  }

  isNumber(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }

}
