using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolateAPI.Models;
using HotChocolateAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace HotChocolateAPI.Controllers
{
    [Route("/api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUrer([FromBody]RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute]int id)
        {
            var IsDeleted = _accountService.Delete(id);
            if (IsDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
