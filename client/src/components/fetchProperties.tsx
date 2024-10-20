import { atom, useAtom } from "jotai";
import {useEffect} from "react";
import {Api} from "../Api.ts";

export const MyApi = new Api({
    baseUrl: "http://localhost:5000",
});

export interface Property {
    id: number;
    propertyName: string;
}

export const propertyAtom = atom<Property[]>([]);

function Properties(){
    const [properties, setProperties] = useAtom(propertyAtom);

    useEffect(() => {
        MyApi.api.propertyGetProperties()
            .then((response) => {
                // @ts-ignore
                setProperties(response.data);
            })
            .catch((error) => {
                console.error("Error fetching properties:", error);
            });
    }, []);

    return (
        <div>
            <h1>All Properties</h1>
            <table>
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Property Name</th>
                </tr>
                </thead>
                <tbody>
                {properties.length > 0 ? (
                    properties.map((property) => (
                        <tr key={property.id}>
                            <td>{property.id}</td>
                            <td>{property.propertyName}</td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan={5}>No Properties found</td>
                    </tr>
                )}
                </tbody>
            </table>
        </div>
    )
}

export default Properties