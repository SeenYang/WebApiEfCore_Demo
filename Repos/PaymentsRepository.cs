using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiEfCorePoc.Models.Dtos;
using WebApiEfCorePoc.Models.Entities;

namespace WebApiEfCorePoc.Repos
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly PaymentContext _context;
        private readonly IMapper _mapper;

        public PaymentsRepository(PaymentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region PaymenetHistories

        public Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistories(FetchPaymentHistoryRequestDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistoriesByCorrelationId(Guid correlationId)
        {
            var entities = await _context.PaymentHistories
                .Include(ph => ph.User)
                .Include(ph => ph.Transaction)
                .Include(ph => ph.Partner)
                .Where(ph => ph.CorrelationId == correlationId)
                .ToListAsync();

            return _mapper.Map<List<PaymentHistory>, List<PaymentHistoryDto>>(entities);
        }

        public async Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistoriesByUserId(Guid userId)
        {
            var entities = await _context.PaymentHistories
                .Include(ph => ph.User)
                .Include(ph => ph.Transaction)
                .Include(ph => ph.Partner)
                .Where(ph => ph.UserId == userId)
                .ToListAsync();

            return _mapper.Map<List<PaymentHistory>, List<PaymentHistoryDto>>(entities);
        }

        public async Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistoriesByPartnerId(Guid partnerId)
        {
            var entities = await _context.PaymentHistories
                .Where(ph => ph.PartnerId == partnerId)
                .ToListAsync();

            return _mapper.Map<List<PaymentHistory>, List<PaymentHistoryDto>>(entities);
        }

        public async Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistoriesByTransactionId(Guid transactionId)
        {
            var entities = await _context.PaymentHistories
                .Where(ph => ph.TransactionId == transactionId)
                .ToListAsync();

            return _mapper.Map<List<PaymentHistory>, List<PaymentHistoryDto>>(entities);
        }

        public async Task<IEnumerable<PaymentHistoryDto>> GetPaymentHistoriesByHistoryId(Guid id)
        {
            var entities = await _context.PaymentHistories
                .Where(ph => ph.Id == id)
                .ToListAsync();

            return _mapper.Map<List<PaymentHistory>, List<PaymentHistoryDto>>(entities);
        }

        #endregion
    }
}