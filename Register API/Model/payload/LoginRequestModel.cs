using System;

namespace Register_API.Model.payload
{

    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class LoginRequestModel
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}