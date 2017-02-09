using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;

namespace Persistance
{
    class EntityMenuPlat : DbContext
    {
        public EntityMenuPlat() : base("name=SelfDBContext")
        { }
        public virtual DbSet<MenuPlat> MenuPlatSet { get; set; }
    }
}