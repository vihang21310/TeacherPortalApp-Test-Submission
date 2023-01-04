using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TeacherCMS.Data;
using TeacherCMS.Models.ViewModel;
using TeacherPortal.Data;

namespace TeacherCMS.Services
{
    public interface ISignUpLogin
    {
        Task<string> Create(LoginSignUpVM dto);
        Task<string> Login(LoginSignUpVM dto);

    }
    public class SignUpLoginService : ISignUpLogin
    {
        private ApplicationDbContext _db;
        public SignUpLoginService(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<string> Create(LoginSignUpVM dto)
        {
            try
            {
                var existingTeacher = await _db.Teachers.FirstOrDefaultAsync(x => x.EmailId == dto.EmailId);
                if (existingTeacher != null)
                {
                    throw new Exception("Teacher with same EmailID already exists");
                }
                Teacher tcr = new Teacher()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    EmailId = dto.EmailId,
                    ContactNo1 = dto.ContactNo1,
                    ContactNo2 = dto.ContactNo2,
                    DOB = dto.DOB,
                    Gender = dto.Gender,
                    Password = dto.Password,
                    ConfirmPassword = dto.ConfirmPassword,
                    JoiningDate = dto.JoiningDate,

                };

                _db.Teachers.Add(tcr);
                await _db.SaveChangesAsync();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Login(LoginSignUpVM dto)

        {
            try
            {
                var message = "";
                var authenticate = await _db.Teachers.Where(x => x.EmailId == dto.EmailId && x.Password == dto.Password).FirstOrDefaultAsync();
                if (authenticate != null)
                {
                    message = "login Succesfull";
                }
                else
                {
                    message = "Incorrect Credentials. Try again!";
                }
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
