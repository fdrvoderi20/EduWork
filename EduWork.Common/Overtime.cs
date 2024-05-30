using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduWork.Common
{
    [Table("Overtimes")]
    public class Overtime
    {
        [Key]
        public Guid OvertimeId { get; set; }

        public DateTime Date { get; set; }
        public int Hours { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
