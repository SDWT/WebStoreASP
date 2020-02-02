﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebStore.Domain.ViewModels;
using WebStore.Domain.Entity;
using WebStore.Infrastructure.Mappings;

namespace WebStore.Tests.Infrastructure.Mappings
{
    [TestClass]
    public class MappingsTest
    {
        [TestMethod]
        public void TestMappingEmployeeToEmployeeView()
        {
            var employee = new Employee
            {
                Id = 1,
                FirstName = "Николай",
                LastName = "Донцов",
                HiringDate = DateTime.Parse("2016-05-01"),
                BirthDay = DateTime.Parse("1990-12-22")
            };
            var employeeView = employee.MapEmployeeView();
            Assert.IsNotNull(employeeView);
            Assert.AreEqual(employeeView.FirstName,employee.FirstName);
        }
    }
}