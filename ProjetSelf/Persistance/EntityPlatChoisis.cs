using Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class EntityPlatChoisis : DbContext
    {
        public EntityPlatChoisis() : base("name=SelfDBContext")
        { }
        public virtual DbSet<PlatChoisis> PlatChoisisSet { get; set; }
    }
}
