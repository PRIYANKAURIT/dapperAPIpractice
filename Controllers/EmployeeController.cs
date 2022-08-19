using dapperAPIpractice.Model;
using dapperAPIpractice.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dapperAPIpractice.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _iEmployeeRepo;
        public EmployeeController(IEmployeeRepository iEmployeeRepo)
        {
            this._iEmployeeRepo = iEmployeeRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employee = await _iEmployeeRepo.GetEmployees();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            try
            {
                var employee = await _iEmployeeRepo.GetEmployeeById(Id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee emp)
        {
            try
            {
                var result = await _iEmployeeRepo.CreateEmployee(emp);

                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Inserted Successfuly with compnay Id {0}", result));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee emp)
        {
            try
            {
                var result = await _iEmployeeRepo.UpdateEmployee(emp);
                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Updated Successfuly"));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var result = await _iEmployeeRepo.DeleteEmployee(id);
                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Deleted Successfuly"));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
