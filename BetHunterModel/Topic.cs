using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BetHunterModel;

namespace BetHunterModel
{
    [Table("topic")]
    public class Topic
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Lesson")]
        [Column("id_lesson")]
        public Guid LessonId { get; set; }

        public virtual Lesson Lesson { get; set; } = null!;

        public Topic() { }

        public Topic(Lesson lesson)
        {
            Id = Guid.NewGuid();
            Lesson = lesson;
            LessonId = lesson.Id;
        }

        public Topic(Guid id, Lesson lesson)
        {
            Id = id;
            Lesson = lesson;
            LessonId = lesson.Id;
        }
    }
}
