using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.DTOS;
using HotelAPI.Models;

namespace HotelAPI.Interfaces
{
    // Interface for the authentication service that defines methods for user registration and login.
    public interface IAuthService
    {
        // Asynchronously registers a new employee and returns the result of the operation.
        Task<AuthResult> RegisterAsync(EmployeeRegisterDTO newEmployeeDto);

        // Asynchronously logs in an employee using their credentials and returns the result of the operation.
        Task<AuthResult> LoginAsync(LoginDTO request);
    }
}