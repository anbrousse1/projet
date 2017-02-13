using Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class EntityUsager : DbContext
    {
        public EntityUsager() : base("name=SelfDBContext")
        { }
        public virtual DbSet<Usager> UsagerSet { get; set; }
    }

}
}
