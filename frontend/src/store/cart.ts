import { CartItemCreateDto, CartItemGetDto } from "@/models/cartItemModel";
import { Api } from "@/services/api-client";
import Cookies from "js-cookie";
import { create } from "zustand";

export interface CartState {
  loading: boolean;
  error: boolean;
  totalAmount: number;
  cartItems: CartItemGetDto[];
  getCartItems: () => Promise<void>;
  updateItemQuantity: (id: number, quantity: number) => Promise<void>;
  addCartItem: (values: CartItemCreateDto) => Promise<void>;
  removeCartItem: (id: number) => Promise<void>;
}

export const useCartStore = create<CartState>((set) => ({
  loading: false,
  error: false,
  totalAmount: 0,
  cartItems: [],

  getCartItems: async () => {
    try {
      set({ loading: true, error: false });

      const tokenCart = Cookies.get("cartToken");

      if (!tokenCart) {
        const response = await Api.carts.createCartForAnonymousUser();
        if (response) {
          Cookies.set("cartToken", response);
        }
      }
      const response = await Api.carts.getCartFullByToken("b98e2dd2-e6f2-4d3c-a5da-69d42dc31dd5");

      if (response) {
        const { cartItems, totalAmount } = response;
        set({ cartItems, totalAmount });
      }
    } catch (error: any) {
      if (error.response) {
        console.error("Error:", error.response.data);
        set({ error: true });
      } else {
        console.error("Unexpected error:", error.message);
        set({ error: true });
      }
    } finally {
      set({ loading: false });
    }
  },

  updateItemQuantity: async (id: number, quantity: number) => {},

  addCartItem: async (values: CartItemCreateDto) => {},

  removeCartItem: async (id: number) => {},
}));
