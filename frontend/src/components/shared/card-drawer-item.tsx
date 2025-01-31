import { cn } from "@/lib/utils";
import React from "react";
import { CartItemDetailsImage } from "./cart-items-details/cart-item-details-image";
import { CartItemProps } from "./cart-items-details/cart-item-details.types";
import { CartItemInfo } from "./cart-items-details/cart-item-info";
import { CountButton } from ".";
import { CartItemDetailsPrice } from "./cart-items-details/cart-item-details-price";
import { Trash2Icon } from "lucide-react";

interface Props extends CartItemProps {
  className?: string;
}

export const CardDrawerItem: React.FC<Props> = ({
  className,
  cartItemId,
  imageUrl,
  details,
  name,
  price,
  quantity,
  disabled,
}) => {
  return (
    <div className={cn("flex bg-white p-5 gap-6", className)}>
      <CartItemDetailsImage src={imageUrl} />

      <div className="flex-1">
        <CartItemInfo name={name} details={details} />

        <hr className="my-3"></hr>

        <div className="flex items-center justify-between">
          <CountButton value={quantity} onClick={(type) => console.log(type)} />

          <div className="flex items-center gap-3">
            <CartItemDetailsPrice value={price} />
            <Trash2Icon
              className="text-gray-400 cursor-pointer hover:text-gray-600"
              size={16}
            />
          </div>
        </div>
      </div>
    </div>
  );
};
