using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string description { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
    // [Required]
    public string UserId { get; set; }
  }
}