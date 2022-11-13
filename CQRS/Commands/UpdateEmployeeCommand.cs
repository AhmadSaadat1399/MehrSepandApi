using System.Linq;
using CQRSMediator.Models;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace CQRSMediator.CQRS.Commands
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private ProductContext _context;

            public UpdateEmployeeCommandHandler(ProductContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = _context.Employees.Where(it => it.Id == command.Id).FirstOrDefault();

                if (employee == null)
                {
                    return default;
                }
                else
                {
                    employee.FirstName = command.FirstName;
                    employee.LastName = command.LastName;
                    employee.Email = command.Email;
                    employee.Address = command.Address;
                    employee.Phone = command.Phone;
                    await _context.SaveChangesAsync();
                    return employee.Id;
                }
            }
        }
    }
}