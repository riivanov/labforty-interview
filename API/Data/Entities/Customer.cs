using System.ComponentModel.DataAnnotations;

namespace API.Data.Entities;

public class Customer
{
  [Key]
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public byte Age { get; set; }

  public ICollection<Order> Orders { get; set; }
}
