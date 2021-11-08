using System;

namespace WebApiEfCorePoc.Models.Dtos
{
    public class FetchPaymentHistoryRequestDto
    {
        public Guid? CorrelationId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? PartnerId { get; set; }
        public Guid? TransactionId { get; set; }
        public Guid? HistoryId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}