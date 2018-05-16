using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Modelo.Classes;



namespace WebApi.Contexto
{
    public class Contexto:DbContext
    {
        public Contexto() : base("DefaultConnection") { }

        public DbSet<Hospital> Hospitais { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
    }



}