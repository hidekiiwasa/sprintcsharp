using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetHunterModel
{
    [Table("user_answer")]
    public class UserAnswer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("User")]
        [Column("id_user")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;

        [Required]
        [ForeignKey("Question")]
        [Column("id_question")]
        public Guid QuestionId { get; set; }

        public virtual Question Question { get; set; } = null!;

        [ForeignKey("Alternative")]
        [Column("id_alternative")]
        public Guid? AlternativeId { get; set; }

        public virtual Alternative? Alternative { get; set; }

        public bool? Correct { get; set; }

        public UserAnswer() { }

        public UserAnswer(User user, Question question, Alternative alternative, bool? correct)
        {
            Id = Guid.NewGuid();
            User = user;
            UserId = user.Id;
            Question = question;
            QuestionId = question.Id;
            Alternative = alternative;
            AlternativeId = alternative?.Id;
            Correct = correct;
        }

        public UserAnswer(Guid id, User user, Question question, Alternative alternative, bool? correct)
        {
            Id = id;
            User = user;
            UserId = user.Id;
            Question = question;
            QuestionId = question.Id;
            Alternative = alternative;
            AlternativeId = alternative?.Id;
            Correct = correct;
        }
    }
}
