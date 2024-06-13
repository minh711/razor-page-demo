using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RazorPageVer1.Pages.TagHelperDemo
{
    public class Member
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        [Url]
        public string WebSite { get; set; }
        [Display(Name = "Send spam to me")]
        public bool SendSpam { get; set; }
        public int? NumberOfCats { get; set; }
        public IFormFile Selfie { get; set; }
    }

    public class IndexModel : PageModel
    {
        public Member Member { get; set; }

        public void OnGet()
        {
        }
    }
}
