﻿namespace SistemaEscolar.Domain.Entities
{
    public class Institution : BaseEntity
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Website { get; set; }

        public int UserId { get; set; }

        public virtual User? User { get; set; }

    }
}