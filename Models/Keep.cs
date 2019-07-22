using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    // [Required]
    public string UserId { get; set; }
    public string Img { get; set; }
    public bool IsPrivate { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    
    public int Keeps { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }

    // public DateTimeOffset Created { get; set; }
    // public DateTimeOffset Created { get; set; }
    //  2019-07-20T17:36:33-06:00
    // public DateTime Created { get; set; }
    //   2019-07-20T17:36:33 DateTime
  }
}