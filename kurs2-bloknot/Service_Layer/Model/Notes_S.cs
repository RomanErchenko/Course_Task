using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Model
{
    //Add Model Notes for service Layer
    public class Notes_S
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public virtual User_S User { get; set; }

    }
}
