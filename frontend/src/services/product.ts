import { ProductBasicDto, ProductGetDto} from "@/models/productModel";
import { monolithInstance } from "./instance";
import { ApiProductRoutes } from "./constants";
import { ResponseError } from "@/models/response";

export const getProductBySearch = async (searchQuery: string) => {
  try {
    const { data } = await monolithInstance.get<ProductBasicDto[]>(
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

export const getProductById = async (id: number): Promise<ProductGetDto | ResponseError > => {
  try {
    const { data } = await monolithInstance.get<ProductGetDto>(
      ApiProductRoutes.GET_PRODUCT_BY_ID + id
    );
    return data;
  } catch (error: any) {
    if (error.response) {
      return { error: true, data: error.response.data, message: error.response.data?.errorMessage };
    }
    return { error: true, message: error.message };
  }
};