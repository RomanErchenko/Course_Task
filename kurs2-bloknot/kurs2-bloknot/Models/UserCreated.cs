using Service_Layer.Model;
using System.ComponentModel.DataAnnotations;

namespace kurs2_bloknot.Models
{
    public class UserCreated
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Login { get; set; }
        [MaxLength(10)]
        public string Password { get; set; }
        public List<NotesCreated>? Note { get; set; } = new();
    }
}
