import { CartItemCreateDto } from "@/models/cartItemModel";
import { monolithInstance } from "./instance";
import { ApiCartItemRoutes} from "./constants";

export const createCartItem = async (cartItemCreateDto:CartItemCreateDto) => {
    try {
      const { data } = await monolithInstance.post<number>(ApiCartItemRoutes.CREATE_CART_ITEM, cartItemCreateDto);
      return data;
    } catch (error: any) {
      if (error.response) {
        console.error("Error:", error.response.data);
      } else {
        console.error("Unexpected error:", error.message);
      }
    }
  };