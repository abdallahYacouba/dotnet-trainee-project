namespace MinimalIdentityDemo.Models;
public class LoginRequest
{
    public string? EmailOrUserName { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? UserName { get; init; }
    //public string? TwoFactorCode { get; init; }
    //public string? TwoFactorRecoveryCode { get; init; }
    // Custome properties
    public string? MacAddress { get; init; }
    public bool RememberDevice { get; init; }

    public string GetIdentity() =>
            !string.IsNullOrWhiteSpace(EmailOrUserName) ? EmailOrUserName :
            !string.IsNullOrWhiteSpace(Email) ? Email! :
            UserName ?? string.Empty;
}
