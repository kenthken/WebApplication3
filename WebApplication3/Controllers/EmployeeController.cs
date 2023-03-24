using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using WebApplication3.Repository;
using System.Data.SqlClient;
namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;

        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee ??
                throw new ArgumentNullException(nameof(employee));
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employee.GetEmployees());
        }
       
    }
}
