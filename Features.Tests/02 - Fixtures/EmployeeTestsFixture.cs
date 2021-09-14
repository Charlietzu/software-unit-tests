using Features.Employees;
using System;
using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(EmployeeCollection))]
    public class EmployeeCollection : ICollectionFixture<EmployeeTestsFixture>{}
    public class EmployeeTestsFixture : IDisposable
    {
        public Employee CreateValidEmployee()
        {
            return new Employee(
             Guid.NewGuid(),
             "Caio",
             "César",
             DateTime.Now.AddYears(-23),
             DateTime.Now,
             "caio@gmail.com",
             true
            );
        }

        public Employee CreateInvalidEmployee()
        {
            return new Employee(
             Guid.NewGuid(),
             "",
             "",
             DateTime.Now,
             DateTime.Now,
             "caio@gmail.com",
             true
            );
        }

        public void Dispose() {}
    }
}
