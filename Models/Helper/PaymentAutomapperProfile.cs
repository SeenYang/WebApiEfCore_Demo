using AutoMapper;
using WebApiEfCorePoc.Models.Dtos;
using WebApiEfCorePoc.Models.Entities;

namespace WebApiEfCorePoc.Models.Helper
{
    public class PaymentAutomapperProfile : Profile
    {
        public PaymentAutomapperProfile()
        {
            CreateMap<Partner, PartnerDto>();
            CreateMap<PartnerDto, Partner>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Transaction, TransactionDto>();
            CreateMap<TransactionDto, Transaction>();
            CreateMap<PaymentHistory, PaymentHistoryDto>();
            CreateMap<PaymentHistoryDto, PaymentHistory>();
        }
    }
}