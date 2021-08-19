using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Features.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMediator _mediator;

        public EmployeeService(IEmployeeRepository employeeRepository,
                              IMediator mediator)
        {
            _employeeRepository = employeeRepository;
            _mediator = mediator;
        }

        public IEnumerable<Employee> GetAllActive()
        {
            return _employeeRepository.GetAll().Where(c => c.Active);
        }

        public void Add(Employee employee)
        {
            if (!employee.IsValid())
                return;

            _employeeRepository.Add(employee);
            _mediator.Publish(new EmployeeEmailNotification("admin@me.com", employee.Email, "Hello!", "Welcome!"));
        }

        public void Update(Employee employee)
        {
            if (!employee.IsValid())
                return;

            _employeeRepository.Update(employee);
            _mediator.Publish(new EmployeeEmailNotification("admin@me.com", employee.Email, "Updates!", "Take a look!"));
        }

        public void Inactivate(Employee employee)
        {
            if (!employee.IsValid())
                return;

            employee.Inactivate();
            _employeeRepository.Update(employee);
            _mediator.Publish(new EmployeeEmailNotification("admin@me.com", employee.Email, "See you soon!", "We hope to see you again!"));
        }

        public void Remove(Employee employee)
        {
            _employeeRepository.Remove(employee.Id);
            _mediator.Publish(new EmployeeEmailNotification("admin@me.com", employee.Email, "Goodbye", "Have a great journey!"));
        }

        public void Dispose()
        {
            _employeeRepository.Dispose();
        }
    }
}
