using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Counter_wfa.Contollers;
using Counter_wfa.Services;
using MessengerHelper.Messengers;
using Counter_wfa.Messages;

namespace Counter_wfa.Tests.Controller
{
    [TestFixture]
    public class CountersViewControllerTests
    {
        CountersViewController controller;
        Mock<ICountersService> service;
        Mock<IMessenger> messenger;

        [SetUp]
        public void SetUp()
        {
            service = new Mock<ICountersService>();
            messenger = new Mock<IMessenger>();
            controller = new CountersViewController(service.Object, messenger.Object);
        }

        [Test]
        public async Task AddNewCounter_AAA_CreateAAACounterAndMessengerPost()
        {
            // Arrange
            service.Setup(s => s.AddNewCounter(It.IsAny<string>())).ReturnsAsync(true);
            // Act
            await controller.AddNewCounter("AAA");
            // Assert
            service.Verify(s => s.AddNewCounter("AAA"));
            service.Verify(s => s.GetAllCounters());
            messenger.Verify(m => m.PostMessage(It.IsAny<CountersChangedMessage>()));
        }

        [TestCase("")]
        [TestCase("Already")]
        public async Task AddNewCounter_NameIsAlreadyCreated_CannotCreateCounter(string counterName)
        {
            // Arrange
            service.Setup(s => s.AddNewCounter(counterName)).ReturnsAsync(false);
            // Act
            await controller.AddNewCounter(counterName);
            // Assert
            service.Verify(s => s.AddNewCounter(counterName));
            service.Verify(s => s.GetAllCounters(), Times.Never);
            messenger.Verify(m => m.PostMessage(It.IsAny<object>()), Times.Never);
        }
    }
}
