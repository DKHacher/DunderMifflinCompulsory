import {atom, useAtom} from "jotai";
import {Api} from "../Api.ts";
import {useEffect} from "react";



export const MyApi = new Api({
    baseUrl: "http://localhost:5000",
});
export interface Customer {
    id: number;
    name: string;
    address: string;
    phone: string;
    email: string;
}

export const customerAtom = atom<Customer[]>([]);


function Customers(){
    const [customers, setCustomers] = useAtom(customerAtom);
    useEffect(() => {
        MyApi.api.customerGetCustomers()
            .then((response) => {
                // @ts-ignore
                setCustomers(response.data);
            })
            .catch((error) => {
                console.error("Error fetching customers:", error);
            });
    }, []);

    return (
        <div>
            <h1>All Customers</h1>
            <table>
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Address</th>
                    <th>Phone</th>
                    <th>Email</th>
                </tr>
                </thead>
                <tbody>
                {customers.length > 0 ? (
                    customers.map((customer) => (
                        <tr key={customer.id}>
                            <td>{customer.id}</td>
                            <td>{customer.name}</td>
                            <td>{customer.address}</td>
                            <td>{customer.phone}</td>
                            <td>{customer.email}</td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan={5}>No Customers found</td>
                    </tr>
                )}
                </tbody>
            </table>
        </div>
    )
}

export default Customers
