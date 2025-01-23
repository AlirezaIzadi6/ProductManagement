// This is just a fake service and does not do anything. The purpose of this service is to make Identity services work.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;

public class EmailSender : IEmailSender<IdentityUser>
{
#pragma warning disable CS1998
    public async Task SendConfirmationLinkAsync(IdentityUser user, string s1, string s2) { }

    public async Task SendPasswordResetLinkAsync(IdentityUser user, string s1, string s2) { }

    public async Task SendEmailAsync(string s1, string s2, string s3) { }

    public async Task SendPasswordResetCodeAsync(IdentityUser user, string s1, string s2) { }
#pragma warning restore CS1998
}
