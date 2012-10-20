using System.Data.Entity;
using ViewsLab.Domain;

namespace ViewsLab.Data.EF
{
    public class GCUToursCeContext : DbContext
    {
        public GCUToursCeContext()
            : base("name = gcutourswmEntities")
        { 
            this.Configuration.LazyLoadingEnabled = false; 
        }

        public DbSet<User> Users { get; set; }
    }
}