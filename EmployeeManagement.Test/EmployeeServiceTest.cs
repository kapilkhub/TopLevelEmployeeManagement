using EmployeeManagement.Business;
using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Services.Test;
using EmployeeManagement.Test.Fixtures;

namespace EmployeeManagement.Test
{
    public class EmployeeServiceTest : IClassFixture<EmployeeServiceFixture>
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture;

        public EmployeeServiceTest(EmployeeServiceFixture employeeServiceFixture)
        {
            _employeeServiceFixture = employeeServiceFixture;
        }
        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourseWithObject()
        {
            var obligatoryCourse = _employeeServiceFixture.EmployeeManagementTestDataRepository.GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            var internalEmployee = _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Kapil", "Khubchandani");

            Assert.Contains(obligatoryCourse,internalEmployee.AttendedCourses);

        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse()
        {
            

            var internalEmployee = _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Kapil", "Khubchandani");

            Assert.Contains(internalEmployee.AttendedCourses, 
                course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedSecondObligatoryCourse()
        {
            var internalEmployee = _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Kapil", "Khubchandani");

            Assert.Contains(internalEmployee.AttendedCourses,
                course => course.Id == Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_AttendedCourseMustMatchObligatoryCourse()
        {
            var internalEmployee = _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Kapil", "Khubchandani");
            var obligatoryCourses = _employeeServiceFixture.EmployeeManagementTestDataRepository.GetCourses(
                 Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                 Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")
                );
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);

        }

        [Fact]
        public async Task CreateInternalEmployee_InternalEmployeeCreated_AttendedCourseMustMatchObligatoryCourse_Async()
        {
            var internalEmployee = await _employeeServiceFixture.EmployeeService.CreateInternalEmployeeAsync("Kapil", "Khubchandani");
            var obligatoryCourses = await _employeeServiceFixture.EmployeeManagementTestDataRepository.GetCoursesAsync(
                 Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                 Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")
                );
            Assert.Equal(obligatoryCourses, internalEmployee.AttendedCourses);

        }

        [Fact]
        public async Task GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionAsync()
        {
            var internalEmployee = new InternalEmployee("Kapil", "Khubchandani", 0, 2500, false, 1);

          await  Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
            async () =>
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, 50)
            );

        }
    }
}
