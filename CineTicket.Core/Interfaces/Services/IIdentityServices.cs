using System;

namespace CineTicket.Core.Interfaces.Services;

public interface IIdentityServices
{
    public string UserNameGenerator(string firstName);
    public Task<string> CreateUserNameUniqueAsync(string firstName);   
}
