using System.Collections;

namespace EmployeeManagement.Test.TestData
{
    public class EmployeeServiceTestData : TheoryData<int,bool>
    {
        public EmployeeServiceTestData()
        {
            Add(100, true);
            Add(200, false);
        }
    }
}
