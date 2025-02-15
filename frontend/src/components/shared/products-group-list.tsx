import React, { useEffect, useRef } from "react";
import { ProductCard, Title } from ".";
import { cn } from "@/lib/utils";
import { useIntersection } from "react-use";
import { useCategoryStore } from "@/store/category";
import {  ProductGetDto, ProductWithIngredientsWithPriceDto } from "@/models/productModel";

interface Props {
  title: string;
  items: ProductGetDto[];
  listClassName?: string;
  categoryId: number;
  handleProductClick:(product: ProductGetDto) => void;
  className?: string;
}

export const ProductsGroupList: React.FC<Props> = ({
  title,
  items,
  listClassName,
  categoryId,
  handleProductClick,
  className,
}) => {
    const setActiveCategoryId = useCategoryStore((state) => state.setActiveId);
  const intersectionRef = useRef(null);
  const intersection = useIntersection(intersectionRef, {
    threshold: 0.4,
  });

  useEffect(() => {
    if(intersection?.isIntersecting){
        setActiveCategoryId(categoryId);
        
    }
  },[categoryId, intersection?.isIntersecting, title])

  return (
    <div className={className} id={title} ref={intersectionRef}>
      <Title text={title} size="lg" className="font-extrabold mb-5" />
      <div className={cn("grid grid-cols-3 gap-[50px]", listClassName)}>
        {items.map((product) => (
          <ProductCard
            key={product.productId}
            productId={product.productId}
            name={product.name}
            imageUrl={product.imageUrl}
            price={product.productVariants[0].price}
            ingredients={product.ingredients.map((ingredient) => ingredient.name)}
            onClick={() => handleProductClick(product)}
          />
        ))}
      </div>
    </div>
  );
};
