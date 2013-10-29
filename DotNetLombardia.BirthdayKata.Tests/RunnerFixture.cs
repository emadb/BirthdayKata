using System;
using System.Collections.Generic;
using DotNetLombardia.BirthdayKata;
using Moq;
using NUnit.Framework;

namespace BirthdayKata.Tests
{
    [TestFixture]
    public class RunnerFixture
    {
        [Test]
        public void Run_WithAtLeastOneRecord_ShouldSendAtLeastAnEmail()
        {
            Mock<IRowsParser> parser = new Mock<IRowsParser>();
            Mock<IBirthdayChecker> checker = new Mock<IBirthdayChecker>();
            Mock<IMailSender> mailSender = new Mock<IMailSender>();

            parser.Setup(p => p.GetEmployees())
                .Returns(new List<Employee> {new Employee("", "", DateTime.Today, "")});
            checker.Setup(s => s.Verify(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            Runner runner = new Runner("filename", parser.Object, checker.Object, mailSender.Object );
            runner.Run();

            mailSender.Verify(m => m.SendMail(It.IsAny<Employee>()), Times.AtLeastOnce());
        }

        [Test]
        public void Run_WithAtLeastOneRecord_ShouldCallVerifyOnBirthdayChecker()
        {
            Mock<IRowsParser> parser = new Mock<IRowsParser>();
            Mock<IBirthdayChecker> checker = new Mock<IBirthdayChecker>();
            Mock<IMailSender> mailSender = new Mock<IMailSender>();

            parser.Setup(p => p.GetEmployees())
                .Returns(new List<Employee> { new Employee("", "", DateTime.Today, "") });
            checker.Setup(s => s.Verify(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            Runner runner = new Runner("filename", parser.Object, checker.Object, mailSender.Object);
            runner.Run();

            checker.Verify(c => c.Verify(It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void Run_WithAtLeastOneRecord_ItsNotHerBirthday_ShouldNotCallSendMail()
        {
            Mock<IRowsParser> parser = new Mock<IRowsParser>();
            Mock<IBirthdayChecker> checker = new Mock<IBirthdayChecker>();
            Mock<IMailSender> mailSender = new Mock<IMailSender>();

            parser.Setup(p => p.GetEmployees())
                .Returns(new List<Employee> { new Employee("", "", DateTime.Today.AddDays(-1), "") });
            checker.Setup(s => s.Verify(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            Runner runner = new Runner("filename", parser.Object, checker.Object, mailSender.Object);
            runner.Run();

            mailSender.Verify(m => m.SendMail(It.IsAny<Employee>()), Times.Never);

        }
    }
}