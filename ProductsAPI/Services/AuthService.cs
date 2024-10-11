using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Config;
using ProductsAPI.Data;
using ProductsAPI.DTOS;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    // Service class that implements authentication-related operations for employees.
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context; // Database context for accessing employee data.
        private readonly Utilities _utilities;   // Utility class for encryption and token generation.

        // Constructor that initializes the AuthService with the required dependencies.
        public AuthService(AppDbContext context, Utilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }

        // Asynchronously registers a new employee.
        public async Task<AuthResult> RegisterAsync(EmployeeRegisterDTO newEmployeeDto)
        {
            // Validate the incoming model data.
            var validationResults = ValidateModel(newEmployeeDto);
            if (validationResults.Any())
            {
                return new AuthResult { IsSuccess = false, Message = string.Join(", ", validationResults) };
            }

            // Check if the email already exists in the database.
            if (await _context.Employees.AnyAsync(u => u.Email == newEmployeeDto.Email))
            {
                return new AuthResult { IsSuccess = false, Message = "Email already exists" };
            }

            // Create a new Employee object and encrypt the password.
            var newEmployee = new Employee
            {
                FirstName = newEmployeeDto.FirstName,
                LastName = newEmployeeDto.LastName,
                Email = newEmployeeDto.Email,
                IdentificationNumber = newEmployeeDto.IdentificationNumber,
                Password = _utilities.EncryptSHA256(newEmployeeDto.Password)
            };

            // Add the new employee to the database and save changes.
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            // Return a successful registration result.
            return new AuthResult { IsSuccess = true };
        }

        // Asynchronously logs in an employee.
        public async Task<AuthResult> LoginAsync(LoginDTO request)
        {
            // Validate the incoming model data.
            var validationResults = ValidateModel(request);
            if (validationResults.Any())
            {
                return new AuthResult { IsSuccess = false, Message = string.Join(", ", validationResults) };
            }

            // Retrieve the user based on the provided email.
            var user = await _context.Employees.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return new AuthResult { IsSuccess = false, Message = "Invalid email" };
            }

            // Verify the provided password against the stored password.
            var passwordIsValid = user.Password == _utilities.EncryptSHA256(request.Password);
            if (!passwordIsValid)
            {
                return new AuthResult { IsSuccess = false, Message = "Invalid password" };
            }

            // Generate a JWT token for the logged-in user.
            var token = _utilities.GenerateJwtToken(user);
            return new AuthResult { IsSuccess = true, Token = token };
        }

        // Validates the properties of a given model using data annotations.
        private IEnumerable<string> ValidateModel<T>(T model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            // Validate the object and collect any validation errors.
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults.Select(v => v.ErrorMessage);
        }
    }
}