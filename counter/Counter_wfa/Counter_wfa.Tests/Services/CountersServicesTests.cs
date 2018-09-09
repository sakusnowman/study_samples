using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Counter_wfa.Services;
using NUnit.Framework;
using Moq;
using Counter_wfa.Models;
using Counter_wfa.Repositories;

namespace Counter_wfa.Tests.Services
{
    [TestFixture]
    public class CountersServicesTests
    {
        ICountersService service;
        Mock<ICountersRepository> repository;

        [SetUp]
        public void SetUP()
        {
            repository = new Mock<ICountersRepository>();
            service = new CountersService(repository.Object);
        }

        [Test]
        public async Task AddNewCounter_AAA_SaveToRepositoryAndReturnTrue()
        {
            // Act
            var result = await service.AddNewCounter("AAA");
            // Assert
            repository.Verify(r => r.SaveOrReplace(It.Is<Counter>(c => c.Name.Equals("AAA"))));
            Assert.IsTrue(result);
        }

        [Test]
        public async Task AddNewCounter_AAA_IsAlreadyInTheRepository_CannotAddCOunter()
        {
            // Arrange
            repository.Setup(r => r.GetCounters()).ReturnsAsync(new List<Counter>() { new Counter("AAA") });
            // Act
            var result = await service.AddNewCounter("AAA");
            // Assert
            repository.Verify(r => r.GetCounters());
            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetAllCounters_GetFromRepository()
        {
            // Arrange
            var counters = new List<Counter>()
            {
                new Counter("AAA"),
                new Counter("BBB"),
                new Counter("CCC")
            };
            repository.Setup(r => r.GetCounters()).ReturnsAsync(counters);
            //Act
            var result =await service.GetAllCounters();
            // Assert
            repository.Verify(r => r.GetCounters());
            Assert.AreEqual(counters, result);
        }

        [Test]
        public async Task IncrementCounter_AAA_AAAsCountAdded1()
        {
            // Arrange
            var counter = new Counter("AAA");
            var initialCount = counter.Count;
            // Act
            await service.IncrementCount(counter);
            // Asseert
            Assert.IsTrue(initialCount < counter.Count);
            repository.Verify(r => r.SaveOrReplace(counter));
        }
    }
}
