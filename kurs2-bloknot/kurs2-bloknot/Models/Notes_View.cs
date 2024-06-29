namespace kurs2_bloknot.Models
{
    public class Notes_View
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public virtual User_View User { get; set; }
    }
}
