using Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class EntityRepasPlats : DbContext
    {
        public EntityRepasPlats() : base("name=SelfDBContext")
        { }
        public virtual DbSet<RepasPlats> RepasPlatSet { get; set; }
    }
}
