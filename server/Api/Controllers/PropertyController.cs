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
    public ActionResult createProperties()
    {
        List<Property> properties = context.Properties.ToList();
        Property property = new Property();
        property.PropertyName = "Name";
        property.Papers = new List<Paper>();
        properties.Add(property);
        context.Properties.AddRange(properties);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    public ActionResult deleteProperty([FromRoute] int id)
    {
        Property propertyToDelete = context.Properties.Where(x => x.Id == id).FirstOrDefault();
        context.Properties.Remove(propertyToDelete);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpPatch]
    [Route("update/{id:int}")]
    public ActionResult updateProperty([FromRoute] int id)
    {
        Property property = context.Properties.Find(id);
        property.PropertyName = "Name";
        context.Properties.Update(property);
        context.SaveChanges();
        return Ok();
    }
}