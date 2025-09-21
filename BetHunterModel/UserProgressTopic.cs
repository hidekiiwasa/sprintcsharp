using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetHunterModel
{
    [Table("user_progress_topic")]
    public class UserProgressTopic
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("User")]
        [Column("id_user")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;

        [Required]
        [ForeignKey("Topic")]
        [Column("id_topic")]
        public Guid TopicId { get; set; }

        public virtual Topic Topic { get; set; } = null!;

        [Required]
        [ForeignKey("Question")]
        [Column("id_question")]
        public Guid QuestionId { get; set; }

        public virtual Question Question { get; set; } = null!;

        [Required]
        public bool Completed { get; set; } = false;

        public UserProgressTopic() { }

        public UserProgressTopic(User user, Topic topic, Question question, bool completed)
        {
            Id = Guid.NewGuid();
            User = user;
            UserId = user.Id;
            Topic = topic;
            TopicId = topic.Id;
            Question = question;
            QuestionId = question.Id;
            Completed = completed;
        }

        public UserProgressTopic(Guid id, User user, Topic topic, Question question, bool completed)
        {
            Id = id;
            User = user;
            UserId = user.Id;
            Topic = topic;
            TopicId = topic.Id;
            Question = question;
            QuestionId = question.Id;
            Completed = completed;
        }
    }
}
