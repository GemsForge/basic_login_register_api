using Register_API.Model;
using System;

namespace Register_API.Model.payload
{

    /// <summary>
    ///The RegisterRequestModel encapsulates the necessary data required for user registration and serves
    ///as a structured representation of the information needed to create a new user account within the application.
    /// </summary>
    public class RegisterRequestModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}