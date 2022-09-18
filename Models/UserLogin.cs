using System.ComponentModel.DataAnnotations;

namespace BulkyBook1Web.Models
{
    public class UserLogin
    {
        [Display(Name ="Email ID")]
        [Required(AllowEmptyStrings = false,ErrorMessage ="Email ID required")]

        public string emailID { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Password required")]
        [DataType(DataType.Password)]

        public string password { get; set; }
        [Display(Name ="Remenber Me")]
        public bool remenberMe { get; set; }
    }
}
