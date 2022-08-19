using Dapper;
using dapperAPIpractice.context;
using dapperAPIpractice.Model;

namespace dapperAPIpractice.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryAsync<Employee>(query);  
                return employee.ToList();
            }
        }
        
        public async Task<Employee> GetEmployeeById(int id)
        {
            var query = "SELECT * FROM Employee where Id=@id";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryAsync<Employee>(query, new { id = id });
                return employee.FirstOrDefault();
            }
        }        

        public async Task<int> CreateEmployee(Employee emp)
        {
            int result = 0;
            var query = @"INSERT INTO Employee (ename,salary) 
                          VALUES (@ename,@salary);
                          SELECT CAST(SCOPE_IDENTITY() as int)";

            using (var connection = _context.CreateConnection())
            {
                result = await connection.QuerySingleAsync<int>(query, emp);
                return result;
            }
        }

        public async Task<int> UpdateEmployee(Employee emp)
        {

            int result = 0;
            var query = @"UPDATE Employee SET ename=@ename,salary=@salary
                          WHERE id=@id";

            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, emp);
                return result;
            }
        }

        public async Task<int> DeleteEmployee(int id)
        {
            int result = 0;
            var query = @"Delete from Employee WHERE Id=@id";
            using (var connection = _context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id = id });
                return result;
            }
        }
         
    }
}
