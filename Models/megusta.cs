using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedSocial.Models
{
    public class megusta
    {
        public int megustaID { get; set; }
        public int idUsuario { get; set; }
        public int idPubli { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaMegusta { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual publicaciones publicaciones { get; set; }
    }
}