using CQRSMediator.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRSMediator.CQRS.Queries
{
    public class GetAllEmployeeQuery : IRequest<IEnumerable<Employee>>
    {
        public int Id { get; set; }
        public class GetAllProductQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<Employee>>
        {
            private ProductContext _productContext;

            public GetAllProductQueryHandler(ProductContext context)
            {
                _productContext = context;
            }
            public async Task<IEnumerable<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
            {
                var employee = await _productContext.Employees.ToListAsync();
                return employee;

            }
        }
    }
}