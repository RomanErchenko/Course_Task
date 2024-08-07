using System.ComponentModel.DataAnnotations.Schema;

namespace kurs2_bloknot.Models
{
    public class NotesView
    {
        public Guid Id { get; set; }

        public string Info { get; set; }

        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        
        public virtual UserView User { get; set; }
    }
}
