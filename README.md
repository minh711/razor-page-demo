# Razor Pages

## Singe File Approach

Code block syntax:

```html
@{ }
```

Có thể dùng `[BindProperty]` hoặc dùng biến bình thường.

### `[BindProperty]` & Dùng biến thông thường

```html
@page
@model RazorPageVer1.Pages.SingleFileDemo.IndexModel
@functions {
    [BindProperty]
    public string Name { get; set; }
}

@{
    if (Request.HasFormContentType)
    {
        Name = Request.Form["name"];
    }

    int age = 10;
}

<h2>This is Page A</h2>

<form method="post">
    <div>Name: <input name="name" /></div>
    <br />
    <div><input type="submit" /></div>
    <br />
</form>

@if (!string.IsNullOrEmpty(Name))
{
    <p>Hello @Name!</p>
    <p>Your are @age year(s) old!</p>
}
```

## PageModel Files

Ở ví dụ trên, có thể vào file `.cs` (`PageModel`) để chỉnh property.

```cs
public class NameModel : PageModel
{
    public string Name { get; set; }

    public void OnGet()
    {
    }
}
```

## `ViewData` & `ViewBag`

`VìewData` là một **dictionary** với key là string.

```cs
[ViewData]
public string NameAttribute { get; set; }

public void OnGet()
{
    ViewData["Name"] = "Nguyen Van A";
    NameAttribute = "Nguyen Van B";
}
```

```html
@{
    ViewBag.MyBag = "My Bag";
}

<p>Hello @ViewData["name"]</p>

<p>@Model.NameAttribute</p>
<p>@ViewData["NameAttribute"]</p>

<p>@ViewBag.MyBag</p>
<p>@ViewData["MyBag"]</p>
```

## `ActionResult`

```cs
public IActionResult OnGet()
{
   return new RedirectToPageResult("/PageModelDemo/Name");
}
```

```cs
public RedirectToPageResult OnGet()
{
    return new RedirectToPageResult("/PageModelDemo/Name");
}
```

## Tag Helpers

```html
<form method="post">
    <input asp-for="Member.PersonId" /><br />
    <input asp-for="Member.Name" /><br />
    <input asp-for="Member.Email" /><br />
    <input asp-for="Member.Password" /><br />
    <input asp-for="Member.PhoneNumber" /><br />
    <input asp-for="Member.DateOfBirth" /><br />
    <input asp-for="Member.Salary" /><br />
    <input asp-for="Member.WebSite" /><br />
    <input asp-for="Member.SendSpam" /><br />
    <input asp-for="Member.NumberOfCats" /><br />
    <input asp-for="Member.Selfie" /><br />
    <input type="submit" value="Submit" />
</form>
```

```cs
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
}
```

## Startup Class (`Program.cs` for `.NET 6` and newer)

`Program.cs`:

```cs
Add services to the container.
builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
   options.RootDirectory = "/MyPages";
});
```

## Configuration

In `appsetings.json`:

```json
"MySettings": {
  "MyName": "Nguyen Van A"
}
```

```cs
 private readonly IConfiguration _configuration;

 public IndexModel(IConfiguration configuration)
 {
     _configuration = configuration;
 }

 public void OnGet()
 {
     ViewData["config"] = _configuration["MySettings:MyName"];
 }
```
