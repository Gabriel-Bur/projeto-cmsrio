using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Classes
{
    public class Avaliacao
    {
        public int IDAvaliacao { get; set; }


        public int IDHospital { get; set; }


        public string Nome { get; set; }


        public string Email { get; set; }


        public string Topico { get; set; }


        public string Comentario { get; set; }


        public string Data { get; set; }
    }
}
