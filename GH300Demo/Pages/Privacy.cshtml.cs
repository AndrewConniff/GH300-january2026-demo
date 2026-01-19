using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace GH300Demo.Pages;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HiringDate { get; set; }
    public string Department { get; set; }
    public string JobTitle { get; set; }
}

public class PrivacyModel : PageModel
{
    public List<Employee> Employees { get; set; } = new();

    public void OnGet()
    {
        var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var filePath = Path.Combine(wwwrootPath, "sampledata.json");
        
        if (System.IO.File.Exists(filePath))
        {
            var json = System.IO.File.ReadAllText(filePath);
            Employees = JsonSerializer.Deserialize<List<Employee>>(json) ?? new();
        }
    }
}

