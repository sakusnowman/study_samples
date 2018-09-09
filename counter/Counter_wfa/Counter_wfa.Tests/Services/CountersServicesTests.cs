﻿using System;
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
    }
}
