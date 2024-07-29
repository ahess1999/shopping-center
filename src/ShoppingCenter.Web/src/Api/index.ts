import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const ordersTag = "orders";

const ShoppingCenterApi = createApi({
    reducerPath: "shoppingCenterApi",
    baseQuery: fetchBaseQuery({
        baseUrl: "http://localhost:8080/api/"
    }),
    endpoints: () => ({}),
    tagTypes: [ordersTag]
});

export default ShoppingCenterApi;
