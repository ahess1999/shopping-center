import { Grid } from "@mui/material";
import { useFetchOrders } from "../../Api/Order";
import OrderCard from "./OrderCard";

const Orders = () => {
    const { data } = useFetchOrders({});

    return (
        <Grid container justifyContent="center" alignItems="center" sx={{ mt: 3 }} gap={2}>
            {data?.map(order => (
                <OrderCard order={order} />
            ))}
        </Grid>
    );
};

export default Orders;
