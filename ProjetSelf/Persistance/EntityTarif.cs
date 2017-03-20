using Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class EntityTarif : DbContext
    {
        public EntityTarif() : base("name=SelfDBContext")
        { }
        public virtual DbSet<Tarif> TarifSet { get; set; }
    }
}
