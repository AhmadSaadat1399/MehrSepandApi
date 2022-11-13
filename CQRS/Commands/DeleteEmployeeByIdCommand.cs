using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRSMediator.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediator.CQRS.Commands
{
    public class DeleteEmployeeByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteEmployeeByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private ProductContext _context;

            public DeleteEmployeeByIdCommandHandler(ProductContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var employeeId = await _context.Employees.Where(it => it.Id == command.Id).FirstOrDefaultAsync();
                _context.Employees.Remove(employeeId);
                await _context.SaveChangesAsync();
                return employeeId.Id;
            }
        }
    }
}