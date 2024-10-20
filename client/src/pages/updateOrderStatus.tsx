import UpdateOrderStatusComp from "../components/UpdateOrderStatusComp.tsx";
function updateOrderStatus () {
    return (
        <div>
            <div>
                OrderId
                <input type="text" id="orderId"></input>
            </div>
            <div>
                NewStatus
                <input type="text" id="status"></input>
            </div>
            <button onClick={test}>Reload</button>
        </div>
    )
}

export default updateOrderStatus

function test() {
    if (document.getElementById("status") != null && document.getElementById("orderId") != null) {
        // @ts-ignore
        UpdateOrderStatusComp(document.getElementById("orderId").value,document.getElementById("status").value)
    }
}