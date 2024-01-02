using AutoMapper;
using EmployeeManagement.Business;
using EmployeeManagement.Controllers;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.MapperProfiles;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagement.Test.Controllers
{
	public class InternalEmployeeControllerTest
    {
        private readonly InternalEmployeesController _employeesController;
        public InternalEmployeeControllerTest()
        {
            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(m => m.FetchInternalEmployeesAsync()).ReturnsAsync(
                new List<InternalEmployee>() {
                new InternalEmployee ("Kapil","Khubchandani",1,200,true,1),
                new InternalEmployee ("Rahul","Tiwari",1,200,true,1),
                new InternalEmployee ("Sachin","Tendulkar",1,200,true,1)
                });

            //var mapperMock = new Mock<IMapper>();
            //mapperMock.Setup(m => m
            //.Map<InternalEmployee, InternalEmployeeDto>(It.IsAny<InternalEmployee>()))
            //    .Returns(new InternalEmployeeDto());

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<EmployeeProfile>());
            var mapper = new Mapper(mapperConfiguration);
            _employeesController = new InternalEmployeesController(employeeServiceMock.Object, mapper);
        }
        [Fact]
        public async Task GetInetnalEmployees_GetAction_MustReturnOKObjectResult()
        {


            var result = await _employeesController.GetInternalEmployees();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<InternalEmployeeDto>>>(result);

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetInetnalEmployees_GetAction_MustReturnIEnumerableOfInternalEmploee()
        {

            var result = await _employeesController.GetInternalEmployees();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<InternalEmployeeDto>>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            var dto = Assert.IsAssignableFrom<IEnumerable<InternalEmployeeDto>>(okObjectResult.Value);

            Assert.Equal(3, dto.Count());
        }
    }
}
