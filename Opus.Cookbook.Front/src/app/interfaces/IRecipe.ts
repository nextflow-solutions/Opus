import { Ingredient } from '../models/ingredient.model';

export interface IRecipe {
    Id: number;
    Title: string;
    Portion: number;
    Calories: number;
    PreparationMode: string;
    Ingredients: Array<Ingredient>
}