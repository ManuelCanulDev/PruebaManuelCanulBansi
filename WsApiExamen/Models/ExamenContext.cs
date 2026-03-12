using System.Data.Entity;

namespace WsApiExamen.Models
{
    public class ExamenContext: DbContext
    {
        public ExamenContext() : base("Server=localhost;Database=BdiExamen;Trusted_Connection=True")
        {
            Database.SetInitializer<ExamenContext>(null);
        }

        public DbSet<Examen> Examenes { get; set; }
    }
}
