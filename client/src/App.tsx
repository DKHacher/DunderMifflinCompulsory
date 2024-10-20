import './App.css'
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Home from './pages/Home'
import NavBar from "./components/Navbar.tsx";
import AllCustomers from "./pages/AllCustomers.tsx";
import AllOrders from "./pages/AllOrders.tsx";
import AllPapers from "./pages/AllPapers.tsx";
import AllCustomersOrders from "./pages/AllCustomersOrders.tsx";
import AllCustomersOrders2 from "./pages/AllCustomersOrders2.tsx";
import UpdateOrderStatus from "./pages/updateOrderStatus.tsx";
import AllProperties from "./pages/AllProperties.tsx";
import CreateProperty from "./pages/CreateProperty.tsx";



function App() {

  return (
    <div>
        <BrowserRouter>
            <NavBar/>
            <Routes>
                <Route path="/" element={<Home/>}  />
                <Route path="/Home" element={<Home/>}  />
                <Route path="/AllCustomers" element={<AllCustomers/>}  />
                <Route path="/AllCustomersOrders" element={<AllCustomersOrders/>}  />
                <Route path="/AllCustomersOrders2" element={<AllCustomersOrders2/>}  />
                <Route path="/AllOrders" element={<AllOrders/>}  />
                <Route path="/UpdateOrderStatus" element={<UpdateOrderStatus/>}  />
                <Route path="/AllPapers" element={<AllPapers/>}  />
                <Route path="/AllProperties" element={<AllProperties/>}  />
                <Route path="/CreateProperty" element={<CreateProperty/>}  />
            </Routes>
        </BrowserRouter>
    </div>
  )
}

export default App
