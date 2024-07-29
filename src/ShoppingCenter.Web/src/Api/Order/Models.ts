export type OrderResponse = {
    success: boolean;
};

export type OrderRequest = {
    productId: number;
};

export type Order = {
    id: number;
    productId: number;
    isShipped: boolean;
};
