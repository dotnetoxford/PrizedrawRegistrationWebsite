using Microsoft.AspNetCore.Mvc;

namespace PrizedrawRegistrationWebsite.Models;

public class UserDetails
{
    [BindProperty] public string FullName { get; set; } = null!;
    [BindProperty] public string EmailAddress { get; set; } = null!;
}