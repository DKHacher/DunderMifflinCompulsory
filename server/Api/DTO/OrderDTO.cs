using dataaccess.Models;

namespace Api.DTO;

public class OrderDTO
{
    public DateTime OrderDate { get; set; }
    public DateOnly deliveryDate { get; set; }
    public int customerId { get; set; }
    
    public List<OrderEntry> OrderEntries { get; set; }
}