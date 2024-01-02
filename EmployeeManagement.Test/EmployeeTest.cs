using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
	public class EmployeeTest
	{
        public EmployeeTest()
        {
            
        }
        [Fact]
		public void EmployeeFullNamePropertyGetter_InputFirstName_InputLastName()
		{
			var employee = new InternalEmployee("Kapil", "Khubchandani", 0, 2500, false, 1);
			Assert.Equal("Kapil Khubchandani", employee.FullName);
		}

		[Theory]
		[InlineData("Kapil", "Khubchandani")]
		public void EmployeeFullNamePropertyGetter_InputFirstName_InputLastName_Theory(string firstName, string lastname)
		{
			var employee = new InternalEmployee(firstName, lastname, 0, 2500, false, 1);
			Assert.Equal("Kapil Khubchandani", employee.FullName);
		}

		[Theory]
		[MemberData(nameof(GetEmployeeNames))]
		public void EmployeeFullNamePropertyGetter_InputFirstName_InputLastName_TheoryMemberData(string firstName, string lastname, string fullName)
		{
			var employee = new InternalEmployee(firstName, lastname, 0, 2500, false, 1);
			Assert.Equal(fullName, employee.FullName);
		}


		public static IEnumerable<object[]> GetEmployeeNames()
		{
			return new List<object[]> {
				new object[] { "Kapil" , "Khubchandani", "Kapil Khubchandani" },
				new object[] { "Rahul" , "Tiwari", "Rahul Tiwari" }

			};
		}
	}
}
