using AutoMapper;
using DirectoryOfPeople.DTO;
using DirectoryOfPeople.Model;

namespace DirectoryOfPeople.Maping;

public class Mapping:Profile
{
    public Mapping()
    {
        CreateMap<City,CityModel>().ReverseMap();
        CreateMap<ContactInformation,ContactInformationModel>().ReverseMap();
        CreateMap<Person,PersonModel>().ReverseMap();
        CreateMap<PersonalityConnection,PersonalityConnectionModel>().ReverseMap();
    }
}
