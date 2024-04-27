
using DirectoryOfPeopel.Service.Interface.IRepository;
using DirectoryOfPeople.DTO;
using DirectoryOfPeople.Repository;
using DirectoryOfPeople.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var context = new DbContextOptionsBuilder<DirectoryOfPeopleDbContext>()
                          .UseSqlServer(@"Server=DESKTOP-I95QGP7;Database=DirectoryOfPeopleDB;trusted_Connection=true;TrustServerCertificate=True").Options;

            DirectoryOfPeopleDbContext _context = new DirectoryOfPeopleDbContext(context);

            UnitOfWork _unitOfWork = new UnitOfWork(_context);

            IPersonRepository personRepository = _unitOfWork.personRepository;

            var tt = personRepository.GetPeopleRelatedToThePerson(15);
            var t1t = personRepository.GetPeopleRelatedToThePerson(16);
            //Assert.Pass();
        }
    }
}