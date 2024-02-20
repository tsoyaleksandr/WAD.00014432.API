using AutoMapper;
using WAD._00014432.API.DAL.DTOs;
using WAD._00014432.API.DAL.Models;
using WAD._00014432.API.DAL.Responses;

namespace WAD._00014432.API.DAL.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Key, KeyDto>().ReverseMap();
			CreateMap<KeyStore, KeyStoreDto>().ReverseMap();
			CreateMap<Key, KeyResponse>().ReverseMap();
			CreateMap<KeyStore, KeyStoreReponse>().ReverseMap();
			CreateMap<KeyStoreReponse, KeyStore>();
		}
	}
}
