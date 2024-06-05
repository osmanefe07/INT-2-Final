using AutoMapper;
using vize.Dtos;
using vize.Models;
using vize.Dtos;
using vize.Models;

namespace vize.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Models.File, FileDto>().ReverseMap();

            CreateMap<AppUser, UserDto>().ReverseMap();

           CreateMap<Folder, FolderDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<UserGroup,UserGroupDto> ().ReverseMap();
        }
    }
}
