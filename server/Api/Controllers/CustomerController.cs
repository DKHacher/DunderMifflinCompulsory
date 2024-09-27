using dataaccess;
using dataaccess.Models;
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
    
    [HttpPost]
    [Route("api/create")]
    public ActionResult createCustomers()
    {
        /*
         *Missing requirements to create customer, starting with basic customer
         *will go further into depth on the creation of customers later, for now this is just to test the method
         *and make sure it works correctly
         *next up later is to make it request a frombody to have the values when creating
        */
        List<Customer> customers = context.Customers.ToList();
        Customer customer = new Customer();
        customer.Name = "John Doe";
        customer.Email = "john.doe@gmail.com";
        customer.Phone = "555-555-5555";
        customer.Address = "123 Main Street";
        customers.Add(customer);
        context.Customers.AddRange(customers);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpDelete]
    [Route("api/delete/{id:int}")]
    public ActionResult deleteCustomer([FromRoute] int id)
    {
        //seems to not work somehow, maybe its the returning of an empty list?
        //apparently it was the only problem, now it works correctly
        Customer customerToDelete = context.Customers.Where(x => x.Id == id).FirstOrDefault();
        context.Customers.Remove(customerToDelete);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpPatch]
    [Route("api/update/{id:int}")]
    public ActionResult updateCustomer([FromRoute] int id)
    {
        /*
         *this is also missing a frombody 
         */
        Customer customer = context.Customers.Find(id);
        customer.Name = "Jane Doe";
        context.Customers.Update(customer);
        context.SaveChanges();
        return Ok();
    }
    
}
