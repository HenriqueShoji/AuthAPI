namespace Auth_API.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Pswrd { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
