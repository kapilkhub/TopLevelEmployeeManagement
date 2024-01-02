using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test
{
    public class CourseTest
    {
        [Fact]        
        public void CourseConstructor_Constructor_IsNewMustBeTrue() 
        {
            var course = new Course("XUnitTest");
            Assert.True(course.IsNew);
        }
    }
}
