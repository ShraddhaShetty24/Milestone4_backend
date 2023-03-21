using Amazon.Runtime.Internal;
using MediatR;
using Milestone4_CrudEmployee_MongoDB_Mar21.Models;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Queries
{
    public record GetAllEmployeesQuery: IRequest<List<EmployeeTable>>;
    
}
