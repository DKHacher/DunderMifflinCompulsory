using System.Diagnostics;
using dataaccess;
using dataaccess.Models;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[Route("api/[controller]")]
public class CustomerController(DmContext context) : ControllerBase
{
    [HttpGet]
    [Route("Customers")]
    public ActionResult getCustomers()
    {
        return Ok(context.Customers.ToList());
    }
    
    [HttpGet]
    [Route("CustomerOrder/{id:int}")]
    public ActionResult getSpecificCustomersOrders([FromRoute] int id)
    {
        Customer customer = context.Customers.Find(id);
        
        return Ok(customer.Orders.ToList());
    }
    
    [HttpPost]
    [Route("create")]
    public ActionResult createCustomers([FromBody] Customer customer)
    {
        /*
         *Missing requirements to create customer, starting with basic customer
         *will go further into depth on the creation of customers later, for now this is just to test the method
         *and make sure it works correctly
         *next up later is to make it request a frombody to have the values when creating
        */
        Customer c = new Customer();
        c.Name = customer.Name;
        c.Email = customer.Email;
        c.Address = customer.Address;
        c.Phone = customer.Phone;
        c.Orders = new List<Order>();
        context.Customers.Add(c);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
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
    [Route("update/{id:int}")]
    public ActionResult updateCustomer([FromRoute] int id, [FromBody] Customer c)
    {
        /*
         *this is also missing a frombody 
         */
        Customer customer = context.Customers.Find(id);
        if (c.Name != customer.Name && c.Name != null)
        {
            customer.Name = c.Name;
        }
        if (c.Address != customer.Address && c.Address != null)
        {
            customer.Address = c.Address;
        }
        if (c.Phone != customer.Phone && c.Phone != null)
        {
            customer.Phone = c.Phone;
        }
        if (c.Email != customer.Email && c.Email != null)
        {
            customer.Email = c.Email;
        }
        context.Customers.Update(customer);
        context.SaveChanges();
        return Ok();
    }
    
}
