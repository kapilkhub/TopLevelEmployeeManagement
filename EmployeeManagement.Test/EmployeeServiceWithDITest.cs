using EmployeeManagement.Test.Fixtures;

namespace EmployeeManagement.Test
{

    [Collection(nameof(EmployeeServiceWithAspNetDICollectionFixture))]
    public class EmployeeServiceWithDITest
    {
        private readonly EmployeeServiceWithAspNetDIFixture _employeeServiceFixture;

        public EmployeeServiceWithDITest(EmployeeServiceWithAspNetDIFixture employeeServiceFixture)
        {
            _employeeServiceFixture = employeeServiceFixture;
        }
        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourseWithObject()
        {
            var obligatoryCourse = _employeeServiceFixture.EmployeeManagementRepository.GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            var internalEmployee = _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Kapil", "Khubchandani");

            Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);

        }
    }
}
