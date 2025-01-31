export interface IngredientBasicDto{
    ingredientId:number,
    name:string
}

export interface IngredientGetDto{
    ingredientId:number;
    name:string;
    imageUrl:string;
    price:number;
}