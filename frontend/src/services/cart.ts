import { CartGetDto } from "@/models/cartModel";
import { monolithInstance } from "./instance";
import { ApiCartRoutes } from "./constants";

export const getCartFullByToken = async (tokenCart: string) => {
  try {
    const { data } = await monolithInstance.get<CartGetDto>(
      ApiCartRoutes.GET_CART_FULL_BY_TOKEN + tokenCart
    );
    return data;
  } catch (error: any) {
    if (error.response) {
      console.error("Error:", error.response.data);
    } else {
      console.error("Unexpected error:", error.message);
    }
  }
};

export const createCartForAnonymousUser = async () => {
  try {
    const { data } = await monolithInstance.post<string>(
      ApiCartRoutes.CREATE_CART_ANONYMOUS_USER
    );
    return data;
  } catch (error: any) {
    if (error.response) {
      console.error("Error:", error.response.data);
    } else {
      console.error("Unexpected error:", error.message);
    }
  }
};
