import { IngredientGetDto } from "./ingredientModel";

export interface ProductBasicDto {
    productId:number,
    name:string,
    imageUrl:string
}

export interface ProductVariantDto{
    productVariantId:number;
    price:number;
    size?:number;
    pizzaType?:number
}

export interface ProductGetDto{
    productId:number;
    name:string;
    imageUrl:string;
    ingredients:IngredientGetDto[];
    productVariants:ProductVariantDto[]
}

export interface ProductWithIngredientsWithPriceDto{
    productId:number;
    name:string;
    imageUrl:string;
    price:number;
    ingredients:string[];
}