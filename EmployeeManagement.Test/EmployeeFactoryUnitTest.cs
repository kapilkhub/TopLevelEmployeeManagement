using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryUnitTest
    {

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            EmployeeFactory employeeFactory = new EmployeeFactory();
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kapil", "Khubchandani", "KKTECH");

            Assert.Equal(2500, employee.Salary);
            
        }
    }
}
