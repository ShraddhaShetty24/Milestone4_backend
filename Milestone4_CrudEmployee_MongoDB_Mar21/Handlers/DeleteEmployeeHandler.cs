using MediatR;
using Milestone4_CrudEmployee_MongoDB_Mar21.Commands;
using Milestone4_CrudEmployee_MongoDB_Mar21.Interface;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Handlers
{
    public class DeleteEmployeeHandler :IRequestHandler<DeleteEmployee,string>
    {
        private readonly IEmployee _employee;

        public DeleteEmployeeHandler(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task<string> Handle(DeleteEmployee request, CancellationToken cancellationToken)
        {
            return  await Task.FromResult(await _employee.RemoveAsync(request.employeeId));
        }
    }
}
