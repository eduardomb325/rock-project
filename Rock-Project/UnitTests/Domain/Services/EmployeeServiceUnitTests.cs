using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using RockProjectAPI.Domain.Repositories.Interfaces;
using RockProjectAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Domain.Services
{
    public class EmployeeServiceUnitTests
    {
        public Mock<IEmployeeRepository> employeeRepositoryMock;
        public ILogger<EmployeeService> logger;

        public EmployeeService employeeService;

        public EmployeeServiceUnitTests()
        {
            employeeRepositoryMock = new Mock<IEmployeeRepository>();
            logger = GetLogger();

            employeeService = new EmployeeService(employeeRepositoryMock.Object, logger);
        }

        private ILogger<EmployeeService> GetLogger()
        {
            var serviceProvider = new ServiceCollection()
                                    .AddLogging()
                                    .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            var logger = factory.CreateLogger<EmployeeService>();

            return logger;
        }
    }
}
