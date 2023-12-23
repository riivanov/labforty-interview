using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string ProductId { get; set; }
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }

    public Customer Customer { get; set; }
    public Product Product { get; set; }
}
