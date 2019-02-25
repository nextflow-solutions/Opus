import { Ingredient } from './ingredient.model';

export class Recipe {
    Id: number;
    Title: string;
    Portion: number;
    Calories: number;
    PreparationMode: string;
    Ingredients: Array<Ingredient>;
}