import { Grid } from "@mui/material";
import { useFetchProducts } from "../../Api/Product";
import ProductCard from "./ProductCard";

const Products = () => {
    const { data } = useFetchProducts({});

    return (
        <Grid container justifyContent="center" alignItems="center" sx={{ mt: 3 }} gap={2}>
            {data?.map(product => (
                <ProductCard product={product} />
            ))}
        </Grid>
    );
};

export default Products;
