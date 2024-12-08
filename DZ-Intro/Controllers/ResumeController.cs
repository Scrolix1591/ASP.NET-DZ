using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DZ_Intro.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DZ_Intro.Controllers
{
    public class ResumeController : Controller
    {
        public ResumeModel resume = new ResumeModel()
        {
            FirstName = "Oleksandr",
            LastName = "Savchenko",
            DateOfBirth = new DateTime(2005, 11, 7),
            Age = 19,
            FrontEnd = ["html", "css",],
            BackEnd = ["c++", "c#",],
            Frameworks = [".NET Framework", ".NET", "QT Framework",],
        };

        public IActionResult MyResume()
        {
            return View(resume);
        }
    }
}
