using Application.Data;
using System;

namespace Application.DatabaseManipulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureDeleted();
        }
    }
}
