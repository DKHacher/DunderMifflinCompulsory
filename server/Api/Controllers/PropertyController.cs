using dataaccess;
using dataaccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
public class PropertyController(DmContext context) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public ActionResult getProperties()
    {
        return Ok(context.Properties.ToList());
    }
    
    [HttpPost]
    [Route("create")]
    public ActionResult createProperties([FromBody] Property property)
    {
        context.Properties.Add(property);
        context.SaveChanges();
        return Ok();
    }
}