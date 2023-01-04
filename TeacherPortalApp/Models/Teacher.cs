using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeacherPortal.Data
{
    public class Teacher
    {
        [Key]

        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please add DOB")]
        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please add Gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please add your Email ID")]
        [Display(Name = "Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please add your contact no.")]
        [Display(Name = "Contact No 1")]
        public long ContactNo1 { get; set; }
        public long? ContactNo2 { get; set; }

        [Required(ErrorMessage = "Please fill the required field.")]
        [Display(Name = "Experience")]
        public int Experience { get; set; }

        [Required(ErrorMessage = "Please fill the required field.")]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }

        public int? SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        public int? ClassId { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }


    }
}
