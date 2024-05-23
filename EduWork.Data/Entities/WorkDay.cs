using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduWork.Entities
{
    [Table("WorkDays")]
    public class WorkDay
    {
        [Key]
        public Guid WorkDayId { get; set; }

        public DateTime Date { get; set; }

        public TimeOnly? SetTime { get; set; }

        public TimeOnly? EndTime { get; set; }

        public TimeSpan? BreakTime { get; set; }

        public int? ScheduledTime { get; set; }

        public int? ActualTime { get; set; }

        public virtual ICollection<User_WorkDay>? User_WorkDays { get; set; }
    }
}
