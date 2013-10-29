using System;

namespace DotNetLombardia.BirthdayKata
{
    public class BirthdayChecker : IBirthdayChecker
    {
        public bool Verify(int month, int day)
        {
            var today = DateTime.Today;
            return month == today.Month && day == today.Day;
        }
    }

    public interface IBirthdayChecker
    {
        bool Verify(int month, int day);
    }

    public interface IMailSender
    {
        void SendMail(Employee employee);
    }

    public class Runner
    {
        private readonly string _filename;
        private readonly IRowsParser _rowsParser;
        private readonly IBirthdayChecker _birthdayChecker;
        private readonly IMailSender _mailSender;

        public Runner(string filename, IRowsParser rowsParser, IBirthdayChecker birthdayChecker, IMailSender mailSender)
        {
            _filename = filename;
            _rowsParser = rowsParser;
            _birthdayChecker = birthdayChecker;
            _mailSender = mailSender;
        }

        public void Run()
        {
            Employee employee = _rowsParser.GetEmployees()[0];
            bool verify = _birthdayChecker.Verify(employee.Birthday.Month, employee.Birthday.Day);
            if (verify)
                _mailSender.SendMail(employee);
        }
    }
}