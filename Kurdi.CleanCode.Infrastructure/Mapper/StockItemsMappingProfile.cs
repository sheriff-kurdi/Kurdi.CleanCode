using AutoMapper;
using Kurdi.CleanCode.Infrastructure.DTOs;
using System.Linq;
using Kurdi.CleanCode.Core.Entities.StockAggregate;

namespace Kurdi.CleanCode.Infrastructure.Mapper
{
    public class StockItemsMappingProfile : Profile
    {
        public StockItemsMappingProfile()
        {
            CreateMap<StockItem, StockItemsDto>()
                .ForMember(
                    dto => dto.Category, 
                    stock=>stock.MapFrom(s => s.Category.Name))
                .ForMember(
                    dto => dto.Name,
                    stock=>stock.MapFrom(s => s.StockItemDetails.FirstOrDefault().Name))
                .ForMember(
                    dto => dto.Description,
                    stock=>stock.MapFrom(s => s.StockItemDetails.FirstOrDefault().Name))
                .ReverseMap();
        }
    }
}