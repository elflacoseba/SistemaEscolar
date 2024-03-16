﻿namespace SistemaEscolar.Domain.Entities
{
    public partial class User : BaseEntity
    {      
        public string? UserName { get; set; }

        public string? PasswordHash { get; set; }

        public string? Email { get; set; }

        public string? Image { get; set; }

    }
}
