using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Controllers.v1.AuthControllers
{

    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(EmployeeRegisterDTO newEmployeeDto)
        {
            // Attempt to register the new employee using the authentication service
            var result = await _authService.RegisterAsync(newEmployeeDto);
            if (result.IsSuccess)
            {
                // Return a success response if registration was successful
                return Ok("User registered successfully");
            }

            // Return a bad request response with the error message if registration failed
            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO request)
        {
            // Attempt to log in the employee using the authentication service
            var result = await _authService.LoginAsync(request);
            if (result.IsSuccess)
            {
                // Return a success response with the JWT token if login was successful
                return Ok(new
                {
                    message = "Please, save this token",
                    jwt = result.Token
                });
            }

            // Return an unauthorized response with the error message if login failed
            return Unauthorized(result.Message);
        }
    }
}