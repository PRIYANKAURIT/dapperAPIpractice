﻿using dapperAPIpractice.Model;

namespace dapperAPIpractice.Services
{
    public interface IEmployeeServices
    {
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<Employee> GetEmployeeById(int id);
        public Task<int> CreateEmployee(Employee emp);
        public Task<int> UpdateEmployee(Employee emp);
        public Task<int> DeleteEmployee(int id);
    }
}
