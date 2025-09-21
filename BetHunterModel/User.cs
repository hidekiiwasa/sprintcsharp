using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetHunterModel
{
    [Table("users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [MaxLength(20)]
        public string? Cellphone { get; set; }

        public int Points { get; set; } = 0;

        public int Placement { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Money { get; set; } = 0m;

        public User() { }

        public User(string email, string password, string name, string? cellphone = null)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            Name = name;
            Cellphone = cellphone;
            Points = 0;
            Placement = 0;
            Money = 0m;
        }
    }
}
