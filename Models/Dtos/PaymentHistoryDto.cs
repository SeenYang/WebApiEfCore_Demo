using System;

namespace WebApiEfCorePoc.Models.Dtos
{
    public class PaymentHistoryDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Description { get; set; }
        public Guid CorrelationId { get; set; }
        
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        
        public Guid PartnerId { get; set; }
        public PartnerDto Partner { get; set; }

        public Guid TransactionId { get; set; }
        public TransactionDto Transaction { get; set; }
    }
}