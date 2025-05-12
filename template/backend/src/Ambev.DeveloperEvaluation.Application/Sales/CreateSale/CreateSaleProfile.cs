using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Profile for mapping between Sale entity and CreateSaleResponse
    /// </summary>
    public class CreateSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateSale operation
        /// </summary>
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>()
            .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.SaleDate, DateTimeKind.Utc)));
            CreateMap<Sale, CreateSaleResult>();
            CreateMap<SaleItem, CreateSaleItemResult>();
        }
    }
}
