using System.ComponentModel.DataAnnotations;

namespace kurs2_bloknot.Models
{
    public class User_View
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Notes_View>? Note { get; set; } = new List<Notes_View>();
    }
}
