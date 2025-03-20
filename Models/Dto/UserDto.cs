﻿namespace EcoinverGMAO_api.Models.Dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string NombreCompleto { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }  // Opcional: lista de roles a asignar
    }
}
