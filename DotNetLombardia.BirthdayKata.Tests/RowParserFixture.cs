using System;
using System.Collections.Generic;
using DotNetLombardia.BirthdayKata;
using Moq;
using NUnit.Framework;

namespace BirthdayKata.Tests
{
    [TestFixture]
    public class RowParserFixture
    {
        private Mock<IReader> _fileReader;
        private RowsParser _rowsParser;

        [SetUp]
        public void SetUp()
        {            
            _fileReader = new Mock<IReader>();   
            _rowsParser = new RowsParser(_fileReader.Object);
        }

        [Test]
        public void GetEmployees_IfFileIsEmpty_ShouldReturnAnEmpyList()
        {
            _fileReader.Setup(f => f.GetLines()).Returns(new string[0]);   
            IList<Employee> employees = _rowsParser.GetEmployees();
            Assert.IsEmpty(employees);
        }


        [Test]
        public void GetEmployees_ShouldCallGetLinesOnFileReader()
        {
            _fileReader.Setup(f => f.GetLines()).Returns(new string[0]);
            _rowsParser.GetEmployees();
            _fileReader.Verify(f => f.GetLines());

            
        }

        [Test]
        public void GetEmployees_FileContainsOneLine_ShouldReturnAListWithAnEmployee()
        {

            _fileReader.Setup(f => f.GetLines()).Returns(new[] { "Doe, John, 1982/10/08, john.doe@foobar.com" });
            
            IList<Employee> employees = _rowsParser.GetEmployees();

            Assert.AreEqual(1, employees.Count);
        }

        [Test]
        public void GetEmployees_FileContainsOneLine_ShouldReturnAValidEmployee()
        {
            _fileReader.Setup(f => f.GetLines()).Returns(new[] { "Doe, John, 1982/10/08, john.doe@foobar.com" });

            IList<Employee> employees = _rowsParser.GetEmployees();

            Assert.AreEqual("Doe", employees[0].Surname);
            Assert.AreEqual("John", employees[0].Name);
            Assert.AreEqual(new DateTime(1982,10,08), employees[0].Birthday);
            Assert.AreEqual("john.doe@foobar.com", employees[0].Email);
            
        }
    }


}