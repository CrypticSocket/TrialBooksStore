using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrialBookStoreWebApi.Modal;
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
        public async Task<IActionResult> SignUp([FromBody] SignUpModal signUpModal)
        {
            var result = _accountRepository.SignUpAsync(signUpModal);
            if(result.Result.Succeeded)
            {
                return Ok(result.Result.Succeeded);
            }

            return Unauthorized(result.Result.Errors);
        }
    }
}