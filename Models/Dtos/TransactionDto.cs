using System;

namespace WebApiEfCorePoc.Models.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime FinalisedDateTime { get; set; }
        public string Description { get; set; }
    }
}