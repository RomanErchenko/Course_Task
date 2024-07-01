using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.Model
{
    public class Notes
    {

        public int Id { get; set; }
        public string Info { get; set; }=string.Empty;
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = new();
    }
}
