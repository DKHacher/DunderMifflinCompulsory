using dataaccess;
using dataaccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[Route("api/[controller]")]
public class PaperController(DmContext context) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public ActionResult getPapers()
    {
        return Ok(context.Papers.ToList());
    }
    
    [HttpPost]
    [Route("create")]
    public ActionResult createPapers([FromBody] Paper paper)
    {
        context.Papers.Add(paper);
        context.SaveChanges();
        return Ok();
    }

    [HttpPatch]
    [Route("Discontinue{id:int}")]
    public ActionResult Discontinue([FromRoute] int id)
    {
        Paper paper = context.Papers.Find(id);
        paper.Discontinued = true;
        context.SaveChanges();
        return Ok(paper.Name + " has been discontinued");
    }

    [HttpPatch]
    [Route("Restock{id:int}")]
    public ActionResult Restock([FromRoute] int id, [FromBody] int amount)
    {
        Paper paper = context.Papers.Find(id);
        if (paper.Discontinued == false)
        {
            paper.Stock += amount;   
            return Ok(paper.Name + " has been restocked");
        }
        else
        {
            return BadRequest("Cant Restock Discontinued Product");
        }
        
        
    }
}