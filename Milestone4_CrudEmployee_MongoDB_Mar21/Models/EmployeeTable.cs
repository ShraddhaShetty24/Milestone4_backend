using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Models
{
    public class EmployeeTable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeAge { get; set; }

        public int EmployeeSalary { get; set; }

        public string EmployeeDesignation { get; set; }

        public string EmployeeDepartment { get; set; }


    }
}
