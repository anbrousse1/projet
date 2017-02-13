using Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class EntityUtilisateur : DbContext
    {
        public EntityUtilisateur() : base("name=SelfDBContext")
        { }
        public virtual DbSet<Utilisateur> UtilisateurSet { get; set; }
    }

}

