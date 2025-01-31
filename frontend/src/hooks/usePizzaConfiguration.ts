import { PizzaSize, pizzaSizes, PizzaType, pizzaTypes } from "@/constants/pizza";
import { ProductVariantDto } from "@/models/productModel";
import { useState } from "react";

export const usePizzaConfiguration = (
  initialSize: PizzaSize,
  initialType: PizzaType,
  productVariants: ProductVariantDto[]
) => {
  const [size, setSize] = useState<PizzaSize>(initialSize);
  const [type, setType] = useState<PizzaType>(initialType);

  const availableSizes = pizzaSizes.map((size) => ({
    ...size,
    disabled: !productVariants.some(
      (variant) => 
        Number(variant.size) === Number(size.value) && 
        Number(variant.pizzaType) === Number(type)
    ),
  }));

  const availableTypes = pizzaTypes.map((type) => ({
    ...type,
    disabled: !productVariants.some(
      (variant) => 
        Number(variant.pizzaType) === Number(type.value) && 
        Number(variant.size) === Number(size)
    ),
  }));

  return {
    size,
    type,
    setSize,
    setType,
    availableSizes,
    availableTypes,
  };
}; 