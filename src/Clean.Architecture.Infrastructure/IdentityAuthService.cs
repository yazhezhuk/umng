using System.Security.Claims;
using Clean.Architecture.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Clean.Architecture.Infrastructure;

public class IdentityAuthService<TUser> : IAuthService
    where TUser: IdentityUser
{
    private readonly ILogger _logger;
    
    private readonly UserManager<TUser> _userManager;
    private readonly SignInManager<TUser> _signInManager;
    
    private readonly IConfiguration _configuration;
    public IdentityAuthService(ILogger logger,
        UserManager<TUser> userManager,
        SignInManager<TUser> signInManager,
        IConfiguration configuration)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async void Login(string email, string password)
    {
        _logger.LogInformation("Trying to log in");
        var signInResult = await _signInManager.PasswordSignInAsync(email, password, false, false);

        if (!signInResult.Succeeded)
            throw new ArgumentException("Password or nickname are incorrect. Please try again.");

        _logger.LogInformation($"Login succeeded with email : {email}" +
                               $" and password : {password}");

        var user = await _userManager.FindByEmailAsync(email);
        await _userManager.AddClaimsAsync(user,new[]{
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(ClaimTypes.Name, user.UserName),
        });
    }

    public void Logout()
    {
        throw new NotImplementedException();
    }

    public bool IsAuthenticated(string username)
    {
        throw new NotImplementedException();
    }
}