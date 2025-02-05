import { IngredientGetDto } from "./ingredientModel";
import { ProductVariantGetDto } from "./productVariantModel";

export interface CartItemGetDto{
    cartItemId: number,
    tokenCart: string,
    quantity: number,
    productVariantId: number,
    productVariant: ProductVariantGetDto,
    ingredients:IngredientGetDto[]
}

export interface CartItemCreateDto{
    quantity:number;
    productVariantId:number;
    tokenCart:string;
    ingredientsId:number[];
}