﻿namespace SuperHeroAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Userame { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public List<Character> Characters { get; set; } = null!;

    }
}
