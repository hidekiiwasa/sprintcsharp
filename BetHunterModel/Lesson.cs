using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetHunterModel
{
    [Table("lesson")]
    public class Lesson
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = null!;

        public Lesson() { }

        public Lesson(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }

        public Lesson(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
