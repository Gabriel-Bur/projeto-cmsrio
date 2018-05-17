using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Contexto
{
    public class Contexto: DbContext
    {
        public Contexto() : base("DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Contexto>());

        }


    }
}