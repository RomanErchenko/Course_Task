using System.ComponentModel.DataAnnotations;

namespace kurs2_bloknot.Models
{
    public class User_Created
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Login { get; set; }
        [MaxLength(10)]
        public string Password { get; set; }
    }
}
