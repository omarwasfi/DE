using System;
using DE.Server.DataModels;
using DE.Shared;
using AutoMapper;


namespace DE.Server.MappingConfiguration
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<AssetDataModel, AssetDataViewModel>()
				.ForMember(x => x.Picure, opt => opt.Ignore())
				.ForMember(x => x.Decuments, opt => opt.Ignore());

			CreateMap<AssetDataViewModel, AssetDataModel>()
				.ForMember(x => x.Picure, opt => opt.Ignore())
				.ForMember(x => x.Decuments, opt => opt.Ignore())
				.ForMember(x => x.Id, opt => opt.Ignore());

		}
	}
}

