import { ProductGetDto } from "@/models/productModel";
import { Api } from "@/services/api-client";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import { toast } from "react-toastify";
import { FaPizzaSlice } from "react-icons/fa";
import {
  Container,
  PizzaImage,
  ProductSelector,
  Title,
} from "@/components/shared";

interface Props {
  className?: string;
}

export const ProductPage: React.FC<Props> = ({ className }) => {
  const { productId } = useParams();
  const [product, setProduct] = useState<ProductGetDto>();

  useEffect(() => {
    const getProductById = async () => {
      const response = await Api.products.getProductById(Number(productId));

      if ("error" in response && response.error) {
        toast.error(response.message || "Something went wrong...", {
          toastId: "unique-toast-id",
          icon: <FaPizzaSlice />,
          progressClassName: "custom-progress-bar",
        });
      } else {
        setProduct(response as ProductGetDto);
      }
    };

    getProductById();
  }, []);

  return (
    <>
      <Container className="flex flex-col my-10">
        <div className="flex flex-1">
          <PizzaImage imageUrl={product?.imageUrl} size={50} />

          <div className="w-[490px] bg-[#f7f6f5]">
            <Title
              text={product?.name!}
              size="md"
              className="font-extrabold mb-1"
            />

            <p className="text-gray-400">
              Lorem, ipsum dolor sit amet consectetur adipisicing elit. Ut
              quidem saepe ad quia natus laudantium laboriosam facilis eligendi
              dicta deleniti. Vero similique ex sed illum veritatis laborum.
              Aut, cum eos!
            </p>

            <ProductSelector selectedValue="2" items={[
              {
                name:"Small",
                value:"1",
              },
              {
                name:"Medium",
                value:"2",
              },
              {
                name:"Big",
                value:"3",
              },
            ]} />
          </div>
        </div>
      </Container>
    </>
  );
};
