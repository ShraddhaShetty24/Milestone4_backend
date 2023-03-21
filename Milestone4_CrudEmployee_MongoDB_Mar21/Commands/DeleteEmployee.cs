using Amazon.Runtime.Internal;
using MediatR;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Commands
{
    public record DeleteEmployee(string employeeId):IRequest<string>;
    
}
