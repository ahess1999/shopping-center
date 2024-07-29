import { Button, Card, CardActions, CardContent, Grid, Typography } from "@mui/material";
import { useState } from "react";
import { useOrderProduct } from "../../Api/Order";
import { Product } from "../../Api/Product/Models";

interface Props {
    product: Product;
}

const ProductCard = ({ product }: Props) => {
    const [orderProduct] = useOrderProduct();
    const [isOrdering, setIsOrdering] = useState<boolean>(false);

    const handleOrder = async () => {
        setIsOrdering(true);

        await orderProduct({ productId: product.id }).unwrap();

        setIsOrdering(false);
    };

    return (
        <Grid item key={product.id}>
            <Card sx={{ maxWidth: 275 }} elevation={3}>
                <CardContent>
                    <Typography variant="h5" component="div">
                        {product.name} ${product.price}
                    </Typography>
                    <Typography>{product.description}</Typography>
                </CardContent>
                <CardActions sx={{ float: "right" }}>
                    <Button onClick={handleOrder} variant="outlined" size="small" color="success">
                        {isOrdering ? "Ordering..." : "Order"}
                    </Button>
                </CardActions>
            </Card>
        </Grid>
    );
};

export default ProductCard;
