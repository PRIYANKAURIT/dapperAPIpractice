using dapperAPIpractice.Model;
using dapperAPIpractice.Repository;

namespace dapperAPIpractice.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _iEmployeeRepo;
        public EmployeeServices(IEmployeeRepository iEmployeeRepo)
        {
            _iEmployeeRepo = iEmployeeRepo;
        }

        public Task<int> CreateEmployee(Employee emp)
        {
            return _iEmployeeRepo.CreateEmployee(emp);
        }

        public Task<int> DeleteEmployee(int id)
        {
            return _iEmployeeRepo.DeleteEmployee(id);
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            return _iEmployeeRepo.GetEmployeeById(id);
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            return _iEmployeeRepo.GetEmployees();
        }

        public Task<int> UpdateEmployee(Employee emp)
        {
            return _iEmployeeRepo.UpdateEmployee(emp);
        }
    }
}
