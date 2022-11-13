using System.Linq;
using CQRSMediator.Models;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator.CQRS.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }

        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
        {
            private ProductContext _context;

            public GetEmployeeByIdQueryHandler(ProductContext context)
            {
                _context = context;
            }

            public async Task<Employee> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.Where(it => it.Id == query.Id).FirstOrDefaultAsync();
                return employee;
            }
        }
    }
}