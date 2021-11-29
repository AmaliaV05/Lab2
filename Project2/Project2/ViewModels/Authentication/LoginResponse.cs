using System;

namespace Project2.ViewModels.Authentication
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
