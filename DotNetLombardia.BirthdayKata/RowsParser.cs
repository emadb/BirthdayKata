using System;
using System.Collections.Generic;

namespace DotNetLombardia.BirthdayKata
{
    public class RowsParser : IRowsParser
    {
        private readonly IReader _reader;

        public RowsParser(IReader reader)
        {
            _reader = reader;
        }

        public IList<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            string[] lines =  _reader.GetLines();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                employees.Add(new Employee(parts[0].Trim(), parts[1].Trim(), DateTime.Parse(parts[2].Trim()), parts[3].Trim()));
            }
            return employees;
        }
    }

    public interface IRowsParser
    {
        IList<Employee> GetEmployees();
    }
}