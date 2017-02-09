using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;

namespace Persistance
{
    class EntityPlat : DbContext
    {
        public EntityPlat() : base("name=SelfDBContext")
        { }
        public virtual DbSet<Plat> PlatSet { get; set; }
    }
}