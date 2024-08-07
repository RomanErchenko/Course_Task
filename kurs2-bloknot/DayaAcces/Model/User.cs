using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayaAcces.Model
{
    public class User
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public virtual List<Notes>? Note { get; set; } = new List<Notes>();
    }


}
