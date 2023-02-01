namespace Auth_API.Domain.Entities.Dtos
{
    public class LogInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                return false;
            return true;
        }
    }
}
