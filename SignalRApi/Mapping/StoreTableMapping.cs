using AutoMapper;
using SignalR.DtoLayer.StoreTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class StoreTableMapping : Profile
	{
		public StoreTableMapping()
		{
			CreateMap<StoreTable, ResultStoreTableDto>().ReverseMap();
			CreateMap<StoreTable, CreateStoreTableDto>().ReverseMap();
			CreateMap<StoreTable, GetByIdStoreTableDto>().ReverseMap();
			CreateMap<StoreTable, UpdateStoreTableDto>().ReverseMap();
		}
	}
}
