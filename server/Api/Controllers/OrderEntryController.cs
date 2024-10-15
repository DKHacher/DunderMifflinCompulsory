using dataaccess;
using dataaccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
public class OrderEntryController(DmContext context) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public ActionResult getOrderEntries()
    {
        return Ok(context.OrderEntries.ToList());
    }
    
    [HttpPost]
    [Route("create")]
    public ActionResult createOrderEntry([FromBody] OrderEntry orderEntry)
    {
        context.OrderEntries.Add(orderEntry);
        context.SaveChanges();
        return Ok();
    }
}