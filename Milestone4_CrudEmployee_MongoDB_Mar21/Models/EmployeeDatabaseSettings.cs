namespace Milestone4_CrudEmployee_MongoDB_Mar21.Models
{
    public class EmployeeDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string EmployeeDatabaseCollectionName { get; set; } = null!;
    }
}
