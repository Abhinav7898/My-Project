using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CRUD.Dal
{
    public partial class CRUDDalBase : DbContext
    {
        public CRUDDalBase(DbContextOptions<CRUDDalBase> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
