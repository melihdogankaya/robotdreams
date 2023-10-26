﻿using System.ComponentModel.DataAnnotations;

namespace RobotDreams.API.Context.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
