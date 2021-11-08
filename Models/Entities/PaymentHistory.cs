using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEfCorePoc.Models.Entities
{
    public class PaymentHistory
    {
        [Key] 
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Description { get; set; }
        public Guid CorrelationId { get; set; }
        
        [ForeignKey("paymenthistory_user_fk")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        [ForeignKey("paymenthistory_partner_fk")]
        public Guid PartnerId { get; set; }
        public Partner Partner { get; set; }

        [ForeignKey("paymenthistory_transaction_fk")]
        public Guid TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}