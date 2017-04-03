using Metier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    class EntityMoisEnCours : DbContext
    {
        public EntityMoisEnCours() : base("name=SelfDBContext")
        { }
        public virtual DbSet<MoisEnCours> MoisEnCoursSet { get; set; }
    }
}