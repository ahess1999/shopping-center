import { BrowserRouter, Route, Routes } from "react-router-dom";
import Header from "../Components/Header";
import Orders from "./Orders";
import Products from "./Products";

const Router = () => {
    return (
        <>
            <BrowserRouter basename="/">
                <Header />
                <Routes>
                    <Route path="/" element={<Products />} />
                    <Route path="/orders" element={<Orders />} />
                </Routes>
            </BrowserRouter>
        </>
    );
};

export default Router;
