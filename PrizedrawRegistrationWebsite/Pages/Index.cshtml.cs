using Microsoft.AspNetCore.Mvc.RazorPages;
using PrizedrawRegistrationWebsite.Models;

namespace PrizedrawRegistrationWebsite.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public void OnPostSubmit(UserDetails person)
    {
        Console.WriteLine($"Name: {person.FullName}, Email: {person.EmailAddress}");
    }
}