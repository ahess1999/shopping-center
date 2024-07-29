import { Card, CardActions, CardContent, Grid, Typography } from "@mui/material";
import { Order } from "../../Api/Order/Models";

interface Props {
    order: Order;
}

const OrderCard = ({ order }: Props) => {
    return (
        <Grid item key={order.id}>
            <Card sx={{ width: 275 }} elevation={3}>
                <CardContent>
                    <Typography variant="h5" component="div">
                        Order #{order.id}
                    </Typography>
                </CardContent>
                <CardActions sx={{ float: "right" }}>
                    <Typography>{order.isShipped ? "Shipped" : "Not Shipped"}</Typography>
                </CardActions>
            </Card>
        </Grid>
    );
};

export default OrderCard;
