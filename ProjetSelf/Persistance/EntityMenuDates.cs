using Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class EntityMenuDates : DbContext
    {
        public EntityMenuDates() : base("name=SelfDBContext")
        { }
        public virtual DbSet<MenuDates> MenuDatesSet { get; set; }
    }
}
