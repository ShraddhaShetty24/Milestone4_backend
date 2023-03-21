using Milestone4_CrudEmployee_MongoDB_Mar21.Models;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Interface
{
    public interface IEmployee
    {
        public List<EmployeeTable> GetAllEmployees();
       
        Task<string> CreateAsync(EmployeeTable employee);
        Task<string> UpdateAsync(string id, EmployeeTable updatedEmployee);
        Task<string> RemoveAsync(string id);


    }
}
