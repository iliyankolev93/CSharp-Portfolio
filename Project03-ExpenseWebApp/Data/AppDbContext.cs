using Microsoft.EntityFrameworkCore;
using Project03_ExpenseWebApp.Models;

namespace Project03_ExpenseWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }
}