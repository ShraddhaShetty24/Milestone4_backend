using MediatR;
using Milestone4_CrudEmployee_MongoDB_Mar21.Commands;
using Milestone4_CrudEmployee_MongoDB_Mar21.Interface;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Handlers
{
    public class UpdateEmployeeHandler:IRequestHandler<UpdateEmployee,string>
    {

        private readonly IEmployee _employee;

        public UpdateEmployeeHandler(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task<string> Handle(UpdateEmployee request, CancellationToken cancellationToken)
        {
            return await Task.FromResult( await _employee.UpdateAsync(request.employee.id,request.employee));
        }
    
    }
}
