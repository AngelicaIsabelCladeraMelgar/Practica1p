namespace WebApplicationPractica1p.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<WebApplicationPractica1p.Models.Student> Students { get; set; }
    }
 }