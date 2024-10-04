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
        /*
         *Missing requirements to create property, starting with basic property
         *will go further into depth on the creation of propertys later, for now this is just to test the method
         *and make sure it works correctly
         *next up later is to make it request a frombody to have the values when creating
         */
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
        //seems to not work somehow, maybe its the returning of an empty list?
        //apparently it was the only problem, now it works correctly
        Property propertyToDelete = context.Properties.Where(x => x.Id == id).FirstOrDefault();
        context.Properties.Remove(propertyToDelete);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpPatch]
    [Route("update/{id:int}")]
    public ActionResult updateProperty([FromRoute] int id)
    {
        /*
         *this is also missing a frombody
         */
        Property property = context.Properties.Find(id);
        property.PropertyName = "Name";
        context.Properties.Update(property);
        context.SaveChanges();
        return Ok();
    }
}