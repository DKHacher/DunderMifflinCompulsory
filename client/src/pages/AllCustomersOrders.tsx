import {Link} from "react-router-dom";

function AllCustomersOrders (){
    return (
        <div>
            <input type="text" id="myInput"></input>
            <button onClick={test}>Reload</button>
            <Link to="/allCustomersOrders2">View Orders</Link>
        </div>
    )
}

export default AllCustomersOrders

function test(){
    if (document.getElementById("myInput") != null){
        localStorage.clear()
        // @ts-ignore
        localStorage.setItem('idData', document.getElementById("myInput").value);
    }
}