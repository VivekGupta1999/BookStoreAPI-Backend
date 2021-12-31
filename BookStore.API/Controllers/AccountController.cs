using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Models;
using BookStore.API.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        public IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]SignUpModel signupmodel)
        {
            var result = await _accountRepository.SignUpAsync(signupmodel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signinmodel)
        {
            var result = await _accountRepository.LoginAsync(signinmodel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

    }
}

