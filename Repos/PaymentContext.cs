using Microsoft.EntityFrameworkCore;
using WebApiEfCorePoc.Models;
using WebApiEfCorePoc.Models.Entities;

namespace WebApiEfCorePoc.Repos
{
    public class PaymentContext: DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
            
        }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}