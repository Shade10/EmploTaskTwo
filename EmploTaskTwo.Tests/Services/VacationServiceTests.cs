using EmploTaskTwo.Application.Services;
using EmploTaskTwo.Domain.Entities;
using EmploTaskTwo.Domain.Interfaces;
using EmploTaskTwo.Domain.Repositories;
using EmploTaskTwo.Tests.Mocks;
using EmploTaskTwo.Tests.TestHelpers;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace EmploTaskTwo.Tests.Services
{
    [TestFixture]
    public class VacationServiceTests
    {
        private Mock<IEmployeeRepository> _employeeRepoMock;
        private Mock<ITeamRepository> _teamRepoMock;
        private Mock<IVacationRepository> _vacationRepoMock;
        private VacationService _vacationService;

        [SetUp]
        public void Setup()
        {
            _employeeRepoMock = new Mock<IEmployeeRepository>();
            _teamRepoMock = new Mock<ITeamRepository>();
            _vacationRepoMock = new Mock<IVacationRepository>();

            _vacationService = new VacationService(
                _employeeRepoMock.Object,
                _teamRepoMock.Object,
                _vacationRepoMock.Object);
        }

        [Test]
        public void employee_can_request_vacation()
        {
            // Arrange
            int currentYear = DateTime.Now.Year;
            var employees = EmployeeMockData.GetEmployeesWithVacations(currentYear);
            var vacations = VacationMockData.GetVacationsForYear(currentYear).ToList();
            var employee = employees.First();

            _employeeRepoMock
                .Setup(r => r.Query())
                .Returns(employees);

            _vacationRepoMock
                .Setup(r => r.Query())
                .Returns(vacations.AsQueryable());

            var vacationPackage = new VacationPackage
            {
                GrantedDays = 20
            };

            // Act
            var result = _vacationService.IfEmployeeCanRequestVacation(employee, vacations, vacationPackage);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void employee_cant_request_vacation()
        {
            // Arrange
            int currentYear = DateTime.Now.Year;
            var employees = EmployeeMockData.GetEmployeesWithoutVacations();
            var vacations = VacationMockData.GetVacationsForYear(currentYear).ToList();
            var employee = employees.First();

            _employeeRepoMock
                .Setup(r => r.Query())
                .Returns(employees);

            _vacationRepoMock
                .Setup(r => r.Query())
                .Returns(vacations.AsQueryable());

            var vacationPackage = new VacationPackage
            {
                GrantedDays = 0
            };

            // Act
            var result = _vacationService.IfEmployeeCanRequestVacation(employee, vacations, vacationPackage);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
