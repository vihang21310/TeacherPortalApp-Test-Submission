using System.ComponentModel.DataAnnotations;

namespace TeacherCMS.Models.ViewModel
{
    public class LoginSignUpVM
    {

        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Password { get; set; }


        public string ConfirmPassword { get; set; }


        public DateTime DOB { get; set; }


        public string Gender { get; set; }


        public string EmailId { get; set; }


        public long ContactNo1 { get; set; }
        public long? ContactNo2 { get; set; }


        public int Experience { get; set; }


        public DateTime JoiningDate { get; set; }


        public string SubjectName { get; set; }


        public int ClassNo { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get;  set; }
    }
}
