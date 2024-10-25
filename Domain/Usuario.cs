﻿using Microsoft.AspNetCore.Identity;
namespace Domain
{
    public class Usuario : IdentityUser
    {
        public string Nombre    { get; set; }
        public string Apellido { get; set; }


        public string Token {  get; set; }
    }
}
