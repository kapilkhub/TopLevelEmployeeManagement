using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class EmployeeTest
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstName_InputLastName()
        {
            var employee = new InternalEmployee("Kapil", "Khubchandani", 0, 2500, false, 1);
            Assert.Equal("Kapil Khubchandani", employee.FullName);
        }
    }
}
