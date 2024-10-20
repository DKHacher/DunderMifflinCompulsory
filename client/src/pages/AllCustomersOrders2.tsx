import fetchSpecificCustomersOrder from "../components/fetchSpecificCustomersOrder.tsx";

function AllCustomersOrders2 (){
    return (
        fetchSpecificCustomersOrder(Number(localStorage.getItem("idData")))
    )
}

export default AllCustomersOrders2


