using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetHunterModel
{
    [Table("article")]
    public class Article
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = null!;

        public Article() { }

        public Article(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }
    }
}
