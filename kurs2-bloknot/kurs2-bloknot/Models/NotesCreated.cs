namespace kurs2_bloknot.Models
{
    public class NotesCreated
    {
       
            public Guid Id { get; set; }
            public string Info { get; set; }=string.Empty;
            public DateTime? Date { get; set; }
            public Guid UserId { get; set; }
            public virtual UserCreated User { get; set; }
        
    }
}
