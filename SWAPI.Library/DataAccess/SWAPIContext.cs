using Microsoft.EntityFrameworkCore;
using SWAPI.Library.Models;

namespace SWAPI.Library.DataAccess
{
    public class SWAPIContext : DbContext
    {
        private string _dataSource;

        public DbSet<Person> People { get; set; }

        public SWAPIContext(string dataSource)
        {
            _dataSource = dataSource;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={ _dataSource }");
        }
    }
}
