using Bogus;
using Bogus.DataSets;
using Features.Employees;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Bogus.DataSets.Name;

namespace Features.Tests
{
    [CollectionDefinition(nameof(EmployeeAutoMockerCollection))]
    public class EmployeeAutoMockerCollection : ICollectionFixture<EmployeeTestsAutoMockerFixture>
    {
    }

    public class EmployeeTestsAutoMockerFixture : IDisposable
    {
        public EmployeeService EmployeeService;
        public AutoMocker Mocker;

        public Employee CreateValidEmployee()
        {
            return CreateEmployees(1, true).FirstOrDefault();
        }

        public IEnumerable<Employee> CreateVariedEmployees()
        {
            List<Employee> employees = new List<Employee>();

            employees.AddRange(CreateEmployees(50, true).ToList());
            employees.AddRange(CreateEmployees(50, false).ToList());

            return employees;
        }

        public IEnumerable<Employee> CreateEmployees(int quantity, bool active)
        {
            Gender genero = new Faker().PickRandom<Name.Gender>();

            Faker<Employee> employees = new Faker<Employee>("pt_BR")
                .CustomInstantiator(f => new Employee(
                    Guid.NewGuid(),
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    DateTime.Now,
                    "",
                    active))
                .RuleFor(c => c.Email, (f, c) =>
                      f.Internet.Email(c.FirstName.ToLower(), c.LastName.ToLower()));

            return employees.Generate(quantity);
        }

        public Employee CreateInvalidEmployee()
        {
            Gender genero = new Faker().PickRandom<Name.Gender>();

            return new Faker<Employee>("pt_BR")
                .CustomInstantiator(f => new Employee(
                    Guid.NewGuid(),
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    f.Date.Past(1, DateTime.Now.AddYears(1)),
                    DateTime.Now,
                    "",
                    false));
        }

        public EmployeeService GetEmployeeService()
        {
            Mocker = new AutoMocker();
            EmployeeService = Mocker.CreateInstance<EmployeeService>();

            return EmployeeService;
        }

        public void Dispose()
        {
        }
    }
}
