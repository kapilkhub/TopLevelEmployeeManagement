using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Services.Test;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Test.Fixtures
{
   
    public class EmployeeServiceWithAspNetDIFixture  : IDisposable
    {
        private ServiceProvider _serviceProvider;
        public EmployeeServiceWithAspNetDIFixture()
        {
            var services = new ServiceCollection();
            services.AddScoped<EmployeeFactory>();  
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeManagementRepository, EmployeeManagementTestDataRepository>();

            _serviceProvider = services.BuildServiceProvider();
        }

#pragma warning disable CS8603 // Possible null reference return.
        public IEmployeeService EmployeeService
        {
            get => _serviceProvider.GetService<IEmployeeService>();
        }

        public IEmployeeManagementRepository EmployeeManagementRepository
        {
            get => _serviceProvider.GetService<IEmployeeManagementRepository>();
        }
#pragma warning restore CS8603 // Possible null reference return.

        public void Dispose()
        {
          //no code needed here
        }

    }
}
