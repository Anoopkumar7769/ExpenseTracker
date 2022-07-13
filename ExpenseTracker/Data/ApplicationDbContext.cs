using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;

namespace ExpenseTracker.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items{ get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<ExpenditureType> ExpenditureTypes { get; set; }

    }
}
