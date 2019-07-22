using System;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }
    [Required]
    public int VaultId { get; set; }
    [Required]
    public int KeepId { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
    [Required]
    public string UserId { get; set; }
  }
}