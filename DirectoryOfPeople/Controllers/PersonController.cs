using AutoMapper;
using DirectoryOfPeopel.Service.Interface.IServices;
using DirectoryOfPeople.DTO;
using DirectoryOfPeople.Model;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryOfPeople.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PersonController : ControllerBase 
{
    private readonly IPersonService _personService;
    private readonly IMapper _mapper;

    public PersonController(IPersonService personService, IMapper mapper)
    {
        _personService = personService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Person>> GetPeople()
    {
        var people = await _personService.GetPerson();

        return people;
    }

    public async Task<Person> GetPersonById(int  id)
    {
        var person= await _personService.GetPerson(id);

        return person;
    }

    public async Task<ActionResult<PersonModel>> CreatePerson(PersonModel personModel)
    {
        Person person = _mapper.Map<Person>(personModel);
        _personService.CreatePerson(person);

        return RedirectToAction("GetPeople");
    }

    public ActionResult UpdatePerson(int id)
    {
        var personModel = GetPersonById(id);
        Person person = _mapper.Map<Person>(personModel);
        _personService.UpdatePerson(person);

        return RedirectToAction($"GetPersonById{id}");
    }

    public ActionResult DeletePerson(int id)
    {
        _personService.DeletePerson(id);

        if(GetPersonById(id) == null)
        return RedirectToAction("GetPeople");

        return RedirectToAction($"GetPeople{id}");
    }
}
