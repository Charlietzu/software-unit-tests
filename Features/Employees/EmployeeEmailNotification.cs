using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Employees
{
    public class EmployeeEmailNotification : INotification
    {
        public string Origin { get; private set; }
        public string Destination { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }

        public EmployeeEmailNotification(string origin, string destiny, string subject, string message)
        {
            Origin = origin;
            Destination = destiny;
            Subject = subject;
            Message = message;
        }
    }
}
