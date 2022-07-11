using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using PrizedrawRegistrationWebsite.Models;

namespace PrizedrawRegistrationWebsite.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly Config _config;

    public IndexModel(ILogger<IndexModel> logger, IOptions<Config> config)
    {
        _logger = logger;
        _config = config.Value;
    }

    public void OnGet()
    {
    }

    public async Task OnPostSubmitAsync(UserDetails userDetails)
    {
        var tableClient = new TableClient(_config.StorageConnectionString, "Attendees");

        var meetingId = "39e1fd99-79c9-4b75-979e-437c7456fa53"; // Random GUID for this event (same as in the route)

        await tableClient.AddEntityAsync(new Attendee
        {
            PartitionKey = meetingId,
            RowKey = Guid.NewGuid().ToString(),

            Type = 1, // Zoom event types - we don't care what it is - but it can't be 0, as the Prizedraw app will ignore it
            MeetingUuid = "n/a",
            MeetingId = meetingId,
            MeetingName = "July 2022 Lightning Talks",
            UserName = userDetails.FullName,
            UserId = userDetails.EmailAddress,
            UserUuid = "n/a",
            JoinTime = DateTime.UtcNow,
            LeaveTime = null,
        });
    }
}
