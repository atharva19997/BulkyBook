using System.ComponentModel;
using System.ComponentModel.DataAnnotations;    //Check documentation for more annotations.

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display order")]  //To show on webpage, like in create category. Also, needed to add system.componentmodel for that
        [Range(1,50,ErrorMessage ="Display order must be between 1 and 50 only!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
