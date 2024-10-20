import {Api} from "../Api.ts";
import {useEffect} from "react";

export const MyApi = new Api({
    baseUrl: "http://localhost:5000",
});

function UpdateOrderStatusComp(orderId:number, status: number) {
    
    useEffect(() => {
        MyApi.api.orderUpdateOrderStatus(orderId, status);
    }, []);
}

export default UpdateOrderStatusComp