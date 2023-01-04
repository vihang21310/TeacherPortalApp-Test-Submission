using System.ComponentModel.DataAnnotations;

namespace TeacherPortal.Data
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Please select a subject.")]
        [Display(Name = "Subject")]

        public string SubjectName { get; set; }



    }
}
