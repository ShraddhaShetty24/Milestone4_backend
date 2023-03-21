using MediatR;
using Milestone4_CrudEmployee_MongoDB_Mar21.Interface;
using Milestone4_CrudEmployee_MongoDB_Mar21.Models;
using Milestone4_CrudEmployee_MongoDB_Mar21.Queries;

namespace Milestone4_CrudEmployee_MongoDB_Mar21.Handlers
{
    public class GetAllEmployeesQueryHandler :IRequestHandler<GetAllEmployeesQuery,List<EmployeeTable>>
    {
        private readonly IEmployee _employee;
        public GetAllEmployeesQueryHandler(IEmployee employee)
        {
            _employee=employee;
        }

        public Task<List<EmployeeTable>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_employee.GetAllEmployees());
        }
    }
}
