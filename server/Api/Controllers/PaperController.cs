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
    public ActionResult createPapers()
    {
        List<Paper> papers = context.Papers.ToList();
        Paper paper = new Paper();
        paper.Name = "A4";
        paper.Discontinued = false;
        paper.Stock = 3;
        paper.Price = 1.99;
        paper.Properties = new List<Property>();
        paper.OrderEntries = new List<OrderEntry>();//not sure if this one is needed
        papers.Add(paper);
        context.Papers.AddRange(papers);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    public ActionResult deletePapers([FromRoute] int id)
    {
        Paper paperToDelete = context.Papers.Where(x => x.Id == id).FirstOrDefault();
        context.Papers.Remove(paperToDelete);
        context.SaveChanges();
        return Ok();
    }
    
    [HttpPatch]
    [Route("update/{id:int}")]
    public ActionResult updatePapers([FromRoute] int id)
    {
        Paper paper = context.Papers.Find(id);
        paper.Name = "A3";
        context.Papers.Update(paper);
        context.SaveChanges();
        return Ok();
    }
}