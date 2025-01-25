import React from 'react';
import { useParams } from 'react-router';

interface Props {
  className?: string;
}

export const ProductPage: React.FC<Props> = ({ className }) => {
    const{productId} = useParams();
  return (
    <div className={className}>
        <h1>{productId}</h1>
    </div>
  );
};