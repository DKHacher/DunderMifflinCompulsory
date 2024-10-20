import {Link} from "react-router-dom";

function NavBar(){
    return (
        <ul>
            <li>
                <Link to="/Home">Home</Link>
            </li>
            <li>
                <Link to="/allCustomers">All Customers</Link>
            </li>
            <li>
                <Link to="/allCustomersOrders">Specific Customers Orders</Link>
            </li>
            <li>
                <Link to="/allOrders">All Orders</Link>
            </li>
            <li>
                <Link to="/UpdateOrderStatus">UpdateOrderStatusTOTEST</Link>
            </li>
            <li>
                <Link to="/allPapers">All Papers</Link>
            </li>
            <li>
                <Link to="/allProperties">All Properties</Link>
            </li>
            <li>
                <Link to="/createProperty">Create Properties</Link>
            </li>
        </ul>
    );
}

export default NavBar;