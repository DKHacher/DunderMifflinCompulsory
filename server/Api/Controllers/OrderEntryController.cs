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
        OrderEntry orderEntryToDelete = context.OrderEntries.Where(x => x.Id == id).FirstOrDefault();
        context.OrderEntries.Remove(orderEntryToDelete);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpPatch]
    [Route("update/{id:int}")]
    public ActionResult updateOrderEntry([FromRoute] int id)
    {
        OrderEntry orderEntry = context.OrderEntries.Find(id);
        orderEntry.Quantity = 7;
        context.OrderEntries.Update(orderEntry);
        context.SaveChanges();
        return Ok();
    }
}