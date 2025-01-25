import App from "@/App";
import { Home } from "@/pages/home";
import { ProductPage } from "@/pages/productPage";
import { createBrowserRouter } from "react-router";

export const router = createBrowserRouter([
    {
        path:"/",
        element:<App />,
        children:[
            {path:"",element:<Home />},
            {path:"product/:productId", element:<ProductPage />}
        ]
    }
])