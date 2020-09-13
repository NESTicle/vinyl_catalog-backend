using AutoMapper;
using VinylCollection.Data.Models.Communities;
using VinylCollection.Data.Models.Security;
using VinylCollection.Data.Models.Vinyls;
using VinylCollection.Domain.ViewModels.Communities;
using VinylCollection.Domain.ViewModels.Security;
using VinylCollection.Domain.ViewModels.Vinyls;

namespace VinylCollection.Data.Models.Mappings.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Community, CommunityViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<Vinyl, VinylViewModel>();
        }
    }
}
