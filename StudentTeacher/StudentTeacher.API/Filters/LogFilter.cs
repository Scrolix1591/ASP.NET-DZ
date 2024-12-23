using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentTeacher.API.Filters
{
    public class LogFilter : Attribute, IActionFilter
    {
        private readonly string _name;
        public LogFilter([CallerMemberName] string? name = null)
        {
            _name = name;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Before endpoint[{_name}]");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"After endpoint");
        }
    }
}
