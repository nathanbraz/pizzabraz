﻿namespace PizzaBraz.API.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Guid CompanyId { get; set; }
    }
}
