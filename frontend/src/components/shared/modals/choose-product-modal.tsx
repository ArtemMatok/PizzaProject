import { Dialog, DialogContent } from "@/components/ui/dialog";
import { ProductGetDto } from "@/models/productModel";
import React from "react";
import { ChoosePizzaForm, ChooseProductForm } from "..";
import { PizzaSize, PizzaType } from "@/constants/pizza";

interface Props {
  product: ProductGetDto;
  className?: string;
  onClose: () => void;
}

export const ChooseProductModal: React.FC<Props> = ({
  product,
  onClose,
  className,
}) => {
  const isPizzaForm = Boolean(product.productVariants[0].pizzaType);

  return (
    <Dialog open={true} onOpenChange={onClose}>
      <DialogContent className="p-0 max-w-[1060px] bg-white overflow-hidden">
        {isPizzaForm ? (
          <ChoosePizzaForm
            name={product.name}
            imageUrl={product.imageUrl}
            ingredients={product.ingredients}
            productVariants={product.productVariants}
            pizzaSize={product.productVariants[0].size as PizzaSize}
            pizzaType={product.productVariants[0].pizzaType as PizzaType}
            productId={product.productId}
          />
        ) : (
          <ChooseProductForm
            name={product.name}
            imageUrl={product.imageUrl}
            productVariants={product.productVariants}
          />
        )}
      </DialogContent>
    </Dialog>
  );
};
