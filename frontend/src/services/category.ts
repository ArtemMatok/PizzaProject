import { CategoryGetDto, CategoryWithProductsDto } from "@/models/categoryModel";
import { monolithInstance } from "./instance";
import { ApiCategoriesRoutes } from "./constants";

export const getCategoriesWithProducts = async () => {
  try {
    const { data } = await monolithInstance.get<CategoryWithProductsDto[]>(ApiCategoriesRoutes.GET_CATEGORIES_WITH_PRODUCTS);
    return data;
  } catch (error: any) {
    if (error.response) {
      console.error("Error:", error.response.data);
    } else {
      console.error("Unexpected error:", error.message);
    }
  }
};

export const getCategories = async () => {
  try {
    const { data } = await monolithInstance.get<CategoryGetDto[]>(ApiCategoriesRoutes.GET_CATEGORIES);
    return data;
  } catch (error: any) {
    if (error.response) {
      console.error("Error:", error.response.data);
    } else {
      console.error("Unexpected error:", error.message);
    }
  }
}