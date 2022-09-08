using System;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook1Web.Models
{
    public class Category
    {
        [Key]//Make id is a key
        public int  Id{ get; set; }
        [Required]//Make name is required
        public string Name { get; set; }

        public int DisplayOder { get; set; }

        public DateTime CreatedDataTime { get; set; } = DateTime.Now;


    }
}

