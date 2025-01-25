import { ProductSearchDto } from "@/models/productModel";
import { monolithInstance } from "./instance";
import { ApiProductRoutes } from "./constants";

export const getProductBySearch = async (searchQuery: string) => {
  try {
    const { data } = await monolithInstance.get<ProductSearchDto[]>(
      ApiProductRoutes.SEARCH_PRODUCTS + searchQuery
    );
    return data;
  } catch (error: any) {
    if (error.response) {
      console.error("Error:", error.response.data);
    } else {
      console.error("Unexpected error:", error.message);
    }
    return null;
  }
};
