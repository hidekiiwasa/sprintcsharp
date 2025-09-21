using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetHunterModel
{
    [Table("alternative")]
    public class Alternative
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Question")]
        [Column("id_question")]
        public Guid QuestionId { get; set; }

        public virtual Question Question { get; set; } = null!;

        [MaxLength(1000)]
        public string Text { get; set; } = string.Empty;

        public bool Correct { get; set; } = false;

        public Alternative() { }

        public Alternative(Question question, string text, bool correct)
        {
            Id = Guid.NewGuid();
            Question = question;
            QuestionId = question.Id;
            Text = text;
            Correct = correct;
        }

        public Alternative(Guid id, Question question, string text, bool correct)
        {
            Id = id;
            Question = question;
            QuestionId = question.Id;
            Text = text;
            Correct = correct;
        }
    }
}
