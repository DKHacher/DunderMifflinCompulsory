using dataaccess;
using dataaccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
public class OrderEntryController(DmContext context) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public ActionResult getOrderEntrys()
    {
        return Ok(context.OrderEntries.ToList());
    }
    
    [HttpPost]
    [Route("create")]
    public ActionResult createOrderEntrys()
    {
        /*
         *Missing requirements to create orderEntry, starting with basic orderEntry
         *will go further into depth on the creation of orderEntrys later, for now this is just to test the method
         *and make sure it works correctly
         *next up later is to make it request a frombody to have the values when creating
         */
        List<OrderEntry> orderEntries = context.OrderEntries.ToList();
        OrderEntry orderEntry = new OrderEntry();
        orderEntry.Order = new Order();
        orderEntry.Order.Id = 1;
        orderEntry.OrderId = orderEntry.Order.Id;
        orderEntry.Product = new Paper();
        orderEntry.Product.Id = 1;
        orderEntry.ProductId = orderEntry.Product.Id;
        orderEntry.Quantity = 1;
        orderEntries.Add(orderEntry);
        context.OrderEntries.AddRange(orderEntries);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    public ActionResult deleteOrderEntry([FromRoute] int id)
    {
        //seems to not work somehow, maybe its the returning of an empty list?
        //apparently it was the only problem, now it works correctly
        OrderEntry orderEntryToDelete = context.OrderEntries.Where(x => x.Id == id).FirstOrDefault();
        context.OrderEntries.Remove(orderEntryToDelete);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpPatch]
    [Route("update/{id:int}")]
    public ActionResult updateOrderEntry([FromRoute] int id)
    {
        /*
         *this is also missing a frombody
         */
        OrderEntry orderEntry = context.OrderEntries.Find(id);
        orderEntry.Quantity = 7;
        context.OrderEntries.Update(orderEntry);
        context.SaveChanges();
        return Ok();
    }
}