using System.Threading;
using System.Threading.Tasks;
using CQRSMediator.Models;
using MediatR;

namespace CQRSMediator.CQRS.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private ProductContext _productContext;

            public CreateEmployeeCommandHandler(ProductContext context)
            {
                _productContext = context;
            }

            public async Task<int> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = new Employee();
                employee.FirstName = command.FirstName;
                employee.LastName = command.LastName;
                employee.Email = command.Email;
                employee.Address = command.Address;
                employee.Phone = command.Phone;

                _productContext.Employees.Add(employee);
                await _productContext.SaveChangesAsync();
                return employee.Id;
            }
        }
    }
}