using BC = BCrypt.Net.BCrypt;

public static class PasswordUtils
{
    public static string @HashPassword(string password)
    {
        return BC.HashPassword(password);
    }

    public static bool VerifyPassword(string hashedPassword, string password)
    {
        return BC.Verify(password, hashedPassword);
    }
}