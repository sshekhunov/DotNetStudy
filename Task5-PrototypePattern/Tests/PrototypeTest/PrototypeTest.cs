using System;
using System.Net;
using Task5_PrototypePattern.Entities;
using Xunit;

namespace Task5_PrototypePattern.Tests
{
    public class PrototypeTest
    {
        [Fact]
        public void Person_MyClone_ShouldCreateDeepCopy()
        {
            var address = new Address("Москва", "Тверская");
            var person = new Person("Иван", address);

            var clone = person.MyClone();

            Assert.NotSame(person, clone);
            Assert.Equal(person.Name, clone.Name);
            Assert.NotSame(person.HomeAddress, clone.HomeAddress);
            Assert.Equal(person.HomeAddress.City, clone.HomeAddress.City);
            Assert.Equal(person.HomeAddress.Street, clone.HomeAddress.Street);
        }

        [Fact]
        public void Person_Clone_ShouldCreateDeepCopy()
        {
            var address = new Address("Москва", "Тверская");
            var person = new Person("Иван", address);

            var clone = (Person)person.Clone();

            Assert.NotSame(person, clone);
            Assert.Equal(person.Name, clone.Name);
            Assert.NotSame(person.HomeAddress, clone.HomeAddress);
            Assert.Equal(person.HomeAddress.City, clone.HomeAddress.City);
            Assert.Equal(person.HomeAddress.Street, clone.HomeAddress.Street);
        }

        [Fact]
        public void Employee_MyClone_ShouldCreateDeepCopy()
        {
            var address = new Address("Москва", "Тверская");
            var employee = new Employee("Петр", address, "Разработчик");

            var clone = employee.MyClone();

            Assert.NotSame(employee, clone);
            Assert.Equal(employee.Name, clone.Name);
            Assert.Equal(employee.Position, clone.Position);
            Assert.NotSame(employee.HomeAddress, clone.HomeAddress);
            Assert.Equal(employee.HomeAddress.City, clone.HomeAddress.City);
            Assert.Equal(employee.HomeAddress.Street, clone.HomeAddress.Street);
        }

        [Fact]
        public void Employee_Clone_ShouldCreateDeepCopy()
        {
            var address = new Address("Москва", "Тверская");
            var employee = new Employee("Петр", address, "Разработчик");

            var clone = (Employee)employee.Clone();

            Assert.NotSame(employee, clone);
            Assert.Equal(employee.Name, clone.Name);
            Assert.Equal(employee.Position, clone.Position);
            Assert.NotSame(employee.HomeAddress, clone.HomeAddress);
            Assert.Equal(employee.HomeAddress.City, clone.HomeAddress.City);
            Assert.Equal(employee.HomeAddress.Street, clone.HomeAddress.Street);
        }

        [Fact]
        public void Manager_MyClone_ShouldCreateDeepCopy()
        {
            var address = new Address("Москва", "Тверская");
            var manager = new Manager("Мария", address, "Менеджер", 5, "Проект X");

            var clone = manager.MyClone();

            Assert.NotSame(manager, clone);
            Assert.Equal(manager.Name, clone.Name);
            Assert.Equal(manager.Position, clone.Position);
            Assert.Equal(manager.TeamSize, clone.TeamSize);
            Assert.Equal(manager.ProjectName, clone.ProjectName);
            Assert.NotSame(manager.HomeAddress, clone.HomeAddress);
            Assert.Equal(manager.HomeAddress.City, clone.HomeAddress.City);
            Assert.Equal(manager.HomeAddress.Street, clone.HomeAddress.Street);
        }

        [Fact]
        public void Manager_Clone_ShouldCreateDeepCopy()
        {
            var address = new Address("Москва", "Тверская");
            var manager = new Manager("Мария", address, "Менеджер", 5, "Проект X");

            var clone = (Manager)manager.Clone();

            Assert.NotSame(manager, clone);
            Assert.Equal(manager.Name, clone.Name);
            Assert.Equal(manager.Position, clone.Position);
            Assert.Equal(manager.TeamSize, clone.TeamSize);
            Assert.Equal(manager.ProjectName, clone.ProjectName);
            Assert.NotSame(manager.HomeAddress, clone.HomeAddress);
            Assert.Equal(manager.HomeAddress.City, clone.HomeAddress.City);
            Assert.Equal(manager.HomeAddress.Street, clone.HomeAddress.Street);
        }
    }
}