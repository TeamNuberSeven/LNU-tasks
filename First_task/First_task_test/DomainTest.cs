using System.Collections.Generic;
using First_task.source.data;
using First_task.source.domain.entities;
using First_task.source.domain.use_cases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace First_task_test
{
    [TestClass]
    public class DomainTest
    {
        private List<Person> _mockPersons;
        private IPersonRepository _repo;
        private const int AMOUNT_OF_UNIQUE_ELEMENTS = 4;
        private const int AMOUNT_OF_STUDENTS = 3;
        private const int AMOUNT_OF_TEACHERS = 3;
        private const string AMOUNT = "Amount of student ";
        private const string TEACHER_AMOUNT = "and amount of teacher: ";

        [TestInitialize]
        public void Init()
        {
            _mockPersons = new List<Person>
            {
                new Teacher("name1", 1, "1", "1", "1"),
                new Student("name3", 3, "3", "3", "3"),
                new Teacher("name2", 2, "2", "2", "2"),
                new Student("name4", 4, "4", "4", "4"),
                new Student("name3", 3, "3", "3", "3"),
                new Teacher("name2", 2, "2", "2", "2"),
            };
            _repo = Substitute.For<IPersonRepository>();
            _repo.Fetch().Returns(_mockPersons);
        }

        [TestMethod]
        public void FetchPersonTest()
        {
            var fetchPersons = new FetchPersons(_repo).Fetch();
            Assert.AreEqual(_mockPersons[0], fetchPersons[0]);
            Assert.AreEqual(_mockPersons[3], fetchPersons[3]);
        }

        [TestMethod]
        public void FetchUniqueListOfPersonsTest()
        {
            var uniquePersons = new FetchUnigueListOfPersons(_repo).FetchUnique();
            Assert.AreEqual(uniquePersons.Count, AMOUNT_OF_UNIQUE_ELEMENTS);
        }

        [TestMethod]
        public void CountAmountOfPersons()
        {
            var personsAmount = new CountAmountOfPersons(_repo).CountPerson();
            var resultString = string.Format(AMOUNT + AMOUNT_OF_STUDENTS + TEACHER_AMOUNT + AMOUNT_OF_TEACHERS);
            Assert.AreEqual(personsAmount, resultString);
        }
    }
}