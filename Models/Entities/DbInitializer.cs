using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiEfCorePoc.Repos;

namespace WebApiEfCorePoc.Models.Entities
{
    public static class DbInitializer
    {
        public static async Task Initialize(PaymentContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (context.PaymentHistories.Any())
            {
                return;
            }

            var user1 = new User
            {
                Id = Guid.NewGuid(),
                Name = "Jack Jones"
            };

            var user2 = new User
            {
                Id = Guid.NewGuid(),
                Name = "Lucy Marry"
            };

            await context.Users.AddRangeAsync(user1, user2);
            await context.SaveChangesAsync();

            var partner1 = new Partner
            {
                Id = Guid.NewGuid(),
                Name = "AliPay ltd."
            };
            var partner2 = new Partner
            {
                Id = Guid.NewGuid(),
                Name = "Paypal"
            };
            await context.Partners.AddRangeAsync(partner1, partner2);
            await context.SaveChangesAsync();

            var transaction1 = new Transaction
            {
                Id = Guid.NewGuid(),
                Description = "Recent Transaction 5min ago.",
                CreatedDateTime = DateTime.UtcNow.AddMinutes(-5),
                FinalisedDateTime = DateTime.UtcNow.AddMinutes(-4)
            };
            var transaction2 = new Transaction
            {
                Id = Guid.NewGuid(),
                Description = "Less Recent Transaction 5 hr ago.",
                CreatedDateTime = DateTime.UtcNow.AddHours(-5),
                FinalisedDateTime = DateTime.UtcNow.AddHours(-4).AddMinutes(-55)
            };


            var transaction3 = new Transaction
            {
                Id = Guid.NewGuid(),
                Description = "Less Recent Transaction 2 min ago.",
                CreatedDateTime = DateTime.UtcNow.AddHours(-2),
                FinalisedDateTime = DateTime.UtcNow.AddHours(-1)
            };
            await context.Transactions.AddRangeAsync(transaction1, transaction2);
            await context.SaveChangesAsync();

            var history1 = new PaymentHistory
            {
                Id = Guid.NewGuid(),
                CorrelationId = Guid.NewGuid(),
                Description = "User 1 transaction with partner 1",
                UserId = user1.Id,
                User = user1,
                PartnerId = partner1.Id,
                Partner = partner1,
                TransactionId = transaction1.Id,
                Transaction = transaction1,
                CreatedDateTime = DateTime.UtcNow.AddMinutes(-5)
            };
            var history2 = new PaymentHistory
            {
                Id = Guid.NewGuid(),
                CorrelationId = Guid.NewGuid(),
                Description = "User 2 transaction with partner 2",
                UserId = user2.Id,
                User = user2,
                PartnerId = partner2.Id,
                Partner = partner2,
                TransactionId = transaction2.Id,
                Transaction = transaction2,
                CreatedDateTime = DateTime.UtcNow.AddHours(-5)
            };

            var history3 = new PaymentHistory
            {
                Id = Guid.NewGuid(),
                CorrelationId = Guid.NewGuid(),
                Description = "User 1 transaction with partner 2",
                UserId = user1.Id,
                User = user1,
                PartnerId = partner2.Id,
                Partner = partner2,
                TransactionId = transaction3.Id,
                Transaction = transaction3,
                CreatedDateTime = DateTime.UtcNow.AddMinutes(-2)
            };

            await context.PaymentHistories.AddRangeAsync(history1, history2, history3);
            await context.SaveChangesAsync();
        }
    }
}