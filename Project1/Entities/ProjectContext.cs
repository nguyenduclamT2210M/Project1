using Microsoft.EntityFrameworkCore;

namespace Project1.Entities
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) 
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<SericeTypes> SericeTypes { get; set; }
        public virtual DbSet<Receivers> Receivers { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<GoodsProperties> GoodsProperties { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
    }
}
