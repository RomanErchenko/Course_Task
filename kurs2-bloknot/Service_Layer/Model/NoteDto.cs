using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Model
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Info { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; } = new();
    }
}
