using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeacherCMS.Data;
using TeacherCMS.Models.ViewModel;
using TeacherCMS.Services;
using TeacherPortalApp.Models;

namespace TeacherPortalApp.Controllers
{
    public class HomeController : Controller
    {
        private ISignUpLogin _repo;
        private ApplicationDbContext _db;

        public HomeController(ISignUpLogin repo, ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            var subjectList = await _db.Subjects.Select(x => new LoginSignUpVM
            {
                SubjectId = x.SubjectId,

                SubjectName = x.SubjectName

            }).ToListAsync();

            ViewBag.Subjects = subjectList;

            var classNo = await _db.Classes.Select(x => new LoginSignUpVM
            {
                ClassId = x.ClassId,
                ClassNo = x.ClassNo,


            }).ToListAsync();

            ViewBag.Class = classNo;

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(LoginSignUpVM dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Task<string> resp = _repo.Create(dto);
                    TempData["msg"] = resp;
                    return RedirectToAction("LogIn");
                }

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Register");
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(LoginSignUpVM dto)
        {
            Task<string> resp = _repo.Login(dto);
            TempData["msg"] = resp;
            return View();
        }
    }
}