using Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class EntityRepas : DbContext
    {
        public EntityRepas() : base("name=SelfDBContext")
        { }
        public virtual DbSet<Repas> RepasSet { get; set; }
    }
}
