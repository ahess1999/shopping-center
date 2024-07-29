import ShoppingCenterApi, { ordersTag } from "..";
import { Order, OrderRequest, OrderResponse } from "./Models";

const orderApi = ShoppingCenterApi.injectEndpoints({
    endpoints: builder => ({
        fetchOrders: builder.query<Order[], unknown>({
            query: () => ({
                url: "orders",
                method: "GET"
            }),
            providesTags: [ordersTag]
        }),
        orderProduct: builder.mutation<OrderResponse, OrderRequest>({
            query: request => ({
                url: "order",
                method: "POST",
                body: {
                    productId: request.productId
                }
            }),
            invalidatesTags: [ordersTag]
        })
    }),
    overrideExisting: false
});

export const { useQuery: useFetchOrders } = orderApi.endpoints.fetchOrders;
export const { useMutation: useOrderProduct } = orderApi.endpoints.orderProduct;
