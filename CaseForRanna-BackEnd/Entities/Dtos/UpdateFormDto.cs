﻿namespace CaseForRanna_BackEnd.Entities.Dtos
{
    public class UpdateFormDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
