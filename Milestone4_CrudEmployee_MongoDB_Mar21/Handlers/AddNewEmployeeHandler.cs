using MediatR;
using Milestone4_CrudEmployee_MongoDB_Mar21.Commands;
using Milestone4_CrudEmployee_MongoDB_Mar21.Interface;
using Milestone4_CrudEmployee_MongoDB_Mar21.Models;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Handlers
{
    public class AddNewEmployeeHandler :IRequestHandler<AddNewEmployee,string>
    {
        private readonly IEmployee _employee;

        public AddNewEmployeeHandler(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task<string> Handle(AddNewEmployee request, CancellationToken cancellationToken)
        {
            return  await Task.FromResult( await _employee.CreateAsync(request.employee));
        }
       
    }
}
