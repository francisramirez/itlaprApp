
using itlapr.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace itlapr.DAL.Context
{
    public class ItlaContext : DbContext
    {
        public ItlaContext()
        {

        }

        public ItlaContext(DbContextOptions<ItlaContext> options) : base(options)
        {

        }

        #region "Registros"
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        #endregion
    }
}
