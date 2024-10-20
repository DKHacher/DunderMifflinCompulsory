import { atom, useAtom } from "jotai";
import {useEffect} from "react";
import {Api} from "../Api.ts";

export const MyApi = new Api({
    baseUrl: "http://localhost:5000",
});

export interface Order {
    id: number;
    CustomerId: number;
    status: string;
    DeliveryDate: number;
    OrderDate: number;
    TotalAmount: number;
}

export const orderAtom = atom<Order[]>([]);

function Orders(){
    const [orders, setOrders] = useAtom(orderAtom);

    useEffect(() => {
        MyApi.api.orderGetOrders()
            .then((response) => {
                // @ts-ignore
                setOrders(response.data);
            })
            .catch((error) => {
                console.error("Error fetching orders:", error);
            });
    }, []);
    
    return (
        <div>
            <h1>All Orders</h1>
            <table>
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Customer Id</th>
                    <th>Status</th>
                    <th>Delivery Date</th>
                    <th>Order Date</th>
                    <th>Total Amount</th>
                </tr>
                </thead>
                <tbody>
                {orders.length > 0 ? (
                    orders.map((order) => (
                        <tr key={order.id}>
                            <td>{order.id}</td>
                            <td>{order.CustomerId}</td>
                            <td>{order.status}</td>
                            <td>{order.TotalAmount}</td>
                            <td>{order.OrderDate}</td>
                            <td>{order.DeliveryDate}</td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan={5}>No Orders found</td>
                    </tr>
                )}
                </tbody>
            </table>
        </div>
    )
}

export default Orders