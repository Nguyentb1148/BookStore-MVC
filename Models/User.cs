using System.ComponentModel.DataAnnotations;

namespace BulkyBook1Web.Models;

public class User
{
    [Key]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(password),ErrorMessage = "Password and confirmation password  did not match")]
    public string confirmPassword { get; set; }

}