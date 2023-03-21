using Microsoft.Extensions.Options;
using Milestone4_CrudEmployee_MongoDB_Mar21.Interface;
using Milestone4_CrudEmployee_MongoDB_Mar21.Models;
using MongoDB.Driver;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Repository
{
    public class EmployeeRepository :IEmployee
    {
        private readonly IMongoCollection<EmployeeTable> _employeeCollection;

        public EmployeeRepository(IOptions<EmployeeDatabaseSettings> EmployeeDatabaseSettings)
        {
            var mongoClient = new MongoClient(EmployeeDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(EmployeeDatabaseSettings.Value.DatabaseName);

            _employeeCollection = mongoDatabase.GetCollection<EmployeeTable>(EmployeeDatabaseSettings.Value.EmployeeDatabaseCollectionName);
        }

        public List<EmployeeTable> GetAllEmployees()
        {
            return _employeeCollection.Find(_ => true).ToList();

        }

        public async Task GetEmployeeByDepartmentName(string EmployeeDepartment)
        {
            await _employeeCollection.Find(x => x.EmployeeDepartment==EmployeeDepartment).FirstOrDefaultAsync();

        }


        public async Task<string> CreateAsync(EmployeeTable employee)
        {
            await _employeeCollection.InsertOneAsync(employee);
            return "added";
        }

        public async Task<string> UpdateAsync(string id, EmployeeTable updatedEmployee)
        {
            await _employeeCollection.ReplaceOneAsync(x => x.id == id, updatedEmployee);
            return "updated";
        }

        public async Task<string> RemoveAsync(string id)
        {
            await _employeeCollection.DeleteOneAsync(x => x.id == id);
            return "deleted";
        }

        
    }
}
