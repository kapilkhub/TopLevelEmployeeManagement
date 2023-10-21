using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryUnitTest
    {
        EmployeeFactory _employeeFactory;
        public EmployeeFactoryUnitTest()
        {
             _employeeFactory = new EmployeeFactory();
        }
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kapil", "Khubchandani", "KKTECH");

            Assert.Equal(2500, employee.Salary);
            
        }
    }
}
