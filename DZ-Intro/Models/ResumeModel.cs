using Microsoft.Extensions.ObjectPool;

namespace DZ_Intro.Models
{
    public class ResumeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + LastName;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string[] FrontEnd { get; set; }
        public string[] BackEnd { get; set; }
        public string[] Frameworks { get; set; }
    }
}
