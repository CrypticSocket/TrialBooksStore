using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrialBookStoreWebApi.Model;
using TrialBookStoreWebApi.Repository;

namespace TrialBookStoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel SignUpModel)
        {
            var result = _accountRepository.SignUpAsync(SignUpModel);
            if(result.Result.Succeeded)
            {
                return Ok(result.Result.Succeeded);
            }

            return Unauthorized(result.Result.Errors);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] SignInModel signIn)
        {
            var result = _accountRepository.LoginAsync(signIn);
            if(string.IsNullOrEmpty(result.Result))
            {
                return Unauthorized();
            }

            return Ok(result.Result);
        }
    }
}