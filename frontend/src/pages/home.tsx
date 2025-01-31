import {
  ChooseProductModal,
  Container,
  Filters,
  ProductsGroupList,
  Title,
  TopBar,
} from "@/components/shared";
import { CategoryWithProductsDto } from "@/models/categoryModel";
import {
  ProductGetDto,
} from "@/models/productModel";
import { Api } from "@/services/api-client";
import React, { useEffect, useState } from "react";
import { Helmet } from "react-helmet-async";

interface Props {
  className?: string;
}

export const Home: React.FC<Props> = ({ className }) => {
  const [categories, setCategories] = useState<CategoryWithProductsDto[]>([]);
  const [selectedProduct, setSelectedProduct] =
    useState<ProductGetDto | null>();
  const [isModalOpen, setIsModalOpen] = useState(false);

  const openModal = (product: ProductGetDto) => {
    console.log(product);
    setSelectedProduct(product);
    setIsModalOpen(true);
  };

  const closeModal = () => {
    setSelectedProduct(null);
    setIsModalOpen(false);
  };

  useEffect(() => {
    const getCategoriesWithProducts = async () => {
      var data = await Api.categories.getCategoriesWithProducts();
      console.log(data);
      if (data) {
        setCategories(data);
      }
    };

    getCategoriesWithProducts();
  }, []);

  useEffect(() => {}, [categories]);

  return (
    <>
      <Helmet>
        <title>Pizzonix | Main</title>
      </Helmet>
      <Container className="mt-10">
        <Title text={"All pizzas"} size="lg" className="font-extrabold" />
      </Container>
      <TopBar />

      <Container className="mt-10 pb-14">
        <div className="flex gap-[60px]">
          {/* Filtration */}
          <div className="w-[250px]">
            <Filters />
          </div>

          {/* List of products */}
          <div className="flex-1">
            <div className="flex flex-col gap-16">
              {categories.map(
                (category) =>
                  category.products.length > 0 && (
                    <ProductsGroupList
                      key={category.categoryId}
                      title={category.name}
                      categoryId={category.categoryId}
                      items={category.products}
                      handleProductClick={openModal}
                    />
                  )
              )}
            </div>
          </div>
        </div>

        {isModalOpen && selectedProduct && (
          <ChooseProductModal
            product={selectedProduct}
            className="your-class-name"
            onClose={closeModal}
          />
        )}
      </Container>
    </>
  );
};
