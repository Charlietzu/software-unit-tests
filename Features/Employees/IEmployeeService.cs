using System;
using System.Collections.Generic;

namespace Features.Employees
{
    public interface IEmployeeService : IDisposable
    {
        IEnumerable<Employee> GetAllActive();
        void Add(Employee employee);
        void Update(Employee employee);
        void Remove(Employee employee);
        void Inactivate(Employee employee);
    }
}
