using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEfCorePoc.Models;
using WebApiEfCorePoc.Models.Dtos;
using WebApiEfCorePoc.Models.Entities;

namespace WebApiEfCorePoc.Repos
{
    public interface IPaymentsRepository
    {
        Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistories(FetchPaymentHistoryRequestDto request);
        Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistoriesByCorrelationId(Guid correlationId);
        Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistoriesByUserId(Guid userId);
        Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistoriesByPartnerId(Guid partnerId);
        Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistoriesByTransactionId(Guid transactionId);
        Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistoriesByHistoryId(Guid id);
    }
}