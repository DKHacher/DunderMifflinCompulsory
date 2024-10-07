using System.Runtime.InteropServices.JavaScript;
using dataaccess;
using dataaccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
public class OrderController(DmContext context) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public ActionResult getOrders()
    {
        return Ok(context.Orders.ToList());
    }
    
    [HttpPost]
    [Route("create")]
    public ActionResult createOrders([FromBody] Order order)
    {
        context.Orders.Add(order);
        context.SaveChanges();
        return Ok();
    }

    [HttpPatch]
    [Route("updateStatus/{orderId:int}")]
    public ActionResult updateOrderStatus([FromRoute] int orderId,[FromBody] int orderstatus)
    {
        Order order = context.Orders.Find(orderId);
        switch (orderstatus)
        {
         case 1:
             order.Status = "AwaitingPayment";
             break;
         case 2:
             order.Status = "Processing";
             break;
         case 3:
             order.Status = "Shipped";
             break;
         case 4:
             order.Status = "Delivered";
             break;
         case 5:
             order.Status = "Completed";
             break;
         case 6:
             if (orderstatus == 1)
             {
                 order.Status = "Cancelled";
             }
             break;
        }
        context.SaveChanges();
        return Ok("Order Has Been" + order.Status);
    }
    
    
}