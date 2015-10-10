using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDDMota2.Domain.Entities
{
    public class Login
    {
        public int LoginId { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
    }
}
