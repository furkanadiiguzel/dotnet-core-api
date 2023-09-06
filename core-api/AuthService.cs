// Services/AuthService.cs
public async Task<string> AuthenticateAsync(string email, string password)
{
    var user = await _userManager.FindByEmailAsync(email);

    if (user != null && await _userManager.CheckPasswordAsync(user, password))
    {
        var token = GenerateJwtToken(user);
        return token;
    }

    return null;
}
