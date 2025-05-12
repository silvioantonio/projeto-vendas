using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleCommand, Sale>()
            .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.SaleDate, DateTimeKind.Utc)));
            CreateMap<Sale, UpdateSaleResult>();
            CreateMap<SaleItem, UpdateSaleItemResult>();
        }
    }
}
