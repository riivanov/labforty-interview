namespace API.Data.Entities;

public class Product
{
  public string Id { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }

  public ICollection<Order> Orders { get; set; }
}
