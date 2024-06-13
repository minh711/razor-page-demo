using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageVer1.Pages.ActionResultDemo
{
    public class IndexModel : PageModel
    {
        //public IActionResult OnGet()
        //{
        //    return new RedirectToPageResult("/PageModelDemo/Name");
        //}

        public RedirectToPageResult OnGet()
        {
            return new RedirectToPageResult("/PageModelDemo/Name");
        }
    }
}
