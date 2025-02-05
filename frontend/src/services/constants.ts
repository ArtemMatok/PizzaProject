export enum ApiProductRoutes{
    SEARCH_PRODUCTS = 'Products?searchQuery=',
    GET_PRODUCT_BY_ID = "Products/"
}

export enum ApiIngredientsRoutes{
    GET_INGREDIENTS_BASIC="ingredients/ingredients-basic"
}

export enum ApiCategoriesRoutes{
    GET_CATEGORIES_WITH_PRODUCTS = "categories/categories-with-products",
    GET_CATEGORIES = "categories",
}

export enum ApiCartRoutes{
    GET_CART_FULL_BY_TOKEN = "carts/cart-full-by-token/",
    CREATE_CART_ANONYMOUS_USER = "carts/create-cart-anonymous-user"
}


export enum ApiCartItemRoutes{
    CREATE_CART_ITEM = "cart-items"
}
