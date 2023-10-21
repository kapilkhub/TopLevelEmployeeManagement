using EmployeeManagement.Business;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Test;

namespace EmployeeManagement.Test
{
    public class EmployeeServiceTest
    {
        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourseWithObject()
        {
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeService = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());

            var obligatoryCourse = employeeManagementTestDataRepository.GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            var internalEmployee =  employeeService.CreateInternalEmployee("Kapil", "Khubchandani");

            Assert.Contains(obligatoryCourse,internalEmployee.AttendedCourses);

        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse()
        {
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeService = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());

            var internalEmployee = employeeService.CreateInternalEmployee("Kapil", "Khubchandani");

            Assert.Contains(internalEmployee.AttendedCourses, 
                course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedSecondObligatoryCourse()
        {
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeService = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());

            var internalEmployee = employeeService.CreateInternalEmployee("Kapil", "Khubchandani");

            Assert.Contains(internalEmployee.AttendedCourses,
                course => course.Id == Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_AttendedCourseMustMatchObligatoryCourse()
        {
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeService = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());

            var internalEmployee = employeeService.CreateInternalEmployee("Kapil", "Khubchandani");
            var obligatoryCourses = employeeManagementTestDataRepository.GetCourses(
                 Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                 Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")
                );
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);

        }

        [Fact]
        public async Task CreateInternalEmployee_InternalEmployeeCreated_AttendedCourseMustMatchObligatoryCourse_Async()
        {
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeService = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());

            var internalEmployee = await employeeService.CreateInternalEmployeeAsync("Kapil", "Khubchandani");
            var obligatoryCourses = await employeeManagementTestDataRepository.GetCoursesAsync(
                 Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                 Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")
                );
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);

        }

        [Fact]
        public async Task GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionAsync()
        {
            var employeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();
            var employeeService = new EmployeeService(employeeManagementTestDataRepository, new EmployeeFactory());

            var internalEmployee = new InternalEmployee("Kapil", "Khubchandani", 0, 2500, false, 1);

          await  Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
            async () =>
            await employeeService.GiveRaiseAsync(internalEmployee, 50)
            );

        }
    }
}
