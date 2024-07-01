using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Model
{
    public class User_S
    {
        //Add Model User for service Layer

        public int Id { get; set; }
        public string Name { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual List<Notes_S>? Note { get; set; } = new List<Notes_S>();
    }
}
