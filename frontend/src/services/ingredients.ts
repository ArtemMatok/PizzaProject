import { IngredientBasicDto } from "@/models/ingredientModel";
import { monolithInstance } from "./instance";
import { ApiIngredientsRoutes } from "./constants";

export const getIngredientsBasic = async () => {
  try {
    const { data } = await monolithInstance.get<IngredientBasicDto[]>(ApiIngredientsRoutes.GET_INGREDIENTS_BASIC);
    return data;
  } catch (error: any) {
    if (error.response) {
      console.error("Error:", error.response.data);
    } else {
      console.error("Unexpected error:", error.message);
    }
  }
};