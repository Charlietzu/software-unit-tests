using Features.Core;

namespace Features.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetByEmail(string email);
    }
}
