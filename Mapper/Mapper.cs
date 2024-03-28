using AutoMapper;
using DirectoryOfPeople.DTO;
using DirectoryOfPeople.Model;

namespace Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<City, CityModel>();
        CreateMap<Person, PersonModel>();
        CreateMap<PersonalityConnection, PersonalityConnectionModel>();
        CreateMap<ContactInformation, ContactInformationModel>();
    }
}
