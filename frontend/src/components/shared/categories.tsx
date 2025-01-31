import { cn } from "@/lib/utils";
import { CategoryGetDto } from "@/models/categoryModel";
import { Api } from "@/services/api-client";
import { useCategoryStore } from "@/store/category";
import React, { useEffect, useState } from "react";

interface Props {
  className?: string;
}

export const Categories: React.FC<Props> = ({ className }) => {
  const categoryActiveId = useCategoryStore((state) => state.activeId);

  const[categories, setCategories] = useState<CategoryGetDto[]>([]);

  useEffect(() => {
    const getCategories = async () => {
      const data = await Api.categories.getCategories();
      if(data){
        setCategories(data);
      }
    }

    getCategories();
  },[])
  return (
    <div
      className={cn("inline-flex gap-1 bg-grey-50 p-1 rounded-2xl", className)}
    >
      {categories.map((cat, index) => (
        <a
          className={cn(
            "flex items-center font-bold h-11 rounded-2xl px-5",
            categoryActiveId ===cat.categoryId &&
              "bg-white shadow-md shadow-gray-200 text-primary"
          )}
          href={`/#${cat.name}`}
          key={index}
        >
          <button>{cat.name}</button>
        </a>
      ))}
    </div>
  );
};
