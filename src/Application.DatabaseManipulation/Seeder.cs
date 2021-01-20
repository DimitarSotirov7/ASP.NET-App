using Application.Data;

namespace Application.DatabaseManipulation
{
    public class Seeder
    {
        private ApplicationDbContext db;

        public Seeder(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
