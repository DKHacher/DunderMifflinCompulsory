import {Api} from "../Api.ts";


export interface Property {
    propertyName?: string;
}


export const MyApi = new Api({
    baseUrl: "http://localhost:5000",
});

function CreateProperty(pname:string) {
    
const property:Property = {
    propertyName:pname
}

MyApi.api.propertyCreateProperties(property);


}

export default CreateProperty