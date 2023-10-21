using EmployeeManagement.Business.Exceptions;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeServiceCollection")]
    public class DataDrivenEmployeeServiceTest 
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture;

        public DataDrivenEmployeeServiceTest(EmployeeServiceFixture employeeServiceFixture)
        {
            _employeeServiceFixture = employeeServiceFixture;
        }

        [Fact]
        public async Task GiveRaise_MinimumRaiseGiven_EmployeeMinimumRaiseGivenMustBeTrue()
        {
            var internalEmployee = new InternalEmployee("Kapil", "Khubchandani", 5, 3000, false, 1);
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, 100);
            Assert.True(internalEmployee.MinimumRaiseGiven);
        }

        [Fact]
        public async Task GiveRaise_MinimumRaiseGiven_EmployeeMinimumRaiseGivenMustBeFalse()
        {
            var internalEmployee = new InternalEmployee("Kapil", "Khubchandani", 5, 3000, false, 1);
            await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, 200);
            Assert.False(internalEmployee.MinimumRaiseGiven);
        }

        [Fact]
        public async Task GiveRaise_MinimumRaiseGivenTwice_EmployeeMinimumRaiseException()
        {
            var internalEmployee = new InternalEmployee("Kapil", "Khubchandani", 5, 3000, true, 1);
            await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
                async () => await
            _employeeServiceFixture.EmployeeService.GiveRaiseAsync(internalEmployee, 100));

        }
    }
}

