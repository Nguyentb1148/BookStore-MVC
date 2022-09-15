using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook1Web.Models
{
    public class Category
    {
        [Key]//Make id is a key
        public int  Id{ get; set; }
        [Required]//Make name is required
        public string Name { get; set; }
        [DisplayName("Display Order")]//Use DisplayName to display what we want to display in the view
        [Range(1,100,ErrorMessage ="Display Order must between 1 to 100 only !!!")]//Make min and max value
        public int DisplayOder { get; set; }
        [DisplayName("Create DataTime")]
        public DateTime CreatedDataTime { get; set; } = DateTime.Now;
    }
}

