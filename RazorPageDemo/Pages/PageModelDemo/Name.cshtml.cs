using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageVer1.Pages.PageModelDemo
{
    public class NameModel : PageModel
    {
        public string Name { get; set; }

        public void OnGet()
        {
        }
    }
}
