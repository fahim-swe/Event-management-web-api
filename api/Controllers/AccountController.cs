using AutoMapper;
using jwtAuth.Interfaces;
using repository.Interfaces;

using api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using model.Entities;
using System.Security.Cryptography;
using System.Text;
using jwtAuth.Model;
using api.Helper;

namespace api.Controllers
{
    public class AccountController : ApiBaseController
    {
        private readonly IUnitOkWork _unitOkWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountController(IUnitOkWork unitOkWork, IMapper mapper, ITokenService tokenService){
            _unitOkWork = unitOkWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignUpDto  signUpDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Invalid data." });
            }

            bool emailExists = await _unitOkWork.UserRepository.ExistsAsync(filter => filter.Email == signUpDto.Email);

            if (emailExists)
            {
                return Conflict(new { message = "Email already exists." });
            }

            var user = _mapper.Map<User>(signUpDto);

            var salt = GenerateSalt();
            var passwordHash = GeneratePasswordHash(signUpDto.Password, salt);

            user.PasswordSalt = salt;
            user.PasswordHash = passwordHash;

            
            _unitOkWork.UserRepository.InsertOneAsync(user);
            
            return await _unitOkWork.Commit() ? Ok(new { message = ApiResponseMessage.AccountCreated }) : BadRequest(new {message = ApiResponseMessage.Failed});
        }



        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(new {message = "Invalid data"});
            }

            var user = await _unitOkWork.UserRepository.FindOneAsync(filter => filter.Email == loginDto.Email);
            if (user == null) 
            {
                return Unauthorized(new {message = ApiResponseMessage.UserNotFound });
            }

            if (!this.VerifyPassword(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized(new {message = ApiResponseMessage.PasswordWrong});
            }

           
            var usertoken = _tokenService.CreateToken(_mapper.Map<UserDto>(user));

            return Ok(new {token = usertoken, message = ApiResponseMessage.LoginSuccessfull});
        }




         private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        } 

        private byte[] GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[64];
            rng.GetBytes(salt);
            return salt;
        }

        private byte[] GeneratePasswordHash(string password, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            return hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }


    }
}