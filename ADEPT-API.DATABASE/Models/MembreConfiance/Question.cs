using ADEPT_API.DATABASE.Models.Markers;
using System;
using System.ComponentModel.DataAnnotations;

namespace ADEPT_API.DATABASE.Models.MembreConfiance
{
  public class Question : IBaseModel
  {
    [Key]
    public Guid Id {  get; set; }

    [Required]
    public string Content {  get; set; }

    public int Activated {  get; set; } 
  }
}
