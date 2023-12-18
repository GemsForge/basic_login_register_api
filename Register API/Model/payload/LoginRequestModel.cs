using System;

namespace Register_API.Model.payload
{

    /// <summary>
    ///A LoginRequestModel payload encapsulates the necessary information required for a user to 
    ///authenticate and log into an application. It typically contains fields that identify and 
    ///verify the user's identity during the login process.
    /// </summary>
    public class LoginRequestModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}