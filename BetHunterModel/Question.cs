using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BetHunterModel;

namespace BetHunterModel
{
    [Table("question")]
    public class Question
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Topic")]
        [Column("id_topic")]
        public Guid TopicId { get; set; }

        public virtual Topic Topic { get; set; } = null!;

        [Column("question_number")]
        [Required]
        public int QuestionNumber { get; set; }

        [MaxLength(2000)]
        public string? Statement { get; set; }

        public virtual ICollection<Alternative> Alternatives { get; set; } = new List<Alternative>();

        public Question() { }

        public Question(Topic topic, int questionNumber, string statement)
        {
            Id = Guid.NewGuid();
            Topic = topic;
            TopicId = topic.Id;
            QuestionNumber = questionNumber;
            Statement = statement;
        }

        public Question(Guid id, Topic topic, int questionNumber, string? statement)
        {
            Id = id;
            Topic = topic;
            TopicId = topic.Id;
            QuestionNumber = questionNumber;
            Statement = statement;
        }
    }
}
