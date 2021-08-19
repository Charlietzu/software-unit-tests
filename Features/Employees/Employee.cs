using Features.Core;
using FluentValidation;
using System;

namespace Features.Employees
{
    public class Employee : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }

        protected Employee()
        {
        }

        public Employee(Guid id, string firstName, string lastName, DateTime birthDate, DateTime registerDate, string email, bool active)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            RegisterDate = registerDate;
            Email = email;
            Active = active;
        }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        public bool IsSpecial()
        {
            return BirthDate < DateTime.Now.AddYears(-3) && Active;
        }

        public void Inactivate()
        {
            Active = false;
        }

        public override bool IsValid()
        {
            ValidationResult = new EmployeeValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(c => c.FirstName)
               .NotEmpty().WithMessage("Please enter the first name.")
               .Length(2, 150).WithMessage("The first name must be between 2 and 150 characters.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Please enter the last name.")
                .Length(2, 150).WithMessage("The last name must be between 2 and 150 characters.");

            RuleFor(c => c.BirthDate)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("The employee must be 18 years old or older");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }
    }
}
