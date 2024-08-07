using System.ComponentModel.DataAnnotations;

namespace kurs2_bloknot.Models
{
    public class UserView
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<NotesView>? Note { get; set; } = new List<NotesView>();
    }
}
