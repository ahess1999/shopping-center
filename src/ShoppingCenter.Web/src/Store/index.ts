import { configureStore } from "@reduxjs/toolkit";
import { combineReducers } from "redux";
import ShoppingCenterApi from "../Api";

const reducers = combineReducers({
    [ShoppingCenterApi.reducerPath]: ShoppingCenterApi.reducer
});

const store = configureStore({
    reducer: reducers,
    middleware: getDefaultMiddleware => getDefaultMiddleware().concat(ShoppingCenterApi.middleware)
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
