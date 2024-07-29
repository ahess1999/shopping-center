import ShoppingCenterApi from "..";
import { Product } from "./Models";

const productApi = ShoppingCenterApi.injectEndpoints({
    endpoints: builder => ({
        fetchProducts: builder.query<Product[], unknown>({
            query: () => ({
                url: "products",
                method: "GET"
            })
        })
    }),
    overrideExisting: false
});

export const { useQuery: useFetchProducts } = productApi.endpoints.fetchProducts;
