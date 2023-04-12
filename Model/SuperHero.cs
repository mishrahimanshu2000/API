﻿using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class SuperHero
    {

        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateTimeUpdated { get; set; } = null;
    }
}