using dataaccess;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[Route("")]
public class CustomerController(DmContext context) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public ActionResult getCustomers()
    {
        return Ok(context.Customers.ToList());
    }
    
}
