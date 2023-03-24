using WebApplication3.Model;

namespace WebApplication3.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

    }
}
