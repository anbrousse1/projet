using Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class EntityUtilisateurUsager : DbContext
    {
        public EntityUtilisateurUsager() : base("name=SelfDBContext")
        { }
        public virtual DbSet<UtilisateurUsager> UtilisateurUsagerSet { get; set; }
    }
}

