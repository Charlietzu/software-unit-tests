using Bogus;
using Bogus.DataSets;
using Features.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Bogus.DataSets.Name;

namespace Features.Tests
{
    [CollectionDefinition(nameof(EmployeeBogusCollection))]
    public class EmployeeBogusCollection : ICollectionFixture<EmployeeBogusTestsFixture> { }
    public class EmployeeBogusTestsFixture : IDisposable
    {
        public Employee CreateValidEmployee()
        {
            return CreateEmployees(1, true).FirstOrDefault();
        }

        public IEnumerable<Employee> CreateVariedEmployees()
        {
            var employees = new List<Employee>();

            employees.AddRange(CreateEmployees(50, true).ToList());
            employees.AddRange(CreateEmployees(50, false).ToList());

            return employees;
        }

        public IEnumerable<Employee> CreateEmployees(int quantity, bool active)
        {
            Gender gender = new Faker().PickRandom<Name.Gender>();

            return new Faker<Employee>("pt_BR")
                .CustomInstantiator(f => new Employee(
                    Guid.NewGuid(),
                f.Name.FirstName(gender),
                f.Name.LastName(gender),
                f.Date.Past(80, DateTime.Now.AddYears(-18)),
                DateTime.Now,
                "",
                active
                    )).RuleFor(e => e.Email, (f, e) =>
                    f.Internet.Email(e.FirstName.ToLower(), e.LastName.ToLower())).Generate(quantity);
        }

        public Employee CreateInvalidEmployee()
        {
            Gender gender = new Faker().PickRandom<Name.Gender>();

            return new Faker<Employee>("pt_BR")
                .CustomInstantiator(f => new Employee(
                    Guid.NewGuid(),
                    f.Name.FirstName(gender),
                    f.Name.LastName(gender),
                    f.Date.Past(1, DateTime.Now.AddYears(1)),
                    DateTime.Now,
                    "",
                    false
                    ));
        }
        public void Dispose()
        {}
    }
}
