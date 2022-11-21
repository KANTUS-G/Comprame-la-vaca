using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COmpamelaVacaAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public int idRole { get; set; }

        public string nombre { get; set; }

        public string correo { get; set; }

        public string contraseña { get; set; }

        public string telefono { get; set; }
    }
}
