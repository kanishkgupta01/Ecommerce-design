﻿namespace Ecom_RajasthanRoyals.DTOs
{
   
        public class RegisterUserDto
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginDto
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    
}
