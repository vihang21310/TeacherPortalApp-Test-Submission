using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.Data
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }


        [Required(ErrorMessage = "Please select a class.")]
        [Display(Name = "Class")]
        public int ClassNo { get; set; }
    }
}
