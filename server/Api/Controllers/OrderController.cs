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
    public ActionResult createOrders()
    {
        /*
         *Missing requirements to create order, starting with basic order
         *will go further into depth on the creation of orders later, for now this is just to test the method
         *and make sure it works correctly
         *next up later is to make it request a frombody to have the values when creating
         */
        List<Order> orders = context.Orders.ToList();
        Order order = new Order();
        order.Customer = new Customer();
        order.Customer.Id = 1;
        order.OrderDate = DateTime.Now;
        order.OrderEntries = new List<OrderEntry>();
        order.Status = "Shipped";
        order.DeliveryDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2));
        order.TotalAmount = 3;
        order.CustomerId = order.Customer.Id;
        orders.Add(order);
        context.Orders.AddRange(orders);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    public ActionResult deleteOrder([FromRoute] int id)
    {
        //seems to not work somehow, maybe its the returning of an empty list?
        //apparently it was the only problem, now it works correctly
        Order orderToDelete = context.Orders.Where(x => x.Id == id).FirstOrDefault();
        context.Orders.Remove(orderToDelete);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpPatch]
    [Route("update/{id:int}")]
    public ActionResult updateOrder([FromRoute] int id)
    {
        /*
         *this is also missing a frombody
         */
        Order order = context.Orders.Find(id);
        order.Status = "Arrived";
        context.Orders.Update(order);
        context.SaveChanges();
        return Ok();
    }
    
}