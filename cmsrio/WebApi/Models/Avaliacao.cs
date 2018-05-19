using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Avaliacao
    {
        [Key]
        public int IDAvaliacao { get; set; }


        public int IDHospital { get; set; }


        public string Nome { get; set; }


        public string Email { get; set; }


        public string Topico { get; set; }


        public string Comentario { get; set; }


        public string Data { get; set; }
    }

}