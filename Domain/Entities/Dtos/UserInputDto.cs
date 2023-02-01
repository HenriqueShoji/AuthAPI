namespace Auth_API.Domain.Entities.Dtos
{
    public class UserInputDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pswrd { get; set; }

        public bool isValid()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Pswrd) || string.IsNullOrEmpty(UserName))
                return false;
            return true;
        }
    }
}
