using System.ComponentModel.DataAnnotations;

namespace BulkyBook1Web.Models;

public class User
{
    [Key]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
}