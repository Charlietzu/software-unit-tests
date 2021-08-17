using Demo;
using System;
using System.Collections.Generic;

namespace Demo
{
    public class Person
    {
        public string Name { get; set; }
        public string NickName { get; set; }
    }
    public class Employee : Person
    {
        public double Salary { get; set; }
        public ProfessionalLevel ProfessionalLevel { get; set; }
        public IList<string> Skills { get; set; }

        public Employee(string name, double salary)
        {
            Name = string.IsNullOrEmpty(name) ? "Fulano" : name;
            SetSalary(salary);
            SetSkills();
        }

        public void SetSalary(double salary)
        {
            if (salary < 500) throw new Exception("Salary lower than the allowed");
            Salary = salary;

            if (salary < 2000) ProfessionalLevel = ProfessionalLevel.Junior;
            else if (salary >= 2000 && salary < 8000) ProfessionalLevel = ProfessionalLevel.Full;
            else if (salary >= 8000) ProfessionalLevel = ProfessionalLevel.Senior;
        }

        private void SetSkills()
        {
            Skills = new List<string>()
            {
                "Software Logic",
                "OOP"
            };

            switch (ProfessionalLevel)
            {
                case ProfessionalLevel.Full:
                    Skills.Add("Tests");
                    break;

                case ProfessionalLevel.Senior:
                    Skills.Add("Tests");
                    Skills.Add("Microsservices");
                    break;
            }
        }
    }
}

public enum ProfessionalLevel
{
    Junior, Full, Senior
};

public class EmployeFactory
{
    public static Employee Create(string name, double salary)
    {
        return new Employee(name, salary);
    }
}
