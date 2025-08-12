using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [AllowNull]
        public string? LasName { get; set; }

        [Required]
        public string? UserName { get; set; }
        public DateTime CreateBy { get; set; } = DateTime.UtcNow;
    }
}
