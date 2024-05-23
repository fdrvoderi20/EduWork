using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduWork.Entities
{
    [Table("ProjectTypes")]
    public class ProjectType
    {
        [Key]
        public Guid TypeId { get; set; }

        [Required]
        [StringLength(60)]
        public string? TypeName { get; set; }

        public virtual ICollection<Project>? Projects { get; set; }
    }
}
