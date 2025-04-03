using System;
using CineTicket.Core.Entities;
using CineTicket.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace CineTicket.Application.Services;

public class IdentityServices : IIdentityServices
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityServices(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public string UserNameGenerator(string firstName)
    {
        var randomNumber = new Random().Next(100, 9999);
        var userName = $"{firstName}{randomNumber}";
        return userName;
    }

    public async Task<string> CreateUserNameUniqueAsync(string firstName)
    {
        string userName;
        do{
            userName = UserNameGenerator(firstName);
        } while (await _userManager.FindByNameAsync(userName) != null);
        
        return userName;
    }
}
