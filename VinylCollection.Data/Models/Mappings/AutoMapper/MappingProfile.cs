using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VinylCollection.Data.Models.Communities;
using VinylCollection.Data.Models.Security;
using VinylCollection.Domain.ViewModels.Communities;
using VinylCollection.Domain.ViewModels.Security;

namespace VinylCollection.Data.Models.Mappings.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Community, CommunityViewModel>();
            CreateMap<User, UserViewModel>();
        }
    }
}
