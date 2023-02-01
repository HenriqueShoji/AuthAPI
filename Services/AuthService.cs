using Auth_API.Domain.Entities;
using Auth_API.Domain.Entities.Dtos;
using Auth_API.Middleware.Exceptions;
using Auth_API.Repositories;
using Auth_API.Services.SecurityService;
using Microsoft.AspNetCore.Mvc;

namespace Auth_API.Services
{
    public class AuthService
    {
        public IConfiguration _configuration { get; set; }
        public SecureService _secureService;

        public AuthService(IConfiguration configuration, SecureService secureService)
        {
            _configuration = configuration;
            _secureService = secureService;
        }

        public async Task RegisterUser(UserInputDto inputDto)
        {
            try
            {
                if(inputDto.isValid())
                {
                    using (Context db = new Context(_configuration.GetConnectionString("SQLAuth")))
                    {
                        if (await _secureService.VerifyRegisteredEmail(inputDto.Email))
                        {
                            throw new DuplicateDataException("Email already exists");
                        }
                        else
                        { 
                            User user = new User
                            {
                                UserName = inputDto.UserName,
                                Email = inputDto.Email,
                                Pswrd = _secureService.EncryptPassword(inputDto.Pswrd),
                                CreateDate = DateTime.Now,
                                LastLogin = DateTime.Now
                            };
                            db.User.AddAsync(user);
                            db.SaveChangesAsync();
                        }
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

        public async Task<Guid> LogIn(LogInDto inputDto)
        {
            try
            {
                if(inputDto.IsValid())
                {
                    await _secureService.VerifyPassword(inputDto.Email, inputDto.Password);

                    using (Context db = new Context(_configuration.GetConnectionString("SQLAuth")))
                    {
                        return db.User.FirstOrDefault(x => x.Email == inputDto.Email).Id;
                    }
                }
                throw new NotFoundException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
    }
}
