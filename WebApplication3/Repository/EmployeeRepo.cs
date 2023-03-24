using Microsoft.EntityFrameworkCore;
using WebApplication3.Model;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace WebApplication3.Repository
{

    public class EmployeeRepository : IEmployeeRepository 
    {
       


/*        private readonly APIDbContext _appDBContext;
        public EmployeeRepository(APIDbContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }*/
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            List<Employee> employees = new();

            String connect = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=webapp3;Integrated Security=True";

            using (SqlConnection connection = new(connect))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new("SELECT * FROM Employees", connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Employee employee = new()
                            {
                                EmployeeID = reader.GetInt32(0),
                                EmployeeName = reader.GetString(1),
                                Department = reader.GetString(2),
                              
                            };

                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }





    }
}
