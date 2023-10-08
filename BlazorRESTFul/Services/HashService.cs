namespace BlazorRESTFul.Services
{
    public class HashService : IHashService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
