using Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class EntityPlatProduit : DbContext
    {
        public EntityPlatProduit() : base("name=SelfDBContext")
        { }
        public virtual DbSet<PlatProduit> PlatProduitSet { get; set; }
    }
}
