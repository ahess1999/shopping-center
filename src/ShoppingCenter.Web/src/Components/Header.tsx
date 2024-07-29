import { AppBar, Button, Toolbar } from "@mui/material";
import { useNavigate } from "react-router-dom";

const Header = () => {
    const navigate = useNavigate();

    return (
        <AppBar position="static" color="success">
            <Toolbar>
                <Button sx={{ color: "white" }} onClick={() => navigate("/")}>
                    Store
                </Button>
                <Button sx={{ color: "white" }} onClick={() => navigate("/orders")}>
                    Orders
                </Button>
            </Toolbar>
        </AppBar>
    );
};

export default Header;
