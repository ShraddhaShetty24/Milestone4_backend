using MediatR;
using Milestone4_CrudEmployee_MongoDB_Mar21.Models;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Commands
{
    public record UpdateEmployee(string id,EmployeeTable employee):IRequest<string>;
   
}
