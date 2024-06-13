using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageVer1.Pages.PageModelDemo
{
    public class ViewDataModel : PageModel
    {
        [ViewData]
        public string NameAttribute { get; set; }

        public void OnGet()
        {
            ViewData["Name"] = "Nguyen Van A";
            NameAttribute = "Nguyen Van B";
        }
    }
}
