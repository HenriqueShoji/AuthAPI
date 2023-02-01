using Auth_API.Middleware.Exceptions;
using Auth_API.Repositories;

namespace Auth_API.Services.SecurityService
{
    public class SecureService
    {
        public IConfiguration _configuration;

        public SecureService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public string EncryptPassword(string password)
        {
            password = password + "encryptedPassword";
            byte[] encryptPword = new byte[password.Length];
            encryptPword = System.Text.Encoding.UTF8.GetBytes(password);
            string encryptedPword = Convert.ToBase64String(encryptPword);
            return encryptedPword;
        }

        public async Task<bool> VerifyPassword(string email ,string password)
        {
            try
            {
                await VerifyRegisteredEmail(email);
                using (Context db = new Context(_configuration.GetConnectionString("SQLAuth")))
                {
                    var pwrd = db.User.FirstOrDefault(x => x.Email == email).Pswrd;

                    password = password + "encryptedPassword";
                    byte[] encryptPword = new byte[password.Length];
                    encryptPword = System.Text.Encoding.UTF8.GetBytes(password);
                    string encryptedPword = Convert.ToBase64String(encryptPword);

                    if (pwrd != password)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> VerifyRegisteredEmail(string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    using (Context db = new Context(_configuration.GetConnectionString("SQLAuth")))
                    {
                        var verifyEmail = db.User.FirstOrDefault(x => x.Email == email);

                        if (verifyEmail != null)
                            return true;
                        return false;
                    }
                }
                else
                {
                    throw new InvalidInputException("Inputs cannot be null or empty!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
