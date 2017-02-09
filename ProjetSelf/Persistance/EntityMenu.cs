using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;

namespace Persistance
{
    class EntityMenu : DbContext
    {
        public EntityMenu() : base("name=SelfDBContext")
        { }
        public virtual DbSet<Menu> MenuSet { get; set; }
    }
}